using DayCareMvc.Interfaces;
using DayCareMvc.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCareMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Get values from App settings nice.
            var dataValue = Configuration["AppSettings:Version"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Custom added.
            services.AddDistributedMemoryCache();

          
            // Custom added.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.Cookie.Name = "MyCookie";
                o.SlidingExpiration = true;
                o.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                o.LoginPath = "/login";
                o.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                //o.ReturnUrlParameter = "returnUrl";
                o.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
                o.LogoutPath = "/logout";
                o.Cookie.HttpOnly = true;
                //o.Cookie.MaxAge = TimeSpan.FromMinutes(15);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

           // services.AddControllers()
           //.AddNewtonsoftJson(options =>
           //{
           //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
           //});

            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        ctx.Response.Redirect("/login");
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("https://localhost:44369/").AllowCredentials());
            });

            // Custom added.
            services.AddMvc(options =>
            {
                options.Filters.Add(
                new AutoValidateAntiforgeryTokenAttribute());
            });

            // My Custom services.
            services.Add(new ServiceDescriptor(typeof(IMoviesRepository), new MoviesRepository()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Custom added.
            app.UseSession();

            // Custom added.
            app.UseCors();    // Enable CORS
            app.UseCors(builder => builder.AllowAnyOrigin());

            // Custom added.
            app.UseCookiePolicy();

            // Custom added.
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
