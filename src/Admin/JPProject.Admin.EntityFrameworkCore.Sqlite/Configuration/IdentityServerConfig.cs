using JPProject.Admin.Infra.Data.Configuration;
using JPProject.Admin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using JPProject.Admin.Domain.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseConfig
    {
        public static IJpProjectAdminBuilder WithSqlite<T>(this IJpProjectAdminBuilder services, string connectionString, JpDatabaseOptions options = null)
        {
            var migrationsAssembly = typeof(T).GetTypeInfo().Assembly.GetName().Name;
            services.Services.AddEntityFrameworkSqlite().AddAdminContext(opt => opt.UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly)), options);

            return services;
        }

        public static IJpProjectAdminBuilder WithSqlite(this IJpProjectAdminBuilder services, Action<DbContextOptionsBuilder> optionsAction, JpDatabaseOptions options = null)
        {
            services.Services.AddAdminContext(optionsAction, options);

            return services;
        }
    }
}