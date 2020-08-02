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
using MieiCorsi.Models.Services.Application;
using MieiCorsi.Models.Services.Infrastructure;

namespace MieiCorsi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            // code omitted for brevity

            services.AddTransient<ICourseService, EfCoreCourseService>();
            // Abilita ASP.Net Core a creare un'istanza di CourseService ogni volta che viene usata nel controller
            //in Questo modo però l'stanza è ancora fortemente accoppiato al tipo "CourseService" 
            //services.AddTransient<IDatabaseAccessor, SqlDatabaseAccessor>();
            //services.AddScoped<MieiCorsiDbContext>();
           // services.AddDbContext<MieiCorsiDbContext>();
            services.AddDbContextPool<MieiCorsiDbContext>(optionsBuilder =>
            {
                //string connectionString = Configuration.GetConnectionString("Default"); // con il metodo GetConnection si riesce ugualmente a recuperare la connectionstring.
                String connectionString = Configuration.GetSection("ConnectionStrings").GetValue<String>("Default");
                optionsBuilder.UseSqlServer(connectionString);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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

            //app.UseEndpoints(endpoints =>
            //{

            //   endpoints.MapControllerRoute(

            

            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
