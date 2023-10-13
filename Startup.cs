using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendMailApi.Services;
using SendMailApi.Settings;

namespace SendMailApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => options.AddPolicy("AllowCors",
               builder =>
               {
                   builder
                       .AllowAnyOrigin()
                       .WithMethods("GET", "PUT", "POST", "DELETE")
                       .AllowAnyHeader();
               }));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    builder => builder.WithOrigins("http://localhost:5188", "http://127.0.0.1:5500")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod());
            });
            services.AddControllers();

            // Configure MailSettings
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            // Register MailService
            services.AddScoped<IMailService, MailService>();



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowLocalhost");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();

        //    // Configure MailSettings
        //    services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

        //    // Register MailService
        //    services.AddScoped<IMailService, MailService>();
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowLocalhost",
        //            builder => builder.WithOrigins("http://localhost:5188")
        //                               .AllowAnyHeader()
        //                               .AllowAnyMethod());
        //    });
        //}

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        app.UseHsts();
        //    }

        //    app.UseHttpsRedirection();
        //    app.UseRouting();
        //    app.UseCors("AllowLocalhost");
        //    // Other middleware configurations
        //}
    }
}
