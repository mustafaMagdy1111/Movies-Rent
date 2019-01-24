using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Movies_Rent.Models;
using Movies_Rent.Viewmodels;

namespace Movies_Rent.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _MOviescontext;
        public MoviesController()
        {
            _MOviescontext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _MOviescontext.Dispose();
        }
        public ActionResult Random()
        { var movies = _MOviescontext.movies.Include(c => c.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View(movies);
            else return View("list");
      
        }
        public ActionResult list()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var mov = _MOviescontext.movies.Include(c=>c.Genre).SingleOrDefault(c => c.ID == id);

            return View(mov);
        }
        public ActionResult MoviesForm()
        {

            var GenreType = _MOviescontext.Genre.ToList();
            var mov = new Movie();
            mov.NumberInStocks = 0;
            var GenreModel = new MoviesGenre
            {
                movie = mov,
                genreTypes = GenreType
            };

            return View(GenreModel);
        }


        public ActionResult Edit (int id)
        {
    
            var mov = _MOviescontext.movies.SingleOrDefault(c => c.ID == id);
      
            if (mov == null)
                return HttpNotFound();
            var viewmodel = new MoviesGenre
            {
                
               
                movie = mov,
                genreTypes = _MOviescontext.Genre.ToList()
            };

            return View("MoviesForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Save(Movie movie)
        {
            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _MOviescontext.movies.Add(movie);
            }
            else
            {
                var movieInDb = _MOviescontext.movies.Single(m => m.ID == movie.ID);
                movieInDb.Name = movie.Name;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.NumberInStocks = movie.NumberInStocks;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _MOviescontext.SaveChanges();

            return RedirectToAction("Random", "Movies");
        }

    }
    }
