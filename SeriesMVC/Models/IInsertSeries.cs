using DataLibrary.Enums;

namespace SeriesMVC.Models
{
    public interface IInsertSeries : IViewSeries
    {
         void SetGender(Gender gender);
         void SetTitle(string title);
         void SetDescription(string description);
         void SetYear(int year);
    }
}