using DataLibrary.Enums;

namespace SeriesMVC.Models
{
    public class GenderView
    {
        public GenderView()
        {
        }
        
        public GenderView(string description, Gender gender)
        {
            Description = description;
            Gender = gender;
        }

        public string Description { get; set; }
        public Gender Gender { get; set; }

    }
}