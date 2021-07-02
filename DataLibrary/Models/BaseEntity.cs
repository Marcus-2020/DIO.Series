namespace DataLibrary.Models
{
    /// <summary>
    /// This class represents an abstraction that can be used as a base for all other classes, because inherits
    /// for then the basic attributes that they needed.
    ///</summary>
    /// <remarks>The BaseEntity class inherits to it's derived classes the Id property.</remarks>
    public abstract class BaseEntity
    {
        // Private backing field
        private int _id;

        // Properties
        /// <value>Get a integer value indicating the entity id</value>
        public int Id
        {
            get { return _id; }

            // Here the set method for the Id proterty is protected, meaning that it can only be accessed by 
            /// a class that inherits from BaseEntity or the class itself.
            protected set { _id = value; }
        }
        
    }
}