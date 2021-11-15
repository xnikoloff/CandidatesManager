using CandidatesManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Candidate>().HasIndex(c => c.Number).IsUnique();
        }
    }
}
