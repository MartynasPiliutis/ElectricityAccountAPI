using Microsoft.EntityFrameworkCore;
using ElectricityAccountAPI.Models;
using System.Linq;

namespace ElectricityAccountAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AggregatedData> AggregatedDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlServer($"Server=Localhost;Database=ElectricityAccountDB;Trusted_Connection=True;");

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
    }
}
