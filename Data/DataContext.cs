using Microsoft.EntityFrameworkCore;
using Teams.API.Model;

namespace Teams.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Projects> Projects { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Items> Items { get; set; }

        public DbSet<Users> Users { get; set;}

        public DbSet<TeamProjects> TeamProjects { get; set; }
    }
}