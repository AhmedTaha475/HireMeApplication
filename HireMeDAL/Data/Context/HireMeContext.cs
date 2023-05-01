using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class HireMeContext:IdentityDbContext
    {
        public HireMeContext(DbContextOptions<HireMeContext> options) : base(options)
        {

        }   
        public DbSet<SystemUser> systemUsers { get; set; }
        public DbSet<Freelancer> freelancers { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Portfolio> portfolios { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<LookupTable> lookupTables { get; set; }
        public DbSet<LookupValue> lookupValues { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectImage> projectImages { get; set; }
        public DbSet<ProjectReview> projectReviews { get; set; }
        public DbSet<ProjectPost> projectPosts { get; set; }
        public DbSet<Milestone> milestones { get; set; }
        public DbSet<ProjectPostApplicant> projectPostApplicants { get; set; }
        public DbSet<ProjectComment> projectComments { get; set; }
        public DbSet<Offer> offers { get; set; }

        public DbSet<Plan> plans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjectPostApplicant>().HasKey(pp => new { pp.PP_ID, pp.FreelancerId });

            builder.Entity<SystemUser>()
                .HasOne(s => s.LookupValue)
                .WithMany(s => s.SystemUsers)
                .HasForeignKey(s => s.CategoryId);

            builder.Entity<SystemUser>()
                .HasOne(s => s.LookupValue)
                .WithMany(s => s.SystemUsers)
                .HasForeignKey(s => s.PaymentMethodId);
            //consider this solution on any 1:1 relation
            builder.Entity<Project>()
             .HasOne(p => p.ProjectReview)
             .WithOne(p => p.Project)
             .HasForeignKey<ProjectReview>(p => p.ProjectId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProjectPost>()
                .HasMany(p => p.ProjectPostApplicants)
                .WithOne(p => p.ProjectPost)
                .HasForeignKey(p => p.PP_ID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Portfolio>()
                .HasOne(f => f.Freelancer)
                .WithOne(p => p.Portfolio)
                .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<ProjectReview>()
                .HasOne(p => p.Freelancer)
                .WithMany(r => r.ProjectReviews)
                .HasForeignKey(r=>r.FreeLancerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
