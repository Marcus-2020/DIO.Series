using System;
using System.Collections.Generic;
using DataLibrary.Exceptions;
using DataLibrary.Models;

namespace DataLibrary.Repositories
{
    /// <summary>
    /// <para>The SeriesListRepository implements the ISeriesRepository interface.</para>
    /// <para>This implementation is resposible for executing data access operations in List of ISeries.</para>
    ///</summary>
    public class SeriesListRepository : ISeriesListRepository
    {
        // A List of ISeries (series) used as a 'database' for the purposes of this project.
        private List<ISeries> _series = new List<ISeries>();

        // Constructor of SeriesListRepository
        public SeriesListRepository()
        {
        }

        // Methods of SeriesListRepository

        /// <summary>Delete a series from the repository given an id value.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
        public void Delete(int id)
        {
            if(this.ValidateId(id))
            {
                this._series[id].Delete();
            }
        }

        /// <summary>Restore a series from the repository given an id value.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
        public void Restore(int id)
        {
            if(this.ValidateId(id))
            {
                this._series[id].Restore();
            }
        }

        /// <summary>Return all series objects from the repository.</summary>
        /// <returns>Return a List of ISeries, if the repository is empty returns null.</returns>
        public List<ISeries> GetAll()
        {
            return this._series;
        }

        /// <summary>Get a single series from the repository given an id value.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <returns>Return a ISeries object.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
        /// <exception cref="DataLibrary.SeriesNotFoundException">
        /// Thrown when the <paramref name="id"/> value results in no series found inside the repository.
        /// </exception>
        public ISeries GetById(int id)
        {
            ISeries series = null;

            if(this.ValidateId(id))
            {
                if(this.CheckIfSeriesExists(id))
                {
                    series = this._series.Find(x => x.ReturnId() == id);;
                }
            }
            
            return series;
        }

        /// <summary>Insert a ISeries object into the repository.</summary
        /// <param name="entity">The ISeries object to be inserted into the repository.</param>
        /// <exception cref="System.ArgumentNullException.">
        /// Thrown when the <paramref name="entity"/> is passed <c>null</c>.
        /// </exception>
        public void Insert(ISeries entity)
        {
            if(entity.Equals(null))
            {
                throw new ArgumentNullException(
                    "Invalid series passed, object can't be null.");
            }

            entity.SetId(this.NextId());
            
            this._series.Add(entity);
        }

        /// <summary>Return the next unique identifier from the repository.</summary>
        /// <returns>Return an integer value representing the next id from the repository.</returns>>
        public int NextId()
        {
            return this._series.Count;
        }

        /// <summary>Update a ISeries object already inside the repository.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <param name="entity">The ISeries object to be inserted into the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
        /// <exception cref="DataLibrary.SeriesNotFoundException">
        /// Thrown when the <paramref name="id"/> value results in no series found inside the repository.
        /// </exception>
        public void Update(int id, ISeries entity)
        {
            if(this.ValidateId(id))
            {
                if(this.CheckIfSeriesExists(id))
                {
                    this._series[id] = entity;
                }
            }
        }

        /// <summary>Check if the series using a given id exists inside the repository.</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <returns>A boolean value representing if the series exists.</returns>
        /// <exception cref="DataLibrary.SeriesNotFoundException">
        /// Thrown when the <paramref name="id"/> value results in no series found inside the repository.
        /// </exception>
        private bool CheckIfSeriesExists(int id)
        {
            bool result = true;
           
            if(id > (this._series.Count-1))
            {
                throw new SeriesNotFoundException(
                    "The requested series was not found.");
            }

            return result;
        }

        /// <summary>Check if an given id is bigger than 0</summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <returns>A boolean value representing if the id is valid.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException.">
        /// Thrown when the <paramref name="id"/> with a value is less than 0 is passed.
        /// </exception>
        private bool ValidateId(int id)
        {
            bool result = true;

            if(id < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid id passed as argument, expected a integer number bigger than 0.");
            }

            return result;
        }
    }
}