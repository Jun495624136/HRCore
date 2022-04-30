using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EFEntity;
using IDAO;
using DAO;
using BLL;
using IBLL;
namespace WebApi
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
            services.AddTransient<IConfig_public_charBLL, Config_public_charBLL>();
            services.AddTransient<IConfig_public_charDAO, Config_public_charDAO>();

            services.AddTransient<IUsers_BLL, Users_BLL>();
            services.AddTransient<IUsers_DAO, Users_DAO>();
            //¶ÁÈ¡Á¬½Ó×Ö·û´®
            var conStr = configuration.GetConnectionString("SqlServerConnection");
            services.AddControllers();
            services.AddTransient<IUsersBLL1, UsersBLL1>();
            services.AddTransient<IUsersDAO1, UsersDAO1>();
            services.AddDistributedMemoryCache().AddSession();
            services.AddDbContext<HR_DBContext>();
            services.AddDistributedMemoryCache().AddSession();
            //¿çÓò
            services.AddCors(option => option.AddPolicy("AllowCors", bu => bu.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            //×¢ÈëSession
            app.UseSession();
            //¿çÓò
            app.UseCors("AllowCors");
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
