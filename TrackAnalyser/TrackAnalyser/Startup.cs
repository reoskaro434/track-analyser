using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrackAnalyser.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackAnalyser.DataAccess.RepositoryPattern;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TrackAnalyser.Utilities.SortStrategyPatternForEmission;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Utilities.SortStrategy;
using TrackAnalyser.Utilities.BroadcastFilter;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Utilities.ExcelSheet;
using TrackAnalyser.Utilities.Rank;
using TrackAnalyser.Utilities.Charts.BarChart;
using TrackAnalyser.Utilities.Charts.PieChart;
using TrackAnalyser.Utilities.DataInitializer;
using TrackAnalyser.Utilities.EmailSender;

namespace TrackAnalyser
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            //options.LoginPath = "/Login/Index"
             options.AccessDeniedPath = "/Authentication/AccessDenied"
                
            
            ); 

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddTransient<ISortStrategyContext<BroadcastListViewModel>, SortStrategyContext>();
            services.AddTransient<IBroadcastFilter<BroadcastListViewModel, IUnitOfWork>, BroadcastFilter>();
            services.AddTransient<IExcelSheetCreator<BroadcastListViewModel>, ExcelSheetCreator>();
            services.AddTransient<IExcelSheetConverter, ExcelSheetConverter>();
            services.AddTransient<IRank<RankViewModel,IUnitOfWork>, Rank>();
            services.AddTransient<IBarChart<IUnitOfWork>, BarChart>();
            services.AddTransient<IPieChart<IUnitOfWork>, PieChart>();
            services.AddTransient<IDataInitializer<IUnitOfWork>, DataInitializer>();
            services.AddTransient<IEmailSender, EmailSender>();
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
               // app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
