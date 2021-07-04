using System;
using System.ComponentModel.DataAnnotations;
using DataLibrary.Enums;
using DataLibrary.Models;

namespace SeriesMVC.Models
{
    public class ViewSeries : BaseEntity, IViewSeries
    {
        // Private backing fields
        /*
            This private backing fields are used to encapsulate the series data 
            in a way that other classes could only access the data from the public properties
            where more validation and controll can be added.
        */
        private Gender _gender;
        private string _title;
        private string _description;
        private int _year;
        private bool _isDeleted;

        [Required(ErrorMessage ="The series gender is required.")]
        // Properties
        ///<value>Gets or Sets the series gender.</value>
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [Required(ErrorMessage = "The series title is required.")]
        [MinLength(3, ErrorMessage = "The title must have at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "The title can't exceed 100 characters.")]
        /// <value>
        /// <para>Gets or Sets the series title.</para>
        /// <para>The string passed as Set parameter should not be null or empty and have more than 3 characters.</para>
        /// </value>
        public string Title
        {
            get { return _title; }
        
            set
            {
                _title = value;
            }
        }

        [Required(ErrorMessage = "The series description is required.")]
        [MinLength(3, ErrorMessage = "The description must have at least 3 characters.")]
        [MaxLength(500, ErrorMessage = "The description can't exceed 500 characters.")]
        ///<value>Gets or Sets the Series description.</value>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Required(ErrorMessage = "The year of release is required.")]
        [Range(1900, 2100, ErrorMessage = "The year of release be between 1900 and the current year.")]
        /// <value>
        /// <para>Gets or Sets the series year of launch.</para>
        /// <para>The date passed as Set parameter must be bigger than 1900 and less or equal to the current year.</para>
        /// </value>
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
            }
        }

        ///<value>Gets a boolean value indicating whether the series is deleted.</value>
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }       

        // Constructor with id
        public ViewSeries(int id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.IsDeleted = false;
        }
        
        // An empty constructor
        public ViewSeries()
        {
        }

        /// <summary>
        /// Return a integer value representing the series Id.
        /// </summary>
        /// <remarks>
        /// The Id value returned is inherited from the BaseEntity class.
        /// </remarks>
        /// <returns>
        /// A integer value representing the series Id.
        /// </returns>
        public int ReturnId()
        {
            return this.Id;
        }

        /// <summary>
        /// Sets a integer value as the series Id.
        /// </summary>
        /// <param name="id">An unique identifier for a ISeries object in the repository.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throw when the <paramref name="id"/>  passed is less than 0..
        ///</exception>
        public void SetId(int id)
        {
            if(id < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid id passed as argument, expected a integer number bigger than 0.");
            }

            this.Id = id;
        }
    }
}