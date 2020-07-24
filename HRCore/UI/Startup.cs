using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using EFEntity;
using IBLL;
using IDAO;
using BLL;
using DAO;

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
            services.AddControllersWithViews();
            var conStr = configuration.GetConnectionString("SqlServerConnection");
            services.AddTransient<IUsersBLL, UsersBLL>();
            services.AddTransient<IUsersDAO, UsersDAO>();

            services.AddTransient<IConfig_file_first_kindBLL, Config_file_first_kindBLL>();
            services.AddTransient<IConfig_file_first_kindDAO, Config_file_first_kindDAO>();

            services.AddTransient<IConfig_file_second_kindBLL, Config_file_second_kindBLL>();
            services.AddTransient<IConfig_file_second_kindDAO, Config_file_second_kindDAO>();

            services.AddTransient<IConfig_file_third_kindBLL, Config_file_third_kindBLL>();
            services.AddTransient<IConfig_file_third_kindDAO, Config_file_third_kindDAO>();

            services.AddTransient<IConfig_major_kindBLL, Config_major_kindBLL>();
            services.AddTransient<IConfig_major_kindDAO, Config_major_kindDAO>();

            services.AddTransient<IConfig_majorBLL, Config_majorBLL>();
            services.AddTransient<IConfig_majorDAO, Config_majorDAO>();

            services.AddTransient<IEngage_major_releaseBLL, Engage_major_releaseBLL>();
            services.AddTransient<IEngage_major_releaseDAO, Engage_major_releaseDAO>();

            services.AddTransient<IConfig_public_charBLL, Config_public_charBLL>();
            services.AddTransient<IConfig_public_charDAO, Config_public_charDAO>();

            services.AddTransient<IEngage_resumeBLL, Engage_resumeBLL>();
            services.AddTransient<IEngage_resumeDAO, Engage_resumeDAO>();

            services.AddTransient<IEngage_interviewBLL, Engage_interviewBLL>();
            services.AddTransient<IEngage_interviewDAO, Engage_interviewDAO>();

            services.AddTransient<IHuman_fileBLL, Human_fileBLL>();
            services.AddTransient<IHuman_fileDAO, Human_fileDAO>();
            services.AddDistributedMemoryCache().AddSession();
            services.AddDbContext<HR_DBContext>();
            services.AddSession();

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
                //});,
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=left}/{id?}");
            });
       
        }
    }
}
