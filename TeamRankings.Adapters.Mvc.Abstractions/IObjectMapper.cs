namespace TeamRankings.Adapters.Mvc.Abstractions
{
    public interface IObjectMapper
    {
        TDestination Map<TSource, TDestination>(TSource srcObj);
    }
}
