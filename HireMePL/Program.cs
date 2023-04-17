

using HireMeBLL.Managers.ProjectsManager;

using HireMeBLL;

using HireMeDAL;
using HireMeDAL.Repos;
using HireMeDAL.Repos.Projects;
using HireMeDAL.Repos.ProjectsImages;
using HireMeDAL.Repos.ProjectsReview;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HireMePL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region DI Middleware
            builder.Services.AddScoped<ISystemUserRepo, SystemUserRepo>();
            builder.Services.AddScoped<ISystemUserManager, SystemUserManager>();
            builder.Services.AddScoped<IFreelancerRepo, FreelancerRepo>();
            builder.Services.AddScoped<IFreelancerManager, FreelancerManager>();
            builder.Services.AddScoped<IClientRepo, ClientRepo>();

            builder.Services.AddScoped<IProjectsRepo, ProjectsRepo>();
            builder.Services.AddScoped<IProjectsReviewRepo, ProjectsReviewRepo>();
            builder.Services.AddScoped<IProjectImagesRepo, ProjectImagesRepo>();
            builder.Services.AddScoped<IProjectCommentsRepo, ProjectCommentsRepo>();
            builder.Services.AddScoped<IProjectsManager, ProjectsManager>();







            builder.Services.AddScoped<IClientManager, ClientManager>();
            #endregion

            #region defaults
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Cors
            var corsPolicy = "AllowAll";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy, p => p
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            #endregion

            #region Database
            builder.Services.AddDbContext<HireMeContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HireMeCon"))
            );
            #endregion

            #region AddIdentity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<HireMeContext>();
            #endregion

            #region Add Authentication

            builder.Services.AddAuthentication(options =>
            {
                //Used Authentication Scheme
                options.DefaultAuthenticateScheme = "HireMeScheme";

                //Used Challenge Authentication Scheme
                options.DefaultChallengeScheme = "HireMeScheme";
            })
            .AddJwtBearer("HireMeScheme", options =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            #endregion

            #region Add Authorization
            //Check Later
            builder.Services.AddAuthorization();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}