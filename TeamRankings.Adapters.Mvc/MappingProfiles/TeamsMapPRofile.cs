using AutoMapper;
using TeamRankings.DomainModel;
using TeamRankings.ViewModel;

namespace TeamRankings.Adapters.Mvc.MappingProfiles
{
    public class TeamsMapProfile : Profile
    {
        public TeamsMapProfile()
        {
            CreateMap<TeamViewModel, Team>()
                .ReverseMap();
        }
    }
}
