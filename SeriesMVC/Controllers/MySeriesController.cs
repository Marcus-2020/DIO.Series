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
        /// <value>An object factory used to create ISeries and IViewSeries</value>
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
            List<IViewSeries> viewSeriesList = new List<IViewSeries>();

            // Check if the ISeries list is empty
            if (seriesList.Count > 0)
            {
                // Loop trough the list of series from the repository and transform it to IViewSeries
                foreach (var series in seriesList)
                {
                    // Builds the IViewSeries from a series object
                    var viewSeries = BuildViewSeriesFromSeries(series);

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
            var model = this._objectFactory.CreateViewSeries();
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

        // GET: MySeries/Edit/{id}
        public IActionResult Edit(int id)
        {
            try
            {
                // Recover the series from the repository.
                var model = this.GetOneSeriesFromRepository(id);

                // Show the view with the parsed model.
                return View(model);
            }
            catch (System.Exception)
            {
                /*
                    More action could be done here if an exception occurs,
                    the .GetById() method from the repository for example can throw
                    two types of exceptions that can be handled individually,
                    DataLibrary.SeriesNotFoundException and System.ArgumentOutOfRangeException
                    but for simplicity sake, i just throw a NotFound() for now if any exception is catched.
                */
                return NotFound();
            }
        }

        // POST: MySeries/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ViewSeries model)
        {
            if (ModelState.IsValid)
            {
                var series = BuildSeriesFromViewSeries(model);

                this._repository.Update(series.ReturnId(),series);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: MySeries/Delete/{id}
        public IActionResult Delete(int id)
        {
            try
            {
                // Recover the series from the repository.
                var model = this.GetOneSeriesFromRepository(id);

                // Show the view with the parsed model.
                return View(model);
            }
            catch (System.Exception)
            {
                /*
                    More action could be done here if an exception occurs,
                    the .GetById() method from the repository for example can throw
                    two types of exceptions that can be handled individually,
                    DataLibrary.SeriesNotFoundException and System.ArgumentOutOfRangeException
                    but for simplicity sake, i just throw a NotFound() for now if any exception is catched.
                */
                return NotFound();
            }
            
        }

        // POST: MySeries/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCofirmed(int id)
        {
            this._repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MySeries/Details/{id}
        public IActionResult Details(int id)
        {
            try
            {
                // Recover the series from the repository.
                var model = this.GetOneSeriesFromRepository(id);

                // Show the view with the parsed model.
                return View(model);
            }
            catch (System.Exception)
            {
                /*
                    More action could be done here if an exception occurs,
                    the .GetById() method from the repository for example can throw
                    two types of exceptions that can be handled individually,
                    DataLibrary.SeriesNotFoundException and System.ArgumentOutOfRangeException
                    but for simplicity sake, i just throw a NotFound() for now if any exception is catched.
                */
                return NotFound();
            }
        }

        /// <summary>Get one ISeries object from the repository.</summary>
        /// <param name="id">An unique identifier for a ISeries object inside the repository.</param>
        /// <returns>An ISeries object from the repository.</returns>
        private IViewSeries GetOneSeriesFromRepository(int id)
        {
            // Recover the series from the repository.
            var series = _repository.GetById(id);

            // Parse to IViewSeries object
            var model = BuildViewSeriesFromSeries(series);

            // Show the view with the parsed model.
            return model;
        }

        /// <summary>Build a new IViewSeries instance from one of ISeries.</summary>
        /// <param name="series">An ISeries instance.</param>
        /// <returns>Returns a new IViewSeries instance.</returns>
        private IViewSeries BuildViewSeriesFromSeries(ISeries series)
        {
            // Parse to IViewSeries object
            var viewSeries = _objectFactory.CreateViewSeries(
                id: series.ReturnId(),
                gender: series.Gender,
                title: series.Title,
                description: series.Description,
                year: series.Year);
            
            return viewSeries;
        }

        /// <summary>Build a new ISeries instance from one of IViewSeries.</summary>
        /// <param name="viewSeries">An IViewSeries instance.</param>
        /// <returns>Returns a new ISeries instance.</returns>
        /// <exception cref="DataLibrary.SeriesPropertyValidationException">Invalid data passed as argument for the ISeries properties.</exception>
        private ISeries BuildSeriesFromViewSeries(IViewSeries viewSeries)
        {
            ISeries series = this._objectFactory.CreateSeries(
                    viewSeries.Id,
                    viewSeries.Gender,
                    viewSeries.Title,
                    viewSeries.Description,
                    viewSeries.Year);
            
            return series;
        }
    }
}