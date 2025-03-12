# LibreLegends.Infrastructure

The goal of the Infrastructure project is to provide a data-access abstraction for usage in other projects.

## Dependencies

- **Aspire.Npgsql**: PostgreSQL Database Provider
- **Dapper**: Minimal ORM for executing SQL on top of Npgsql

Entity Framework is omitted to ensure maximum control over PostgreSQL.

## Database Migration

The project provides an application for migrating the database. Migration is not possible via a public interface.  
All migration scripts are located under `Migrations` and executed using `MigrateDatabase.cs`.
