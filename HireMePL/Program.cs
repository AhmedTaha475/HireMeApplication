using HireMeDAL;
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
            builder.Services.AddIdentity<SystemUser, IdentityRole>().AddEntityFrameworkStores<HireMeContext>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}