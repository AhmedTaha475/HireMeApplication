﻿// <auto-generated />
using System;
using HireMeDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HireMeDAL.Migrations
{
    [DbContext(typeof(HireMeContext))]
    [Migration("20230508131218_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HireMeDAL.LookupTable", b =>
                {
                    b.Property<int>("LookupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookupId"));

                    b.Property<string>("LookupName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("LookupId");

                    b.ToTable("lookupTables");
                });

            modelBuilder.Entity("HireMeDAL.LookupValue", b =>
                {
                    b.Property<int>("ValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ValueId"));

                    b.Property<int>("LookupId")
                        .HasColumnType("int");

                    b.Property<string>("ValueName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ValueId");

                    b.HasIndex("LookupId");

                    b.ToTable("lookupValues");
                });

            modelBuilder.Entity("HireMeDAL.Milestone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectPostId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPostId");

                    b.ToTable("milestones");
                });

            modelBuilder.Entity("HireMeDAL.Offer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("Accepted")
                        .HasColumnType("bit");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreelancerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OfferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("FreelancerId");

                    b.ToTable("offers");
                });

            modelBuilder.Entity("HireMeDAL.Plan", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Bids")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("id");

                    b.ToTable("plans");
                });

            modelBuilder.Entity("HireMeDAL.Portfolio", b =>
                {
                    b.Property<int>("PortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortId"));

                    b.Property<string>("FreelancerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PortId");

                    b.HasIndex("FreelancerId")
                        .IsUnique();

                    b.ToTable("portfolios");
                });

            modelBuilder.Entity("HireMeDAL.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectID"));

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("MoneyEarned")
                        .HasColumnType("money");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProjectDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("SystemProject")
                        .HasColumnType("bit");

                    b.HasKey("ProjectID");

                    b.HasIndex("ClientId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("HireMeDAL.ProjectComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectId");

                    b.ToTable("projectComments");
                });

            modelBuilder.Entity("HireMeDAL.ProjectImage", b =>
                {
                    b.Property<int>("PI_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PI_Id"));

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("PI_Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("projectImages");
                });

            modelBuilder.Entity("HireMeDAL.ProjectPost", b =>
                {
                    b.Property<int>("Pp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pp_Id"));

                    b.Property<decimal>("AveragePrice")
                        .HasColumnType("money");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProjectPostDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("approved")
                        .HasColumnType("bit");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pp_Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("projectPosts");
                });

            modelBuilder.Entity("HireMeDAL.ProjectPostApplicant", b =>
                {
                    b.Property<int>("PP_ID")
                        .HasColumnType("int");

                    b.Property<string>("FreelancerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<decimal>("BiddingPrice")
                        .HasColumnType("money");

                    b.Property<string>("Proposal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PP_ID", "FreelancerId");

                    b.HasIndex("FreelancerId");

                    b.ToTable("projectPostApplicants");
                });

            modelBuilder.Entity("HireMeDAL.ProjectReview", b =>
                {
                    b.Property<int>("PR_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PR_Id"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientReview")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("ClientStars")
                        .HasColumnType("int");

                    b.Property<string>("FreeLancerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FreelancerReview")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("FreelancerStars")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("PR_Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FreeLancerId");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("projectReviews");
                });

            modelBuilder.Entity("HireMeDAL.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SystemUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TransactionId");

                    b.HasIndex("SystemUserId");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HireMeDAL.SystemUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("money");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("PlanId");

                    b.HasDiscriminator().HasValue("SystemUser");
                });

            modelBuilder.Entity("HireMeDAL.Client", b =>
                {
                    b.HasBaseType("HireMeDAL.SystemUser");

                    b.Property<decimal>("TotalMoneySpent")
                        .HasColumnType("money");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("HireMeDAL.Freelancer", b =>
                {
                    b.HasBaseType("HireMeDAL.SystemUser");

                    b.Property<decimal>("AverageRate")
                        .HasColumnType("money");

                    b.Property<int>("Bids")
                        .HasColumnType("int");

                    b.Property<byte[]>("CV")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LookupValueValueId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalMoneyEarned")
                        .HasColumnType("money");

                    b.HasIndex("LookupValueValueId");

                    b.HasDiscriminator().HasValue("Freelancer");
                });

            modelBuilder.Entity("HireMeDAL.LookupValue", b =>
                {
                    b.HasOne("HireMeDAL.LookupTable", "LookupTable")
                        .WithMany("LookupValues")
                        .HasForeignKey("LookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LookupTable");
                });

            modelBuilder.Entity("HireMeDAL.Milestone", b =>
                {
                    b.HasOne("HireMeDAL.ProjectPost", "ProjectPost")
                        .WithMany("Milestones")
                        .HasForeignKey("ProjectPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectPost");
                });

            modelBuilder.Entity("HireMeDAL.Offer", b =>
                {
                    b.HasOne("HireMeDAL.Freelancer", "Freelancer")
                        .WithMany("Offers")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("HireMeDAL.Portfolio", b =>
                {
                    b.HasOne("HireMeDAL.Freelancer", "Freelancer")
                        .WithOne("Portfolio")
                        .HasForeignKey("HireMeDAL.Portfolio", "FreelancerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("HireMeDAL.Project", b =>
                {
                    b.HasOne("HireMeDAL.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId");

                    b.HasOne("HireMeDAL.Portfolio", "Portfolio")
                        .WithMany("Projects")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("HireMeDAL.ProjectComment", b =>
                {
                    b.HasOne("HireMeDAL.Client", "Client")
                        .WithMany("ProjectComments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireMeDAL.Project", "Project")
                        .WithMany("ProjectComments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("HireMeDAL.ProjectImage", b =>
                {
                    b.HasOne("HireMeDAL.Project", "Project")
                        .WithMany("ProjectImages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("HireMeDAL.ProjectPost", b =>
                {
                    b.HasOne("HireMeDAL.LookupValue", "LookupValue")
                        .WithMany("ProjectPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireMeDAL.Client", "Client")
                        .WithMany("ProjectPosts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("LookupValue");
                });

            modelBuilder.Entity("HireMeDAL.ProjectPostApplicant", b =>
                {
                    b.HasOne("HireMeDAL.Freelancer", "Freelancer")
                        .WithMany("ProjectPostApplicants")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireMeDAL.ProjectPost", "ProjectPost")
                        .WithMany("ProjectPostApplicants")
                        .HasForeignKey("PP_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("ProjectPost");
                });

            modelBuilder.Entity("HireMeDAL.ProjectReview", b =>
                {
                    b.HasOne("HireMeDAL.Client", "Client")
                        .WithMany("ProjectReviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireMeDAL.Freelancer", "Freelancer")
                        .WithMany("ProjectReviews")
                        .HasForeignKey("FreeLancerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HireMeDAL.Project", "Project")
                        .WithOne("ProjectReview")
                        .HasForeignKey("HireMeDAL.ProjectReview", "ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Freelancer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("HireMeDAL.Transaction", b =>
                {
                    b.HasOne("HireMeDAL.SystemUser", "SystemUser")
                        .WithMany("Transactions")
                        .HasForeignKey("SystemUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HireMeDAL.SystemUser", b =>
                {
                    b.HasOne("HireMeDAL.LookupValue", "LookupValue")
                        .WithMany("SystemUsers")
                        .HasForeignKey("PaymentMethodId");

                    b.HasOne("HireMeDAL.Plan", "Plan")
                        .WithMany("SystemUsers")
                        .HasForeignKey("PlanId");

                    b.Navigation("LookupValue");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("HireMeDAL.Freelancer", b =>
                {
                    b.HasOne("HireMeDAL.LookupValue", null)
                        .WithMany("Freelancers")
                        .HasForeignKey("LookupValueValueId");
                });

            modelBuilder.Entity("HireMeDAL.LookupTable", b =>
                {
                    b.Navigation("LookupValues");
                });

            modelBuilder.Entity("HireMeDAL.LookupValue", b =>
                {
                    b.Navigation("Freelancers");

                    b.Navigation("ProjectPosts");

                    b.Navigation("SystemUsers");
                });

            modelBuilder.Entity("HireMeDAL.Plan", b =>
                {
                    b.Navigation("SystemUsers");
                });

            modelBuilder.Entity("HireMeDAL.Portfolio", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("HireMeDAL.Project", b =>
                {
                    b.Navigation("ProjectComments");

                    b.Navigation("ProjectImages");

                    b.Navigation("ProjectReview");
                });

            modelBuilder.Entity("HireMeDAL.ProjectPost", b =>
                {
                    b.Navigation("Milestones");

                    b.Navigation("ProjectPostApplicants");
                });

            modelBuilder.Entity("HireMeDAL.SystemUser", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("HireMeDAL.Client", b =>
                {
                    b.Navigation("ProjectComments");

                    b.Navigation("ProjectPosts");

                    b.Navigation("ProjectReviews");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("HireMeDAL.Freelancer", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Portfolio");

                    b.Navigation("ProjectPostApplicants");

                    b.Navigation("ProjectReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
