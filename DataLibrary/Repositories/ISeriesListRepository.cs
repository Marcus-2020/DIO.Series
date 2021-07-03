namespace DataLibrary.Repositories
{
    /// <summary>
    /// This interface abstract a repository of series (ISeries) using a List as 'database'.
    /// </summary>
    public interface ISeriesListRepository : ISeriesRepository
    {
        /// <summary>Return the next unique identifier from the repository.</summary>>
        int NextId();
    }
}