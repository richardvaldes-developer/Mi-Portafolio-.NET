using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPortafolioRichard.Data;
using ProyectoPortafolioRichard.Models;

namespace ProyectoPortafolioRichard.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ExperienceController
        public ActionResult Index()
        {

            var experience = _context.Experience.ToList();
            return View(experience);
        }

        // GET: ExperienceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExperienceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperienceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExperienceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExperienceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExperienceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExperienceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
