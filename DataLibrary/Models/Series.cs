using DataLibrary.Enums;

namespace DataLibrary.Models
{
    /// <summary>
    /// The Series class represents one TV Series withs his attributes.
    /// <remarks> 
    /// This class implements the ISeries interface and inherits from the BaseEntity abstract class, 
    /// from which receives the Id property.
    ///</remarks>
    /// </sumary>
    public class Series : BaseEntity, ISeries
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
            set { _gender = value; }
        }
        ///<value>Gets or Sets the series title.</value>
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
            set { _description = value; }
        }
        ///<value>Gets or Sets the series year of launch.</value>
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
            private set { _isDeleted = value; }
        }

        // Constructor      
        public Series(int id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.IsDeleted = false;
        }

        /// <summary>
        /// Return a integer value representing the series id.
        /// </summary>
        /// <remarks>
        /// The Id value returned is inherited from the BaseEntity class.
        /// </remarks>
        /// <returns>
        /// A integer value representing the series id.
        /// </returns>
        public int ReturnId()
        {
            return this.Id;
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