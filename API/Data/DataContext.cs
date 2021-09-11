using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base (options)
        { }

        public DbSet<Email> Emails { get; set; }
        public DbSet<ToEmail> ToEmails { get; set; }
    }
}