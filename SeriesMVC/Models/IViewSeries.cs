using System.ComponentModel.DataAnnotations;
using DataLibrary.Enums;

namespace SeriesMVC.Models
{
    public interface IViewSeries
    {
        // Propteries of IViewSeries

        [Required]
        ///<value>Gets or Sets a Gender enum indicating the series gender.</value>
        Gender Gender { get; }
        [Required]
        ///<value>Gets or Sets a string value indicating the series title.</value>
        string Title { get; }
        [Required]
        ///<value>Gets or Sets a string value indicating the series description.</value>
        string Description { get; }
        [Required]
        ///<value>Gets or Sets a integer value indicating the series year of launch.</value>
        int Year { get; }
        [Required]
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

        /// <summary>
        /// Sets a integer value as the series Id.
        /// </summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throw when the <paramref name="id"/>  passed is less than 0..
        ///</exception>
        void SetId(int id);
    }
}