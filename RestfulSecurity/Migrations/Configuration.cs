namespace RestfulSecurity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RestfulSecurity.Models;
    using RestfulSecurity.Database;
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            context.Patients.AddOrUpdate(x => x.Id,
                    new Patient() { Id = 1, Title = "Miss", FirstName = "Merry", LastName = "Green", Age = 29, NumberOfEmbryos = 3 },
                    new Patient() { Id = 2, Title = "Ms", FirstName = "Jenny", LastName = "Smith", Age = 31, NumberOfEmbryos = 2 },
                    new Patient() { Id = 3, Title = "Mrs", FirstName = "Jennifer", LastName = "Bond", Age = 26, NumberOfEmbryos = 1 },
                    new Patient() { Id = 4, Title = "Ms", FirstName = "Felicity", LastName = "Mackenzie", Age = 34, NumberOfEmbryos = 2 },
                    new Patient() { Id = 5, Title = "Dr", FirstName = "Hannah", LastName = "Nash", Age = 30, NumberOfEmbryos = 1 },
                    new Patient() { Id = 6, Title = "Mrs", FirstName = "Abigail", LastName = "Hudson", Age = 35, NumberOfEmbryos = 3 },
                    new Patient() { Id = 7, Title = "Ms", FirstName = "Ava", LastName = "Avery", Age = 33, NumberOfEmbryos = 2 },
                    new Patient() { Id = 8, Title = "Ms", FirstName = "Uma", LastName = "Lyman", Age = 36, NumberOfEmbryos = 1 },
                    new Patient() { Id = 9, Title = "Dr", FirstName = "Karen", LastName = "Sharp", Age = 27, NumberOfEmbryos = 3 },
                    new Patient() { Id = 10, Title = "Ms", FirstName = "Bella", LastName = "Jones", Age = 28, NumberOfEmbryos = 1 },
                    new Patient() { Id = 11, Title = "Mrs", FirstName = "Virginia", LastName = "Gibson", Age = 30, NumberOfEmbryos = 2 },
                    new Patient() { Id = 12, Title = "Miss", FirstName = "Amanda", LastName = "Abraham", Age = 30, NumberOfEmbryos = 1 }
            );

            context.Files.AddOrUpdate(x => x.Id,
                new File() { Id = 1, FileName = "R0155SLD754_140.png", PatientID = 2 },
                new File() { Id = 2, FileName = "R0155SLD754_141.png", PatientID = 1 },
                new File() { Id = 3, FileName = "R0155SLD754_142.png", PatientID = 2 },
                new File() { Id = 4, FileName = "R0155SLD754_143.png", PatientID = 3 },
                new File() { Id = 5, FileName = "R0155SLD754_144.png", PatientID = 1 },
                new File() { Id = 6, FileName = "R0155SLD754_145.png", PatientID = 1 },
                new File() { Id = 7, FileName = "R0155SLD754_146.png", PatientID = 5 },
                new File() { Id = 8, FileName = "R0155SLD754_147.png", PatientID = 2 },
                new File() { Id = 9, FileName = "R0155SLD754_148.png", PatientID = 1 },
                new File() { Id = 10, FileName = "R0155SLD754_149.png", PatientID = 12 },
                new File() { Id = 11, FileName = "R0155SLD754_150.png", PatientID = 6 },
                new File() { Id = 11, FileName = "R0155SLD754_110.png", PatientID = 8 },
                new File() { Id = 12, FileName = "R0155SLD754_111.png", PatientID = 10 },
                new File() { Id = 13, FileName = "R0155SLD754_112.png", PatientID = 2 },
                new File() { Id = 14, FileName = "R0155SLD754_113.png", PatientID = 9 },
                new File() { Id = 15, FileName = "R0155SLD754_114.png", PatientID = 1 },
                new File() { Id = 16, FileName = "R0155SLD754_115.png", PatientID = 1 },
                new File() { Id = 17, FileName = "R0155SLD754_116.png", PatientID = 3 },
                new File() { Id = 18, FileName = "R0155SLD754_117.png", PatientID = 9 },
                new File() { Id = 19, FileName = "R0155SLD754_118.png", PatientID = 1 },
                new File() { Id = 20, FileName = "R0155SLD754_119.png", PatientID = 3 },
                new File() { Id = 21, FileName = "R0155SLD754_120.png", PatientID = 8 },
                new File() { Id = 22, FileName = "R0155SLD754_121.png", PatientID = 1 }
            );
        }
    }
}
