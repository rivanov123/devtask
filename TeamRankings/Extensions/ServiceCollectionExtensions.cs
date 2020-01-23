using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamRankings.Adapters.Mvc;
using TeamRankings.Adapters.Mvc.Abstractions;
using TeamRankings.Adapters.Mvc.MappingProfiles;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainLayer.Decorators;
using TeamRankings.DomainLayer.MatchStates;
using IObjectMapper = TeamRankings.Adapters.Mvc.Abstractions.IObjectMapper;

namespace TeamRankings.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTeamRankingsDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddScoped(_ => new TeamRankingsDbContext(configuration.GetConnectionString("TeamRankings")));
        }

        public static IServiceCollection AddTeamRankingsDomainLayer(this IServiceCollection services)
        {
            services.AddScoped<IStateObserver<MatchStateCommand>, MatchStateObserver>();
            services.AddSingleton<IRankComputeStrategy, DefaultRankComputeStrategy>();
            services.AddScoped<IMatchesManager>(provider =>
                new MatchesManagerDbSynchronizationDecorator(
                    provider.GetService<TeamRankingsDbContext>(),
                    new ObservableMatchesManagerDecorator(new MatchesManager(provider.GetService<TeamRankingsDbContext>()), provider.GetService<IStateObserver<MatchStateCommand>>(), provider.GetService<TeamRankingsDbContext>())));

            return services.AddScoped<ITeamsManager>(provider => new TeamsManagerDbSynchronizationDecorator(provider.GetService<TeamRankingsDbContext>(), 
                new TeamsManager(provider.GetService<TeamRankingsDbContext>(), provider.GetService<IRankComputeStrategy>())));
        }

        public static IServiceCollection AddMvcAdapterLayer(this IServiceCollection services)
        {
            services.AddScoped<ITeamsManagerAdapter, TeamsManagerAdapter>();
            services.AddScoped<IMatchesManagerAdapter, MatchesManagerAdapter>();
            services.AddSingleton<IObjectMapper, AutoMapperObjectMapper>();
            return services.AddAutoMapper(typeof(AutoMapperProfileMarkerType));
        }
    }
}
