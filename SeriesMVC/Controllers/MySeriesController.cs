using System;
using System.Collections.Generic;
using DataLibrary.Models;
using DataLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using SeriesMVC.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace SeriesMVC.Controllers
{
    /// <summary>A controller for handling the series related views.</summary>
    public class MySeriesController : Controller
    {
        /// <value>The repository of series</value>
        private readonly IRepository<ISeries> _repository;
        private readonly IServiceProvider _serviceProvider;

        // Constructor of MySeriesController
        public MySeriesController(ISeriesRepository repository, IServiceProvider serviceProvider)
        {
            this._repository = repository;
            this._serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            // Gets all active series from the repository
            List<ISeries> seriesList = this._repository.GetAll().Where(x => !x.IsDeleted).ToList();

            // Create a new list for the view series
            List<IViewSeries> viewSeriesList = new List<IViewSeries>();

            // Check if the ISeries list is empty
            if (seriesList.Count > 0)
            {
                // Loop trough the list of series from the repository and transform it to IViewSeries
                foreach (var series in seriesList)
                {
                    // Resolves a empity IViewSeries instance
                    IViewSeries viewSeries = this._serviceProvider.GetService<IViewSeries>();

                    // Sets the ISeries properties on the IViewSeries instance
                    viewSeries.SetId(series.ReturnId());
                    viewSeries.Title = series.Title;
                    viewSeries.Description = series.Description;
                    viewSeries.Gender = series.Gender;
                    viewSeries.Year = series.Year;

                    // Add to the list of IViewSeries thas was created earlier
                    viewSeriesList.Add(viewSeries);
                }
            }

            // Return the view with the list of IViewSeries
            return View(viewSeriesList);
        }
    }
}