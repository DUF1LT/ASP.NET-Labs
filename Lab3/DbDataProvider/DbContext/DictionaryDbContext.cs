using System.Data.Entity;
using Models.Models;

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