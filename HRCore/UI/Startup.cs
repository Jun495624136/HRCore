using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAO;
using EFEntity;
using IBLL;
using IDAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.AddControllersWithViews();
            services.AddTransient<UsersIDAO3, UsersDAO3>();
            services.AddTransient<UsersIBLL3, UsersBLL3>();
            services.AddTransient<JueSeIDAO3, JueSeDAO3>();
            services.AddTransient<JueSeIBLL3, JueSeBLL3>();
            services.AddTransient<config_file_third_kindIDAO3, config_file_third_kindDAO3>();
            services.AddTransient<config_file_third_kindIBLL3, config_file_third_kindBLL3>();
            services.AddTransient<Config_file_second_kindIDAO3, Config_file_second_kindDAO3>();
            services.AddTransient<Config_file_second_kindIBLL3, Config_file_second_kindBLL3>();
            services.AddTransient<Config_file_first_kindIDAO3, Config_file_first_kindDAO3>();
            services.AddTransient<Config_file_first_kindIBLL3, Config_file_first_kindBLL3>();
            services.AddTransient<Human_fileIDAO3, Human_fileDAO3>();
            services.AddTransient<Human_fileIBLL3, Human_fileBLL3>();
            services.AddTransient<config_major_kindIDAO3, config_major_kindDAO3>();
            services.AddTransient<config_major_kindIBLL3, config_major_kindBLL3>();
            services.AddTransient<Config_majorIDAO3, Config_majorDAO3>();
            services.AddTransient<Config_majorIBLL3, Config_majorBLL3>();
            services.AddTransient<Salary_standardModelIDAO3, Salary_standardModeDAO>();
            services.AddTransient<Salary_standardModelIBLL3, Salary_standardModeBLL3>();
            services.AddTransient<Major_changeIDAO, Major_changeDAO3>();
            services.AddTransient<Major_changeIBLL3, Major_changeBLL3>();
            services.AddTransient<YHquanxianIDAO3, YHquanxianDAO3>();
            services.AddTransient<YHquanxianIBLL3, YHquanxianBLL3>();
            //读取连接字符串
            var conStr = configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<HR_DBContext>();
            services.AddDistributedMemoryCache().AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();//加载静态文件的组件
            app.UseRouting();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Usere}/{action=Index}/{id?}");
            });
        }
    }
}
