using FooYes.DAL;
using FooYes.Models;
using FooYes.Services;
using GodDamnEduHome.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<LayoutService>();
            services.AddScoped<IEmailService, EmailService>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/account/login";
                opt.AccessDeniedPath = "/manage/account/login";
            });
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(async (context, next) =>
            {
                await next.Invoke();

                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    context.Response.Redirect("/error/notfound");
                }
            });

            app.UseRouting();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                    endpoints.MapControllerRoute(
                     "default",
                     "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
