using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerse.Data;
using ECommerse.Models;
using ECommerse.Models.Handlers;
using ECommerse.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerse
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {

            //var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            //builder.AddUserSecrets<Startup>();

            //for local
            Configuration = configuration;

            //for deploy
            //Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IInventory, DevInventory>();
            services.AddScoped<IBasket, DevBasket>();
            services.AddScoped<IEmailSender, EmailSender>();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("AmandaOnly", policy => policy.Requirements.Add(new NameRequirement("Amanda Iverson")));
                options.AddPolicy("MicrosoftOnly", policy => policy.Requirements.Add(new EmailRequirement("@microsoft.com")));
            });

            services.AddAuthentication().AddGoogle(google =>
            {
                google.ClientId = Configuration["Authentication:Google:ClientId"];
                google.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });

            services.AddAuthentication().AddFacebook(facebook =>
            {
                facebook.AppId = Configuration["Authentication:Facebook:AppId"];
                facebook.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            //local Ben
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalProducts")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalUsers")));

            //local Max
            //  services.AddDbContext<InventoryDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //  services.AddDbContext<ApplicationDbContext>(options =>
            //  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //deployed
            //services.AddDbContext<InventoryDbContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IInventory, DevInventory>();
            services.AddTransient<IBasket, DevBasket>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
