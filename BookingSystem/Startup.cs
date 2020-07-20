using System;
using System.Reflection;
using System.Text;
using BookingSystem.AutoMapperConfiguration;
using BookingSystem.Data;
using BookingSystem.Helpers.Auth;
using BookingSystem.Models.Users;
using BookingSystem.Repositories;
using BookingSystem.Repositories.Areas;
using BookingSystem.Repositories.BookingRepository;
using BookingSystem.Repositories.Bookings;
using BookingSystem.Repositories.DoctorsRepository;
using BookingSystem.Repositories.DoctorsRepository.Specializations;
using BookingSystem.Repositories.Patents;
using BookingSystem.Repositories.Regions;
using BookingSystem.Repositories.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BookingSystem
{
    public class Startup
    {

        private const string SecretKey = "signjdhycg6s524376d5sgf354789";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:5001",
                    "https://tachyonblobstorage.z6.web.core.windows.net/"));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();

            // Inject Interfaces and repositories
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IDoctorsRepository, DoctorsRepository>();
            services.AddTransient<IPatentsRepository, PatentsRepository>();
            services.AddTransient<IAreasRepository, AreasRepository>();
            services.AddTransient<IRegionsRepository, RegionsRepository>();
            services.AddTransient<ISpecializationsRepository, SpecializationsRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();

            // Inject Other Services and functions
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Db Context Configuration
            services.AddDbContext<DoctorBookingContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConn"),
                 sqlOptions =>
                 {
                     sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                     //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                     sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                 }));

            //AutoMapper Configuration
            services.AddSingleton(s => AutoMapperFactory.CreateMapper());

            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });


            services.AddDefaultIdentity<Identity>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

            }).AddRoles<IdentityRole>()
           .AddEntityFrameworkStores<DoctorBookingContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            UpdateDatabase(app);

            app.UseMvc();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DoctorBookingContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
