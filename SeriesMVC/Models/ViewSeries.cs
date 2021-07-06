using System;
using System.ComponentModel.DataAnnotations;
using DataLibrary.Enums;
using DataLibrary.Models;

namespace SeriesMVC.Models
{
    public class ViewSeries : IViewSeries
    {
        // Private backing fields
        /*
            This private backing fields are used to encapsulate the series data 
            in a way that other classes could only access the data from the public properties
            where more validation and controll can be added.
        */
        private int _id;
        private Gender _gender;
        private string _title;
        private string _description;
        private int _year;
        private bool _isDeleted;

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

        [Required(ErrorMessage = "The series Id is required.")]
        /// <value>Get a integer value indicating the entity Id</value>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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
        
            set { _title = value; }
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

        /// <summary>
        /// Alter the state of the series object to indicate that is deleted.
        /// </summary>
        /// <remarks>
        /// Check if the series is already deleted, if not alter it's state to deleted.
        /// </remarks>
        public void Delete()
        {
            if(IsDeleted)
            {
                return;
            }

            this.IsDeleted = true;
        }

        /// <summary>
        /// Alter the state of the series object to indicate that is not deleted.
        /// </summary>
        /// <remarks>
        /// Check if the series is already not deleted, if not alter it's state to not deleted.
        /// </remarks>
        public void Restore()
        {
            if(!IsDeleted)
            {
                return;
            }

            this.IsDeleted = false;
        }
    }
}