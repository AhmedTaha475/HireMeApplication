using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public DbSet<ProjectPostApplicantRepo> projectPostApplicants { get; set; }

        public DbSet<Plan> plans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjectPostApplicantRepo>().HasKey(pp => new { pp.PP_ID, pp.FreelancerId });

            builder.Entity<SystemUser>()
                .HasOne(s => s.LookupValue)
                .WithMany(s => s.SystemUsers)
                .HasForeignKey(s => s.CategoryId);

            builder.Entity<SystemUser>()
                .HasOne(s => s.LookupValue)
                .WithMany(s => s.SystemUsers)
                .HasForeignKey(s => s.PaymentMethodId);

            //builder.Entity<SystemUser>()
            //    .HasOne(s => s.LookupValue)
            //    .WithMany(s => s.SystemUsers)
            //    .HasForeignKey(s => s.PlanId);



            builder.Entity<Project>()
                .HasOne(p => p.Portfolio)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.PortfolioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
             .HasMany(p=>p.ProjectImages)
             .WithOne(p=>p.Project)
             .HasForeignKey(p => p.ProjectId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
             .HasOne(p=>p.ProjectReview)
             .WithOne(p => p.Project)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProjectPost>()
                .HasOne(p => p.LookupValue)
                .WithMany(s => s.ProjectPosts)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProjectPost>()
                .HasMany(p=>p.Milestones)
                .WithOne(p=>p.ProjectPost)
                .HasForeignKey(p=>p.ProjectPostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProjectPost>()
                .HasMany(p=>p.ProjectPostApplicants)
                .WithOne(p=>p.ProjectPost)
                .HasForeignKey(p=>p.PP_ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProjectPost>()
                .HasOne(c => c.Client)
                .WithMany(p => p.ProjectPosts)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Portfolio>()
                .HasOne(f => f.Freelancer)
                .WithOne(p => p.Portfolio)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
