using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ukeess.Models;

namespace Ukeess
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:Ukeess:ConnectionString"]));
            services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
            services.AddTransient<IDepartmentRepository, EFDepartmentRepository>();
            services.AddMvc();
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
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Employees/Page/{employeePage}",
                    defaults: new { Controller = "Employees", action = "Index" }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employees}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
