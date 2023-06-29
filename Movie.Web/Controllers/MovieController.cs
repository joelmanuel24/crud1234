using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Data.Repositories;
using Movie.Web.Models;

namespace Movie.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRepository movieRepository;
        private readonly CategoryRepository categoryRepository;

        public MovieController(MovieRepository movieRepository, CategoryRepository categoryRepository) 
        {
            this.movieRepository = movieRepository;
            this.categoryRepository = categoryRepository;
        }    
        // GET: MovieController
        public async Task<ActionResult> Index()
        {
            return View(await this.movieRepository.GetAll());
        }

        // GET: MovieController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var movie = await this.movieRepository.GetById(id);
            return View(movie);
        }

        // GET: MovieController/Create
        public async Task<ActionResult> Create()
        {
            var categories = await this.categoryRepository.GetAll();
            return View(new MovieViewModel() 
            { 
                Categories = categories.Select(
                    c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                        { 
                            Value = c.CategoryID.ToString(),
                            Text = c.CategoryName
                        }
                    ) 
            });
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovieViewModel model)
        {
            try
            {
                var movie = model.Movie;

                movie.Category = await this.categoryRepository.GetById(movie.Category.CategoryID);

                await this.movieRepository.Create(model.Movie);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var movie = await this.movieRepository.GetById(id);
            var categories = await this.categoryRepository.GetAll();
            return View(new MovieViewModel()
            {
                Movie = movie,
                Categories = categories.Select(
                    c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                    {
                        Value = c.CategoryID.ToString(),
                        Text = c.CategoryName
                    }
                    )
            });
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MovieViewModel model)
        {
            try
            {
                var movie = await this.movieRepository.GetById(id);

                movie.Name = model.Movie.Name;
                movie.Description = model.Movie.Description;
                movie.Category = await this.categoryRepository.GetById(model.Movie.Category.CategoryID);

                await this.movieRepository.Update(movie);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var movie = await this.movieRepository.GetById(id);
            return View(movie);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var movie = await this.movieRepository.GetById(id);

                await this.movieRepository.Delete(movie);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
