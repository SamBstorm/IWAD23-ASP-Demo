using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Demo_DBSlide.Repositories;
using BLL_Demo_DBSlide.Entities;
using ASP_Demo_DBSlide.Models;
using ASP_Demo_DBSlide.Handlers;

namespace ASP_Demo_DBSlide.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository<Student> _studentRepository;
        private readonly ISectionRepository<Section> _sectionRepository;
        public StudentController(IStudentRepository<Student> studentRepository, ISectionRepository<Section> sectionRepository)
        {
            _studentRepository = studentRepository;
            _sectionRepository = sectionRepository;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            IEnumerable<StudentListItemViewModel> model = _studentRepository.Get().Select(d => d.ToListItem());
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreateForm form)
        {
            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Pas de données reçues");
                if (!ModelState.IsValid) throw new Exception();
                int id = _studentRepository.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
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

        [HttpGet]
        public IActionResult ChangeSection(int id)
        {
            StudentChangeSectionForm model = _studentRepository.Get(id).ToChangeSection();
            if(model is null) throw new ArgumentOutOfRangeException(nameof(id), $"Pas d'étudiant avec l'identifiant {id}");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeSection(int id, StudentChangeSectionForm form)
        {
            try
            {
                if(form is null) ModelState.AddModelError(nameof(form), "Pas de données reçues");
                Student data = _studentRepository.Get(id);
                if (data is null) ModelState.AddModelError(nameof(id), "Pas d'étudiant avec cet identifiant");
                form.First_name = data.First_name;
                form.Last_name = data.Last_name;
                Section section = _sectionRepository.Get(form.Section_id);
                if (section is null) ModelState.AddModelError(nameof(form.Section_id), "Pas de section avec cet identifiant");
                if (!ModelState.IsValid) throw new Exception();
                data.ChangeSection(section);
                _studentRepository.Update(data);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception)
            {
                return View(form);
            }
        }
    }
}
