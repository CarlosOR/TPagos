using System;
using Microsoft.EntityFrameworkCore;
using Tuya.Pagos.Utilities.Configurations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;

namespace Tuya.Pagos.Persistence.Infraestructure
{
    public class ContructorConnection : IContructorConnection
    {
        public void ConfigureConnection(DbContextOptionsBuilder builder)
        {

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataConfiguration.SqlConnection, MigrationsOptions);
            }
        }

        private readonly Action<SqlServerDbContextOptionsBuilder> MigrationsOptions =
            options => options.MigrationsHistoryTable("PagosMigrationTable", "dbo");
    }
}
