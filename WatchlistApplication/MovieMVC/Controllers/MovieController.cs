using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models.ViewModels;
using MovieMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMVC.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.NetworkInformation;

namespace MovieMVC.Controllers
{
    public class MovieController : Controller
    {
        MovieContext context;
        public MovieController(MovieContext _context)
        {
            context = _context;
        }

        //Category Actions
        CategoryVM categoryVModel = new CategoryVM();
        public IActionResult CategoryList()
        {
            categoryVModel.cList = context.Categories.ToList();
            return View(categoryVModel);
        }
        public IActionResult CreateCategory()
        {
            categoryVModel.cList = context.Categories.ToList();
            return View(categoryVModel);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryVM categoryVModel)
        {
            context.Categories.Add(categoryVModel.Category);
            context.SaveChanges();
            TempData["result"] = "A new category named " + categoryVModel.Category.CategoryName + " has been added!";
            return RedirectToAction("CategoryList");
        }
        public IActionResult EditCategory(int id)
        {
            categoryVModel.Category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(categoryVModel);
        }

        [HttpPost]
        public IActionResult EditCategory(int id, CategoryVM categoryVModel)
        {
            Category category = context.Categories.Find(id);
            category.CategoryName = categoryVModel.Category.CategoryName;
            category.Description = categoryVModel.Category.Description;
            context.SaveChanges();
            TempData["result"] = "The category successfully updated!";
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            TempData["result"] = "The category deleted!";
            return RedirectToAction("CategoryList");
        }


        MovieVM movieVModel = new MovieVM();
        //Movie Actions
        public IActionResult MovieList()
        {
            movieVModel.mList = context.Movies.Select(x => new MovieDTO()
            {
                MovieId = x.MovieId,
                MovieName = x.MovieName,
                About= x.About,
                ReleaseDate= x.ReleaseDate,
                CategoryName = x.Category.CategoryName
            }).ToList();
            return View(movieVModel);
        }
        public IActionResult CreateMovie()
        {
            movieVModel.DropDownForCategory = FillCategory();
            return View(movieVModel);
        }
        [HttpPost]
        public IActionResult CreateMovie(MovieVM movieVModel)
        {
            context.Movies.Add(movieVModel.Movie);
            context.SaveChanges();
            TempData["result"] = "A new movie named " + movieVModel.Movie.MovieName + " has been added!";
            return RedirectToAction("MovieList");
        }
        public IActionResult EditMovie(int id)
        {
            movieVModel.Movie = context.Movies.Find(id);
            movieVModel.DropDownForCategory = FillCategory();
            return View(movieVModel);
        }

        [HttpPost]
        public IActionResult EditMovie(int id, MovieVM movieVModel)
        {
            Movie movie = context.Movies.Find(id);
            movie.MovieName = movieVModel.Movie.MovieName;
            movie.About = movieVModel.Movie.About;
            movie.ReleaseDate = movieVModel.Movie.ReleaseDate;
            movie.CategoryId = movieVModel.Movie.CategoryId;
            context.SaveChanges();
            TempData["result"] = "The movie successfully updated!";
            return RedirectToAction("MovieList");
        }

        public IActionResult DeleteMovie(int id)
        {
            context.Movies.Remove(context.Movies.Find(id));
            context.SaveChanges();
            TempData["result"] = "The movie deleted!";
            return RedirectToAction("MovieList");
        }
        public IActionResult MovieDetails(int id)
        {
            movieVModel.mList = context.Movies.Select(x => new MovieDTO()
            {
                MovieId = x.MovieId,
                MovieName = x.MovieName,
                About = x.About,
                ReleaseDate = x.ReleaseDate,
                CategoryName = x.Category.CategoryName
            }).ToList();
            return View(movieVModel);
        }
        private List<SelectListItem> FillCategory()
        {
            return context.Categories.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
        }

    }
}
