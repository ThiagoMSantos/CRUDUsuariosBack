using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class ConfitecContextFactory : IDesignTimeDbContextFactory<ConfitecContext>
    {
        public ConfitecContextFactory()
        {
        }

        public ConfitecContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfitecContext>();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new ConfitecContext(optionsBuilder.Options, configuration);
        }
    }
}
