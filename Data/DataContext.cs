using Microsoft.EntityFrameworkCore;
using QueryTypes.Models;

namespace QueryTypes.Data {

    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<People> People { get; set; }
        public DbSet<BestGame> BestGames { get; set; }
    }

}