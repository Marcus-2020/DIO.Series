using DataLibrary.Enums;

namespace SeriesMVC.Models
{
    public interface IViewSeries
    {
        // Propteries of IViewSeries

        ///<value>Gets or Sets a Gender enum indicating the series gender.</value>
        Gender Gender { get; }
        ///<value>Gets or Sets a string value indicating the series title.</value>
        string Title { get; }
        ///<value>Gets or Sets a string value indicating the series description.</value>
        string Description { get; }
        ///<value>Gets or Sets a integer value indicating the series year of launch.</value>
        int Year { get; }
        ///<value>Gets a boolean value indicating whether the series is deleted.</value>
        bool IsDeleted { get; }

        // Methods of IViewSeries

        /// <summary>
        /// Return a integer value representing the series id.
        /// </summary>
        /// <returns>
        /// A integer value representing the series id.
        /// </returns>
        int ReturnId();

    }
}