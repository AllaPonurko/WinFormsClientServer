
using Microsoft.EntityFrameworkCore;
using WinFormsServer.Entities;

namespace WinFormsServer.MyDbContext
{
    public class DbStreets:DbContext
    {
       public DbSet<MyIndex> Mies { get; set; }
       public DbSet<Street> Streets { get; set; }
        public DbStreets()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                           Database=Streets.db;Trusted_Connection=True;");
        }
    }
}
