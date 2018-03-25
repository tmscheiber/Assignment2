using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group1_Assn4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Group1_Assn4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration["Data:LinqQueries:ConnectionString"]));
            services.AddTransient<IClientRepository, EFClientRepository>();
            services.AddTransient<IProjectRepository, EFProjectRepository>();
            services.AddTransient<IResourceRepository, EFResourceRepository>();
            services.AddTransient<IProjectResourceRepository, EFProjectResourceRepository>();
            services.AddMvc();
        }// end ConfigureServices

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseStatusCodePages();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                }
                app.UseStaticFiles();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                    //routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
                });


                //ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
                //context.Clients.RemoveRange(context.Clients);
                //context.Resources.RemoveRange(context.Resources);
                //context.Projects.RemoveRange(context.Projects);
                //context.ProjectResources.RemoveRange(context.ProjectResources);
                //context.Database.Migrate();
                //ClientSeedData.EnsurePopulated(app);
                //ResourceSeedData.EnsurePopulated(app);
                //ProjectSeedData.EnsurePopulated(app);
                //ProjectResourceSeedData.EnsurePopulated(app);

            }//end if
        }// end Configure
    }// end class
}// end namespace
