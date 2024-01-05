using Microsoft.AspNetCore.Mvc;

namespace Asp_Exo01_Routing.Controllers
{
    public class ElevesController : Controller
    {
        private static List<string> _students = new List<string>() { "Elena", "Hélène" };
        private readonly ILogger<ElevesController> _logger;

        public ElevesController(ILogger<ElevesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Liste");
        }

        public string Liste()
        {
            string result = "";
            foreach (string name in _students)
            {
                result += name + "\n";
            }
            return result;
        }

        //[Route("Eleves/{name}")]
        [Route("Eleves/Check/{name}")]
        [Route("Eleves/{name}/Existe")]
        public void Check(string name)
        {
            if (_students.Contains(name)) _logger.LogInformation($"L'élève {name} est bien présent.");
            else _logger.LogError($"L'élève {name} n'est pas présent.");
        }

        [Route("Eleves/Ajout/{name}")]
        public void Ajout(string name)
        {
            _students.Add(name);
            _logger.LogInformation(_students.Count.ToString());
        }
    }
}
