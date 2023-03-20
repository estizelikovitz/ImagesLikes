using Microsoft.EntityFrameworkCore;
using System;

namespace _4_06hmwk
{
    public class DataContext:DbContext
    {

        private string _connectionString;

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Image> Images { get; set; }
    }

}
