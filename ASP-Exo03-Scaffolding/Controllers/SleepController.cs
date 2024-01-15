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
            SleepDetailsViewModel model;
            try
            {
                model = _sleeps.SingleOrDefault(data => data.Id == id).ToDetails();
                if (model is null) throw new InvalidDataException();
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = $"Identifiant {id} invalide...";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: SleepController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SleepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SleepCreateForm form)
        {
            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Pas de formulaire valide");
                if (!ModelState.IsValid) throw new Exception();
                SleepModel data = form.ToData();
                data.Id = _sleeps.Max(d => d.Id) + 1;
                _sleeps.Add(data);
                TempData["SuccessMessage"] = "Enregistrement effectué avec succès!";
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
            try
            {
                SleepEditForm model = _sleeps.SingleOrDefault(d => d.Id == id).ToEdit();
                if (model is null) throw new InvalidDataException();
                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = $"Identifiant {id} invalide...";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SleepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SleepEditForm form)
        {
            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Pas de formulaire valide");
                if (!ModelState.IsValid) throw new Exception();
                SleepModel data = form.ToData();
                data.SleepStart = _sleeps.SingleOrDefault(d => d.Id == data.Id).SleepStart;
                data.SleepEnd = _sleeps.SingleOrDefault(d => d.Id == data.Id).SleepEnd;
                data.HaveSnored = _sleeps.SingleOrDefault(d => d.Id == data.Id).HaveSnored;
                _sleeps.Remove(_sleeps.SingleOrDefault(d => d.Id == id));
                _sleeps.Add(data);
                TempData["SuccessMessage"] = $"L'enregistrement {id} a été mis à jour.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(form);
            }
        }

        // GET: SleepController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SleepDeleteForm model = _sleeps.SingleOrDefault(d => d.Id == id).ToDelete();
                if (model is null) throw new InvalidDataException();
                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = $"L'identifiant {id} est invalide...";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SleepController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SleepDeleteForm form)
        {
            try
            {
                _sleeps.Remove(_sleeps.SingleOrDefault(d => d.Id == id));
                TempData["SuccessMessage"] = $"L'enrgistrement {id} a été supprimé";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(form);
            }
        }
    }
}
