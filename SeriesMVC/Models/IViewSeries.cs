using System.ComponentModel.DataAnnotations;
using DataLibrary.Enums;

namespace SeriesMVC.Models
{
    public interface IViewSeries
    {
        // Propteries of IViewSeries

        /// <value>Get a integer value indicating the entity id</value>
        public int Id { get; set; }
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
        /// Alter the state of the series object to indicate that is deleted.
        /// </summary>
        void Delete();

        /// <summary>
        /// Alter the state of the series object to indicate that is not deleted.
        /// </summary>
        void Restore();
        
    }
}