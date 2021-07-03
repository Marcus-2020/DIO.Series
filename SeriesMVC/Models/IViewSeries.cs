using DataLibrary.Enums;

namespace SeriesMVC.Models
{
    public interface IViewSeries
    {
         // Propteries of ISeries

        ///<value>Gets or Sets a Gender enum indicating the series gender.</value>
        Gender Gender { get; set; }
        ///<value>Gets or Sets a string value indicating the series title.</value>
        string Title { get; set; }
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
    }
}