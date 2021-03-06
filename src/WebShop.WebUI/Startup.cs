using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Diagnostics;
using System.Reflection;
using WebShop.Application.Authentication.Command;
using WebShop.Application.Common.Handlers;
using WebShop.Application.Common.Requirement;
using WebShop.Application.Models.Login;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;
using WebShop.Domain.Services;
using WebShop.Infrastructure;
using WebShop.Infrastructure.Services;

namespace WebShop.WebUI
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
            services.AddDbContext<WebShopDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddSingleton<WebShopDbContextFactory>(new WebShopDbContextFactory(Configuration.GetConnectionString("SqlConnection")));

            services.AddRazorPages();

            services.AddSingleton<IAuthorizationHandler, SelectedRoleHandler>();



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie();

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<WebShopDbContext>();

            services.AddMediatR(typeof(LoginCommand).GetTypeInfo().Assembly);
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<LoginModel>();
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IPasswordHasher,PasswordHasher>();

            services.AddMvc().AddRazorPagesOptions(options =>
            options.Conventions.AddPageRoute("/LoginPage/LoginPage", ""));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }
    }
}
