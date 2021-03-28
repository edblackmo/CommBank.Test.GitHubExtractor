using CommBank.Test.Contracts.Response;
using CommBank.Test.CQRS.Queries;
using CommBank.Test.GitHubExtractor.DataAccessLayer;
using CommBank.Test.GitHubExtractor.DataAccessLayer.GitHub;
using CommBank.Test.GitHubExtractor.GitHub.Contracts.Response;
using CommBank.Test.GitHubExtractor.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommBank.Test.GitHubExtractor.Api
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
            services.AddAutoMapper(typeof(Startup));
            services.AddHttpClient();
            services.AddControllersWithViews();
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<IQuery<IEnumerable<UserGitRepositories>>, GetUsersRepositories>();
            services.AddTransient<IQuery<IEnumerable<UserCommits>>, GetUserCommits>();
            services.AddScoped<IWebDataAccessService<GitHubCommits>, GitHubDataAccessService<GitHubCommits>>();
            services.AddScoped<IWebDataAccessService<GitHubRepositories>, GitHubDataAccessService<GitHubRepositories>>();

            services.Scan(scan => scan.FromAssemblies(assembly)
               .AddClasses(where => where.AssignableTo(typeof(IExecutableQuery<>)))
               .AsSelf()
           );
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=GitHubExtractor}/{action=Index}/{id?}");
            });
        }
    }
}
