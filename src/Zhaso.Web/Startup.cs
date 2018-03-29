using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zhaso.Data;
using Zhaso.Interfaces;
using Zhaso.Repositories;
using Zhaso.Services;
using Zhaso.Web.Models;

namespace Zhaso.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ZhasoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ZhasoContext")));
            services.Configure<SiteSettings>(this.Configuration.GetSection("SiteSettings"));
            services.AddTransient<DbContext, ZhasoContext>();
            services.AddTransient(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddTransient(typeof(IService<>), typeof(ServiceBase<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPermissionService, PermissionService>();

            services.AddMvc().AddJsonOptions(o =>
            {
                o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ZhasoContext>();
                    Zhaso.Entities.SeedData.Initialize(context);
                    // rest of your code
                }
            }
            catch (Exception ex)
            {

            }

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
