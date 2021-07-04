using System;
using System.Collections.Generic;
using DataLibrary.Models;
using DataLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using SeriesMVC.Models;
using System.Linq;
using SeriesMVC.Factory;
using System.Threading.Tasks;

namespace SeriesMVC.Controllers
{
    /// <summary>A controller for handling the series related views.</summary>
    public class MySeriesController : Controller
    {
        /// <value>The repository of series</value>
        private readonly IRepository<ISeries> _repository;
        private readonly IObjectFactory _objectFactory;

        // Constructor of MySeriesController
        public MySeriesController(ISeriesRepository repository, IObjectFactory objectFactory)
        {
            this._repository = repository;
            this._objectFactory = objectFactory;
        }

        // GET: MySeries
        public IActionResult Index()
        {
            // Gets all active series from the repository
            List<ISeries> seriesList = this._repository.GetAll().Where(x => !x.IsDeleted).ToList();

            // Create a new list for the view series
            List<ViewSeries> viewSeriesList = new List<ViewSeries>();

            // Check if the ISeries list is empty
            if (seriesList.Count > 0)
            {
                // Loop trough the list of series from the repository and transform it to IViewSeries
                foreach (var series in seriesList)
                {
                    // Sets the ISeries properties to the IViewSeries instance
                    ViewSeries viewSeries = new ViewSeries(
                        id: series.ReturnId(),
                        gender: series.Gender,
                        title: series.Title,
                        description: series.Description,
                        year: series.Year);

                    // Add to the list of IViewSeries thas was created earlier
                    viewSeriesList.Add(viewSeries);
                }
            }

            // Return the view with the list of IViewSeries
            return View(viewSeriesList);
        }

        // GET: MySeries/Create
        public IActionResult Create()
        { 
            var model = new ViewSeries();
            return View(model);
        }

        // POST: MySeries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ViewSeries model)
        {
            if (ModelState.IsValid)
            {
                ISeries series = this._objectFactory.CreateSeries(
                    model.Gender,
                    model.Title,
                    model.Description,
                    model.Year);

                this._repository.Insert(series);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}