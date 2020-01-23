using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamRankings.Adapters.Mvc.Hubs;
using TeamRankings.Extensions;
using TeamRankings.Filters;

namespace TeamRankings
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
            services.AddTeamRankingsDataAccess(Configuration);
            services.AddTeamRankingsDomainLayer();
            services.AddMvcAdapterLayer();
            services.AddSignalR();
            services.AddSingleton<TeamsHub>();

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<AjaxErrorHandleFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler("/Shared/Error");

            app.UseStaticFiles();
            app.UseSignalR(cfg =>
            {
                cfg.MapHub<TeamsHub>("/teamHub");
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Teams}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Matches",
                    template: "{controller=Match}/{action=Index}/{id?}");
            });
        }
    }
}
