using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FirstWebApi.Lesson.Database
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> opts):base(opts)
        {
        }
        public UniversityContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BlogDbContextDatabase"].ConnectionString);
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=UniversityDb; User id = sa ; password = Pass@word01;Trusted_Connection=False");
        }

        public DbSet<Corso> Corso { get; set; }
        public DbSet<Studente> Studente { get; set; }
    }
    public class Studente
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DatePublished { get; set; }
        public virtual Corso? Corso { get; set; }
    }
    public class Corso
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DatePublished { get; set; }
        public virtual List<Studente>? Students { get; set; }
    }
}
