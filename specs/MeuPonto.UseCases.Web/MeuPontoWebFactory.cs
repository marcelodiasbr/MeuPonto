﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using MeuPonto.Data;
using MeuPonto.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MeuPonto;

public class MeuPontoWebFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var dateTimeSnapshotDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DateTimeSnapshot));

            services.Remove(dateTimeSnapshotDescriptor);

            services.AddTransient(container => new DateTimeSnapshot(() => DateTime.Now));

            services.AddAuthentication(defaultScheme: "TestScheme")
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                    "TestScheme", options => { });

            var dbContextDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<MeuPontoDbContext>));

            services.Remove(dbContextDescriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbConnection));

            services.Remove(dbConnectionDescriptor);

            // Create open SqliteConnection so EF won't automatically close it.
            services.AddSingleton<DbConnection>(container =>
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();

                return connection;
            });

            services.AddDbContext<MeuPontoDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection, b => b.MigrationsAssembly("MeuPonto.EntityFrameworkCore.Sqlite"))
                    .UseSqliteModel();

                //options.UseInMemoryDatabase("InMemoryDbForTesting");
            });
        });

        builder.UseEnvironment("Development");
    }
}
