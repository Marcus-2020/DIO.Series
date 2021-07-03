using System;
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

        // Properties
        ///<value>Gets or Sets the series gender.</value>
        public Gender Gender
        {
            get { return _gender; }
            private set { _gender = value; }
        }

        /// <value>
        /// <para>Gets or Sets the series title.</para>
        /// <para>The string passed as Set parameter should not be null or empty and have more than 3 characters.</para>
        /// </value>
        public string Title
        {
            get { return _title; }
        
            private set
            {
                _title = value;
            }
        }

        ///<value>Gets or Sets the Series description.</value>
        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        /// <value>
        /// <para>Gets or Sets the series year of launch.</para>
        /// <para>The date passed as Set parameter must be bigger than 1900 and less or equal to the current year.</para>
        /// </value>
        public int Year
        {
            get { return _year; }
            private set
            {
                _year = value;
            }
        }

        ///<value>Gets a boolean value indicating whether the series is deleted.</value>
        public bool IsDeleted
        {
            get { return _isDeleted; }
            private set { _isDeleted = value; }
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
    }
}