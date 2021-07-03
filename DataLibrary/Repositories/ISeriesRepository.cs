using DataLibrary.Models;

namespace DataLibrary.Repositories
{
    /// <summary>
    /// This interface abstract a repository of series (ISeries) that can be used to implement 
    /// various types of data access.
    /// </summary>
    public interface ISeriesRepository : IRepository<ISeries>
    {
        
    }
}