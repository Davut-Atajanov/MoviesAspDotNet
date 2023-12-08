#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class DirectorsController : Controller
    {
        // Add service injections here
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        // GET: Directors
        public IActionResult Index()
        {
            List<DirectorModel> directorList= _directorService.Query().ToList();
            return View(directorList);
        }

        // GET: Directors/Details/5
        public IActionResult Details(int id)
        {
            DirectorModel director = _directorService.Query().SingleOrDefault(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "Name");
            return View();
        }

        // POST: Directors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DirectorModel director)
        {
            if (ModelState.IsValid)
            {
                bool result = _directorService.Add(director);
                if (result)
                {
                    TempData["Message"] = "Director added successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Director couldn't be added!");
            }
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "Name");
            return View(director);
        }

        // GET: Directors/Edit/5
        public IActionResult Edit(int id)
        {
            DirectorModel director = _directorService.Query().SingleOrDefault(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "Name");
            return View(director);
        }

        // POST: Directors/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DirectorModel director)
        {
            if (ModelState.IsValid)
            {
                bool result = _directorService.Update(director);
                if (result)
                {
                    TempData["Message"] = "Director updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Director couldn't be updated!");
            }
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "Name");
            return View(director);
        }

        // GET: Directors/Delete/5
        public IActionResult Delete(int id)
        {
            bool result = _directorService.Delete(id);

            if (result)
                TempData["Message"] = "Director deleted successfully.";
            else
                TempData["Message"] = "Director cannot be deleted because they have Movies.";
            return RedirectToAction(nameof(Index));
        }

        // POST: Directors/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _directorService.Delete(id);
            TempData["Message"] = " deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
	}
}
