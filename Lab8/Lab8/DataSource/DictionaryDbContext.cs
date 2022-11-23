using Lab8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Lab8.DataSource;

public class DictionaryDbContext : DbContext
{
    public DbSet<Record> Records { get; set; }

    public DictionaryDbContext(DbContextOptions options) : base(options)
    {

    }
}