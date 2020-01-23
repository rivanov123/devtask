using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TeamRankings.DomainModel;
using TeamRankings.ViewModel;

namespace TeamRankings.Adapters.Mvc.MappingProfiles
{
    public class MatchesMapProfile :Profile
    {
        public MatchesMapProfile()
        {
            //CreateMap<MatchViewModel, Match>().ConvertUsing<MatchViewModelToMatchTypeConverter>();
            CreateMap<Match, MatchViewModel>().ConvertUsing<MatchToMatchViewModelTypeConverter>();
        }
    }

    public class MatchViewModelToMatchTypeConverter : ITypeConverter<MatchViewModel, Match>
    {
        public Match Convert(MatchViewModel source, Match destination, ResolutionContext context)
        {
            return new Match
            {
                Id = source.Id,
                MatchDateTime = source.MatchDateTime,
                TeamScores = new List<TeamMatchScore>
                {
                    new TeamMatchScore
                    {
                        Score = source.TeamAScore
                    }
                }
            };
        }
    }

    public class MatchToMatchViewModelTypeConverter : ITypeConverter<Match, MatchViewModel>
    {
        public MatchViewModel Convert(Match source, MatchViewModel destination, ResolutionContext context)
        {
            var teamScoreA = source.TeamScores.ElementAt(0);
            var teamScoreB = source.TeamScores.ElementAt(1);
            return new MatchViewModel
            {

                Id = source.Id,
                MatchDateTime = source.MatchDateTime,
                TeamA = teamScoreA.Team.Name,
                TeamAScore = teamScoreA.Score,
                TeamB = teamScoreB.Team.Name,
                TeamBScore = teamScoreB.Score
            };
        }
    }
}
