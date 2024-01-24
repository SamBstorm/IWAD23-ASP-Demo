using ASP_Demo_DBSlide.Handlers;
using ASP_Demo_DBSlide.Models;
using BLL_Demo_DBSlide.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Demo_DBSlide.Repositories;

namespace ASP_Demo_DBSlide.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository<Section> _sectionRepository;

        public SectionController(ISectionRepository<Section> sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        // GET: SectionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SectionController/Details/5
        public ActionResult Details(int id)
        {
            SectionDetailsViewModel model = _sectionRepository.Get(id).ToDetails();
            return View(model);
        }

        // GET: SectionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionCreateForm form)
        {
            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Aucun formulaire retourné...");
                if (!ModelState.IsValid) throw new Exception();
                int section_id = _sectionRepository.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new {id = section_id});
            }
            catch
            {
                return View();
            }
        }

        // GET: SectionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SectionController/Edit/5
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

        // GET: SectionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SectionController/Delete/5
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
