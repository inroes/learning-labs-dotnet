using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticaInyeccionDependencias_INROES.Datos.Interfaces;
using PracticaInyeccionDependencias_INROES.Models;

namespace PracticaInyeccionDependencias_INROES.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioCiudades _servicioCiudades;
        public HomeController(ILogger<HomeController> logger, IServicioCiudades servicioCiudades)
        {
            _logger = logger;
            _servicioCiudades = servicioCiudades; //Objeto desde el contenedor IoC IServiceCollection
        }

        public IActionResult Index()
        {
            List<string> ciudades = _servicioCiudades.GetCiudades();
            return View(ciudades);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
