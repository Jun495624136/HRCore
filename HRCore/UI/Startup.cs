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
            services.AddTransient<UsersIDAO, UsersDAO>();
            services.AddTransient<UsersIBLL, UsersBLL>();
            services.AddTransient<JueSeIDAO, JueSeDAO>();
            services.AddTransient<JueSeIBLL, JueSeBLL>();
            services.AddTransient<config_file_third_kindIDAO, config_file_third_kindDAO>();
            services.AddTransient<config_file_third_kindIBLL, config_file_third_kindBLL>();
            services.AddTransient<Config_file_second_kindIDAO, Config_file_second_kindDAO>();
            services.AddTransient<Config_file_second_kindIBLL, Config_file_second_kindBLL>();
            services.AddTransient<Config_file_first_kindIDAO, Config_file_first_kindDAO>();
            services.AddTransient<Config_file_first_kindIBLL, Config_file_first_kindBLL>();
            services.AddTransient<Human_fileIDAO, Human_fileDAO>();
            services.AddTransient<Human_fileIBLL, Human_fileBLL>();
            services.AddTransient<config_major_kindIDAO, config_major_kindDAO>();
            services.AddTransient<config_major_kindIBLL, config_major_kindBLL>();
            services.AddTransient<Config_majorIDAO, Config_majorDAO>();
            services.AddTransient<Config_majorIBLL, Config_majorBLL>();
            services.AddTransient<Salary_standardModelIDAO, Salary_standardModeDAO>();
            services.AddTransient<Salary_standardModelIBLL, Salary_standardModeBLL>();
            services.AddTransient<Major_changeIDAO, Major_changeDAO>();
            services.AddTransient<Major_changeIBLL, Major_changeBLL>();
            services.AddTransient<YHquanxianIDAO, YHquanxianDAO>();
            services.AddTransient<YHquanxianIBLL, YHquanxianBLL>();
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
