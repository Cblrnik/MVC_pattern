using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace MVC1
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TestContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                            {
                                endpoints.MapControllerRoute(
                                  name: "default",
                                  pattern: "{controller=Home}/{action=StartPage}/{id?}");
                            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("404 | Page is not Found");
            });
        }
    }
}
