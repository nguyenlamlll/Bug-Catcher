using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BugCatcher.DAL.Implementation.Data;
using BugCatcher.DAL.Models;
using BugCatcher.Infrastructure.Services;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Implementation;
using BugCatcher.DAL.Models.Identity;
using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.DAL.Implementation.Repositories;
using BugCatcher.Web.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using BugCatcher.Web.Middlewares;

namespace BugCatcher.Web
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BugCatcher.DAL.Implementation")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            // ADD REPORT Services
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IReportRepository, ReportRepository>();

            // Add COMPANY Services
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            // Add PRODUCT Services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            // Add BUILD Services
            services.AddTransient<IBuildService, BuildService>();
            services.AddTransient<IBuildRepository, BuildRepository>();

            // Add USER Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICompanyEnrollmentRepository, CompanyEnrollmentRepository>();


            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");

                    options.Conventions.AuthorizeFolder("/Company");

                    options.Conventions.AuthorizeFolder("/Product");

                    options.Conventions.AuthorizeFolder("/Report");
                });

            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
                config.WithExposedHeaders("Location");
            });

            // Setup routes
            app.UseGetRoutesMiddleware(GetRoutes);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            // Start seeding
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                var dbContext2 = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                #region ADD USERS
                var name = "RandomUser";
                var email = "random-user@email.com";
                var password = "!Aa123456789";
                if (!dbContext.Users.Any(user => user.UserName == email))
                {
                    var defaultUser = new ApplicationUser()
                    {
                        UserName = email,
                        Email = email,
                        NormalizedUserName = name.ToUpper(),
                        NormalizedEmail = email.ToUpper(),
                        //PasswordHash = Hasher.GetHashString(password),
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };
                    var result = Task.Run(() => { userManager.CreateAsync(defaultUser, password); });
                    Task.WaitAll(result);
                }

                var name2 = "RandomEmployee";
                var email2 = "employee@email.com";
                var password2 = "!Aa123456789";
                if (!dbContext2.Users.Any(user => user.UserName == email2))
                {
                    var defaultUser = new ApplicationUser()
                    {
                        UserName = email2,
                        Email = email2,
                        NormalizedUserName = name2.ToUpper(),
                        NormalizedEmail = email2.ToUpper(),
                        PasswordHash = Hasher.GetHashString(password2),
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };
                    var result = Task.Run(() => { userManager.CreateAsync(defaultUser, password2); });
                    Task.WaitAll(result);
                }
                #endregion

                #region ADD COMPANIES and EMPLOYEES
                var companyName = "Random Fires Studio";
                if (!dbContext.Companies.Any(com => com.Name == companyName))
                {
                    var user = dbContext.Users.Where(usr => usr.UserName == email).SingleOrDefault();
                    var newCompany = new Company()
                    {
                        Name = companyName
                    };
                    dbContext.Companies.Add(newCompany);
                    dbContext.SaveChanges();
                }

                // Add 2 users into above company.
                var creatorUser = dbContext.Users.Where(usr => usr.UserName == email).SingleOrDefault();
                var addingCompany = dbContext.Companies.Where(com => com.Name == companyName).SingleOrDefault();
                if (!dbContext.CompanyEnrollments.Any
                    (enroll => (enroll.UserId == creatorUser.Id) && (enroll.CompanyId == addingCompany.Id)))
                {
                    // Add company creator
                    dbContext.CompanyEnrollments.Add(new CompanyEnrollment()
                    {
                        CompanyId = addingCompany.Id,
                        UserId = creatorUser.Id,
                        IsCompanyCreator = true
                    });
                }

                var employeeUser = dbContext.Users.Where(usr => usr.UserName == email2).SingleOrDefault();
                if (!dbContext.CompanyEnrollments.Any
                   (enroll => (enroll.UserId == employeeUser.Id) && (enroll.CompanyId == addingCompany.Id)))
                {
                    // Add employee
                    dbContext.CompanyEnrollments.Add(new CompanyEnrollment()
                    {
                        CompanyId = addingCompany.Id,
                        UserId = employeeUser.Id,
                        IsCompanyCreator = false
                    });
                }
                dbContext.SaveChanges();
                #endregion

                #region ADD PRODUCTS
                string productName = "Random Army 2";
                if (!dbContext.Products.Any(prod => prod.Name == productName))
                {
                    var company = dbContext.Companies.Where(com => com.Name == companyName).SingleOrDefault();
                    var product = new Product()
                    {
                        CompanyId = company.Id,
                        Name = productName,
                        Description = "Pure randomness on your computer."
                    };
                    dbContext.Products.Add(product);
                    dbContext.SaveChanges();
                }

                string productName2 = "Action! Fast!";
                if (!dbContext.Products.Any(prod => prod.Name == productName2))
                {
                    var company = dbContext.Companies.Where(com => com.Name == companyName).SingleOrDefault();
                    var product = new Product()
                    {
                        CompanyId = company.Id,
                        Name = productName2,
                        Description = "Run fast. Action faster. Or you will die in five seconds."
                    };
                    dbContext.Products.Add(product);
                    dbContext.SaveChanges();
                }
                #endregion

                #region ADD BUILDS
                List<string> productBuild = new List<string>() { "0.9.0", "0.9.5", "0.9.6", "0.9.9", "1.0.0", "1.0.1" };
                foreach (var build in productBuild)
                {
                    var product = dbContext.Products.Where(prod => prod.Name == productName)
                        .SingleOrDefault();
                    if (product == null) break;

                    if (!dbContext.Builds.Any(bld => bld.Name == build))
                    {
                        var buildToAdd = new Build()
                        {
                            Name = build,
                            ProductId = product.Id
                        };
                        dbContext.Builds.Add(buildToAdd);
                    }
                }
                dbContext.SaveChanges();

                productBuild = new List<string>() { "0.1.1", "0.1.2", "0.1.3", "0.1.5" };
                foreach (var build in productBuild)
                {
                    var product = dbContext.Products.Where(prod => prod.Name == productName2)
                        .SingleOrDefault();
                    if (product == null) break;

                    if (!dbContext.Builds.Any(bld => bld.Name == build))
                    {
                        var buildToAdd = new Build()
                        {
                            Name = build,
                            ProductId = product.Id
                        };
                        dbContext.Builds.Add(buildToAdd);
                    }
                }
                dbContext.SaveChanges();

                #endregion
            } // End Seeding

        }

        private readonly Action<IRouteBuilder> GetRoutes = 
            routes =>
            {   
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            };
    }
}
