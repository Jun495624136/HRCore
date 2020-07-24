using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EFEntity;
using IBLL;
using DAO;
using IDAO;
using BLL;

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
            services.AddTransient<ISalary_grant_detailsBLL, Salary_grant_detailsBLL>();
            services.AddTransient<ISalary_grant_detailsDAO, Salary_grant_detailsDAO>();

            services.AddTransient<ISalary_grantBLL, Salary_grantBLL>();
            services.AddTransient<ISalary_grantDAO, Salary_grantDAO>();

            services.AddTransient<ISalary_standard_BLL, Salary_standard_BLL>();
            services.AddTransient<ISalary_standard_DAO, Salary_standard_DAO>();

            services.AddTransient<ISalary_standard_details_BLL, Salary_standard_details_BLL>();
            services.AddTransient<ISalary_standard_details_DAO, Salary_standard_details_DAO>();

            services.AddTransient<IConfig_public_charBLL, Config_public_charBLL>();
            services.AddTransient<IConfig_public_charDAO, Config_public_charDAO>();

            services.AddTransient<IUsers_BLL, Users_BLL>();
            services.AddTransient<IUsers_DAO, Users_DAO>();
            services.AddControllersWithViews();
            //读取连接字符串
            var conStr = configuration.GetConnectionString("SqlServerConnection");
            services.AddDistributedMemoryCache().AddSession();
            services.AddDbContext<HR_DBContext>();

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
                    pattern: "{controller=Users}/{action=Login}/{id?}");
            });
        }
    }
}
