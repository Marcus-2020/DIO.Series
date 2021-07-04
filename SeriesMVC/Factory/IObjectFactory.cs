using DataLibrary.Enums;
using DataLibrary.Models;
using SeriesMVC.Models;

namespace SeriesMVC.Factory
{
    public interface IObjectFactory
    {
        ISeries CreateSeries();
        ISeries CreateSeries(Gender gender, string title, string description, int year);
        ISeries CreateSeries(int id, Gender gender, string title, string description, int year);
        IViewSeries CreateViewSeries();
        IViewSeries CreateViewSeries(int id, Gender gender, string title, string description, int year);
    }
}