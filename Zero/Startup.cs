using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using Zero.Core.IServices;
using Zero.Infrastructure.Context;
using Zero.Infrastructure.Services;

namespace Zero
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

            services.AddControllers();

            #region Swagger����
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Zero-Management-system",
                    Version = "v1",
                    Description = "Built by Dotnet5",
                    Contact = new OpenApiContact
                    {
                        Name = "Yingfea",
                        Email = "yingfea@gmail.com",
                        Url = new Uri("https://yingfea.top")
                    },
                }); ;
            });
            #endregion

            #region SqlServer����
            //services.AddDbContext<ZeroDBContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            //});
            #endregion

            #region MySql����
            services.AddDbContext<ZeroDBContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version(8, 0, 23)), mySqlOptions =>
                {
                    mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend);
                    mySqlOptions.MigrationsAssembly("Zero");
                }).EnableSensitiveDataLogging(false)
                  .EnableDetailedErrors();
            });
            #endregion

            #region ע�����
            services.AddScoped<IUserServer, UserServer>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zero v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
