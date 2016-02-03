using RestfulSecurity.Models;
using System.Data.Entity;

namespace RestfulSecurity.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<File> Files { get; set; }
    }
}