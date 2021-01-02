using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NutraZone.Data;
using NutraZone.Models;
using ShoeDesignz.Data;
using ShoeDesignz.Models;

namespace NutraZone
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration configuration
        {
            //Configuration = configuration;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<NutraZoneIdentityContext>()
                   .AddDefaultTokenProviders();
            /*Local Strings*/
            services.AddDbContext<NutraZoneIdentityContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:LocalUserConnection"]));

            services.AddDbContext<NutraZoneDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddAuthorization(options =>
            {               
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
            }); 

            services.AddScoped<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Landing}/{id?}");
            });
        }
    }
}
