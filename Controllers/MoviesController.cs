using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Identity_Movie.Data;
using MVC_Identity_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace MVC_Identity_Movie.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
   
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            // return View(await _context.Movie.ToListAsync());
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return PartialView("_Search", await _context.Movie.ToListAsync());
            }
            else
            {
                return PartialView("_Search", await _context.Movie.Where(movie =>
                movie.Title.Contains(search)).ToListAsync());
            }
        }


        [AllowAnonymous]
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

            return View(movie);
        }


        [Authorize(Roles = "Administrator")]
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
        public async Task<IActionResult> Create([Bind("Id,Title,Director,ReleaseDate,Genre,Description,Rating,FileName,FileForm")] Movie movie)
        {


            if (movie.FileForm != null)
            {
                var memoryStream = new MemoryStream();
                movie.FileForm.CopyTo(memoryStream);
                movie.FileName = movie.FileForm.FileName;
                movie.File = memoryStream.ToArray();
            }
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        [Authorize]
      
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Director,ReleaseDate,Genre,Description,Rating,FileName,FileForm")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            var existingMovie = await _context.Movie.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            if (movie.FileForm != null)
            {
                using var memoryStream = new MemoryStream();
                movie.FileForm.CopyTo(memoryStream);
                movie.FileName = movie.FileForm.FileName;
                movie.File = memoryStream.ToArray();
            }
            else
            {
                // Retain the existing file data from the database
                movie.FileName = existingMovie.FileName;
                movie.File = existingMovie.File;
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Details), new { id = movie.Id });
            }
            return View(movie);
        }

        [Authorize(Roles = "Administrator")]
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
