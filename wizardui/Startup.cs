using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using wizarddata.Data;
using wizardrepository.DependencyInjection;


namespace wizardui
{
    public class Startup
    {

        IWebHostEnvironment Environment{ get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            if(Environment.IsDevelopment())
            {
                //add database and add UnitOfWork using Wizard Context
                services.AddDbContext<WizardContext>(options => 
                    options.UseSqlite(Configuration.GetConnectionString("WizardContextLocal")))
                        .AddUnitOfWork<WizardContext>();
            }
            if(Environment.IsProduction()){
                //add database and add UnitOfWork using Wizard Context
                services.AddDbContext<WizardContext>(
                    options => options.UseMySql(Configuration.GetConnectionString("WizardContectDeploy"),
                                                mySqlOptions => mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)
                    )).AddUnitOfWork<WizardContext>();
                
                // services.AddDbContext<WizardContext>(options => 
                //     options.UseSqlite(Configuration.GetConnectionString("WizardContectDeploy")))
                //         .AddUnitOfWork<WizardContext>();                
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //get the database to migrate/update
            using(var servicescope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                servicescope.ServiceProvider.GetService<WizardContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //this can cause headaches when testing locally.
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
