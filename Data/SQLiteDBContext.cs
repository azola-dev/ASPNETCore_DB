using ASPNETCore_DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore_DB.Data
{
    public class SQLiteDBContext : /*Identity*/DbContext
    {
        public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options) : base(options)
        {        
                
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");

        }
    }
}
