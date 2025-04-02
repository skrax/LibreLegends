using Dapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace LibreLegends.DatabaseMigration;

internal class MigrateDatabase(NpgsqlConnection connection, IHostApplicationLifetime hostLifetime, ILogger<MigrateDatabase> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Migrating database to latest version");
        
        var migrationsFolder = Path.Combine(AppContext.BaseDirectory, "Migrations");
        
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS schema_migrations (
                                     id SERIAL PRIMARY KEY,
                                     script_name TEXT NOT NULL UNIQUE,
                                     created_at TIMESTAMP DEFAULT NOW()
                                 );");

        var appliedMigrations = await connection
            .QueryAsync<string>("SELECT script_name FROM schema_migrations")
            .ContinueWith(x => x.Result.ToHashSet(), cancellationToken);

        var migrationFiles = Directory.GetFiles(migrationsFolder, "*.sql").OrderBy(f => f);

        foreach (var migrationFile in migrationFiles)
        {
            var fileName = Path.GetFileName(migrationFile);

            if (appliedMigrations.Contains(fileName))
            {
                continue;
            }

            var sql = File.ReadAllTextAsync(migrationFile, cancellationToken: cancellationToken).Result;
            
            logger.LogInformation("Applying migration {name}", fileName);

            await using var transaction = await connection.BeginTransactionAsync(cancellationToken);

            await connection.ExecuteAsync(sql);

            await connection.ExecuteAsync(
                "INSERT INTO schema_migrations(script_name) VALUES (@script_name);",
                new { script_name = fileName, });
            
            await transaction.CommitAsync(cancellationToken);
        }
        
        logger.LogInformation("All database migrations have been applied. Stopping application...");

        await connection.CloseAsync();

        hostLifetime.StopApplication();
    }
}