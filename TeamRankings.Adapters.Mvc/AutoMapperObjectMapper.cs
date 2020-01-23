using AutoMapper;
using IObjectMapper = TeamRankings.Adapters.Mvc.Abstractions.IObjectMapper;

namespace TeamRankings.Adapters.Mvc
{
    public class AutoMapperObjectMapper : IObjectMapper
    {
        private readonly IMapper _mapper;

        public AutoMapperObjectMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TDestination Map<TSource, TDestination>(TSource srcObj)
        {
            return _mapper.Map<TDestination>(srcObj);
        }
    }
}
