using ASP_Exo03_Scaffolding.Handlers;
using ASP_Exo03_Scaffolding.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Exo03_Scaffolding.Controllers
{
    public class SleepController : Controller
    {
        private static List<SleepModel> _sleeps = new List<SleepModel>()
        {
            new SleepModel(){ Id = 1, SleepStart = new DateTime(2024,1,14,21,30,54), SleepEnd = new DateTime(2024,1,15,5,32,00), HaveDreamed = false, IsNightmare = false, DreamDescription = null, HaveSnored = true }
        };
        // GET: SleepController
        public ActionResult Index()
        {
            IEnumerable<SleepListItemViewModel> model = _sleeps.Select(data => data.ToListItem());
            return View(model);
        }

        // GET: SleepController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SleepController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SleepController/Create
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

        // GET: SleepController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SleepController/Edit/5
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

        // GET: SleepController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SleepController/Delete/5
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
