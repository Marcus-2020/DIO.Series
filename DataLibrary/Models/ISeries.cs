using DataLibrary.Enums;

namespace DataLibrary.Models
{
    /// <summary>
    /// The ISeries interface is a base abstraction that is used throughout the application
    /// where a TV series object is needed. 
    ///</summary>
    /// <remarks>
    /// The ISeries interface allows de program to make use of different implementations for a TV series object,
    /// making testing and mantaining the application easier.
    /// </remarks>
    public interface ISeries
    {
        // Propteries of ISeries

        ///<value>Gets or Sets a Gender enum indicating the series gender.</value>
        Gender Gender { get; set; }
        ///<value>Gets or Sets a string value indicating the series title.</value>
        string Title { get; }
        ///<value>Gets or Sets a string value indicating the series description.</value>
        string Description { get; set; }
        ///<value>Gets or Sets a integer value indicating the series year of launch.</value>
        int Year { get; set; }
        ///<value>Gets a boolean value indicating whether the series is deleted.</value>
        bool IsDeleted { get; }

        // Methods of ISeries

        /// <summary>
        /// Return a integer value representing the series id.
        /// </summary>
        /// <returns>
        /// A integer value representing the series id.
        /// </returns>
        int ReturnId();

        /// <summary>
        /// Sets a integer value as the series id.
        /// </summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        void SetId(int id);

        /// <summary>
        /// Alter the state of the series object to indicate that is deleted.
        /// </summary>
        void Delete();

        /// <summary>
        /// Alter the state of the series object to indicate that is not deleted.
        /// </summary>
        void Restore();
    }
}