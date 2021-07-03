using System.Collections.Generic;

namespace DataLibrary.Repositories
{
    public interface IRepository<T>
    {
        // Methods of SeriesListRepository

        /// <summary>Return all series objects from the repository.</summary>
        /// <returns>Return a List of ISeries, if the repository is empty returns null.</returns>
         List<T> GetAll();

        /// <summary>Get a single series from the repository given an id value.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <returns>Return a ISeries object.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
        /// <exception cref="DataLibrary.SeriesNotFoundException">
        /// Thrown when the <paramref name="id"/> value results in no series found inside the repository.
        /// </exception>
         T GetById(int id);

        /// <summary>Delete a series from the repository given an id value.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
         void Delete(int id);

        /// <summary>Restore a series from the repository given an id value.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
         void Restore(int id);

        /// <summary>Update a ISeries object already inside the repository.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <param name="entity">The ISeries object to be inserted into the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
        /// <exception cref="DataLibrary.SeriesNotFoundException">
        /// Thrown when the <paramref name="id"/> value results in no series found inside the repository.
        /// </exception>         
         void Update(int id, T entity);

        /// <summary>Insert a ISeries object into the repository.</summary
        /// <param name="entity">The ISeries object to be inserted into the repository.</param>
        /// <exception cref="System.ArgumentNullException.">
        /// Thrown when the <paramref name="entity"/> is passed <c>null</c>.
        /// </exception>
         void Insert(T entity);
    }
}