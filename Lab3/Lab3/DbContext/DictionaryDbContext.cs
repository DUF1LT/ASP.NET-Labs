using System.Data.Entity;
using Lab3.Models;

namespace Lab3.DbContext
{
    public class DictionaryDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Record> Records { get; set; }

        public DictionaryDbContext() : base("DefaultConnection")
        {

        }
    }
}