using AppService.Services;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_NetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddDbContext<TanitaTrackerDbContext>(options => options.UseSqlite("Data Source=../DatabaseMigration/TanitaTrackerDb.db"), ServiceLifetime.Singleton);
            services.AddSingleton<ITanitaTrackerDatabase, TanitaTrackerDatabase>();

            services.AddScoped<IUserService, UserService>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddNToastNotifyToastr(new ToastrOptions()
                {
                    CloseButton = true,
                    NewestOnTop = true,
                    ProgressBar = true,
                    PositionClass = ToastPositions.TopRight,
                    ShowDuration = 300,
                    HideDuration = 1000,
                    TimeOut = 5000,
                    ExtendedTimeOut = 1000,
                    ShowEasing = "swing",
                    HideEasing = "linear",
                    ShowMethod = "fadeIn",
                    HideMethod = "fadeOut"
                });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseNToastNotify();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}