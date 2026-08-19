using LiaProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LiaProjekt.Factories
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var connectionString =
                "Host=ep-shy-rain-b1njh6yc-pooler.c-5.eu-central-1.aws.neon.tech;" +
                "Database=neondb;" +
                "Username=neondb_owner;" +
                "Password=npg_OE2jBUD4sifa;" +
                "SSL Mode=Require";

            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
