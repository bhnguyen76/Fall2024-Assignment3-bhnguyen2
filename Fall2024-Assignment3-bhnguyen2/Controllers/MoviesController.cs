using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fall2024_Assignment3_bhnguyen2.Data;
using Fall2024_Assignment3_bhnguyen2.Models;
using Fall2024_Assignment3_bhnguyen2.Services;
using Fall2024_Assignment3_bhnguyen2.Data.Migrations;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;

namespace Fall2024_Assignment3_bhnguyen2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OpenAIService openAIService;
        private readonly SentimentService sentimentService;
        public MoviesController(ApplicationDbContext context, OpenAIService openAIServiceParam, SentimentService sentimentServiceParam)
        {
            _context = context;
            openAIService = openAIServiceParam;
            sentimentService = sentimentServiceParam;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var actors = await openAIService.GenerateActorListAsync(movie.Title);
            var reviews = await openAIService.GenerateReviewsAsync(movie.Title);

            var sentiments = sentimentService.AnalyzeSentimentsReviews(reviews);

            double sentimentAverage = sentiments.Values.Sum(r => r.Sentiment) / sentiments.Count;

            var model = new MovieDetailsViewModel
            {
                Movie = movie,
                Actors = actors,
                Reviews = sentiments.Values.ToList(), 
                SentimentAverage = Math.Round(sentimentAverage, 4)
            };

            return View(model);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IMDb,Genre,Year")] Movie movie, IFormFile? Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null && Photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Photo.CopyToAsync(memoryStream);
                        movie.Photo = memoryStream.ToArray();  
                    }
                }

                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,IMDb,Genre,Year")] Movie movie, IFormFile? Photo)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Photo != null && Photo.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await Photo.CopyToAsync(memoryStream);
                            movie.Photo = memoryStream.ToArray();  
                        }
                    }
                    else
                    {
                        // If no new photo is uploaded, keep the existing photo
                        var existingMovie = await _context.Movie.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                        movie.Photo = existingMovie?.Photo;
                    }

                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
