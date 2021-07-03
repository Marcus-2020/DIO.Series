using DataLibrary.Enums;
using DataLibrary.Models;
using SeriesMVC.Models;

namespace SeriesMVC.Factory
{
    public class ObjectFactory : IObjectFactory
    {
        #region ISeries instantiation methods
        // Instantiate series object for ISeries interface

        /// <summary>Instantiate an empty instance of ISeries.</summary>
        /// <returns>An instance of ISeries.</returns>
        public ISeries CreateSeries()
        {
            return new Series();
        }

        /// <summary>Instantiate an filled instance of ISeries without Id.</summary>
        /// <returns>An instance of ISeries.</returns>
        /// <param name="gender">An enum value representing the gender of the instance.</param>
        /// <param name="title">A string representing the title of the series.</param>
        /// <param name="description">A string representing the description of the series.</param>
        /// <param name="year">An integer representing the year when the series starts.</param>
        public ISeries CreateSeries(Gender gender, string title, string description, int year)
        {
            return new Series(gender, title, description, year);
        }

        /// <summary>Instantiate an filled instance of ISeries with Id.</summary>
        /// <returns>An instance of ISeries.</returns>
        /// <param name="id">An integer representing the ID of the series.</param>
        /// <param name="gender">An enum value representing the gender of the instance.</param>
        /// <param name="title">A string representing the title of the series.</param>
        /// <param name="description">A string representing the description of the series.</param>
        /// <param name="year">An integer representing the year when the series starts.</param>
        public ISeries CreateSeries(int id, Gender gender, string title, string description, int year)
        {
            return new Series(id, gender, title, description, year);
        }
        #endregion

        #region IViewSeries instantiation methods

        // Instantiate series object for IViewSeries interface

        /// <summary>Instantiate an empty instance of IViewSeries.</summary>
        /// <returns>An instance of IViewSeries.</returns>
        public IViewSeries CreateViewSeries()
        {
            return new ViewSeries();
        }

        /// <summary>Instantiate an filled instance of IViewSeries with Id.</summary>
        /// <returns>An instance of IViewSeries.</returns>
        /// <param name="id">An integer representing the ID of the series.</param>
        /// <param name="gender">An enum value representing the gender of the instance.</param>
        /// <param name="title">A string representing the title of the series.</param>
        /// <param name="description">A string representing the description of the series.</param>
        /// <param name="year">An integer representing the year when the series starts.</param>
        public IViewSeries CreateViewSeries(int id, Gender gender, string title, string description, int year)
        {
            return new ViewSeries(id, gender, title, description, year);
        }

        #endregion

        #region IInsertSeries instantiation methods

        // Instantiate series object for IInsertSeries interface

        /// <summary>Instantiate an empty instance of IInsertSeries.</summary>
        /// <returns>An instance of IInsertSeries.</returns>
        public IInsertSeries CreateInsertSeries()
        {
            return new InsertSeries();
        }

        /// <summary>Instantiate an filled instance of IInsertSeries without Id.</summary>
        /// <returns>An instance of IInsertSeries.</returns>
        /// <param name="gender">An enum value representing the gender of the instance.</param>
        /// <param name="title">A string representing the title of the series.</param>
        /// <param name="description">A string representing the description of the series.</param>
        /// <param name="year">An integer representing the year when the series starts.</param>
        public IInsertSeries CreateInsertSeries(Gender gender, string title, string description, int year)
        {
            return new InsertSeries(gender, title, description, year);
        }
        
        #endregion

        #region IUpdateSeries instantiation methods
        // TODO: Implement IUpdateSeries instantiation and implmentation model.
        #endregion
    }
}