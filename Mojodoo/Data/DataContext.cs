using Microsoft.EntityFrameworkCore;

namespace Mojodoo.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                    new Note
                    { 
                        Id = 1, 
                        Todo = "Test", 
                        CreatedDate = new DateTime(2020, 07, 19)
                    }
                );

        }

        public DbSet<Note>Notes { get; set; }
    }
}
