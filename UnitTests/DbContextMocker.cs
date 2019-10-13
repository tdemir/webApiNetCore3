using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Models;
using Xunit;

namespace UnitTests
{
    public class DbContextMocker
    {
        public static ApiDbContext GetApiDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var configPath = System.AppContext.BaseDirectory;//appsettings.json file path
            var configuration = GetIConfigurationRoot(configPath);

            // Create instance of DbContext
            var dbContext = new ApiDbContext(options, configuration);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {            
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("e3dfcccf-0cb3-423a-b302-e3e92e95c128")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}