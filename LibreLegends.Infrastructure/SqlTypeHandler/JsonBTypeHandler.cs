using System.Data;
using System.Text.Json;
using Dapper;
using Npgsql;
using NpgsqlTypes;

namespace LibreLegends.Infrastructure.SqlTypeHandler;

/// <summary>
/// Instructs Dapper to treat the provided type as a jsonb column.
/// Setting the value will trigger JSON serialization and vice versa.
/// </summary>
internal class JsonBTypeHandler<T>(JsonSerializerOptions? opt = null) : SqlMapper.TypeHandler<T>
{
    public override void SetValue(IDbDataParameter parameter, T? value)
    {
        if (parameter is not NpgsqlParameter p)
        {
            return;
        }

        p.Value = JsonSerializer.Serialize(value, opt);
        p.NpgsqlDbType = NpgsqlDbType.Jsonb;
    }

    public override T? Parse(object? value)
    {
        return value is null ? default : JsonSerializer.Deserialize<T>((string)value);
    }
}