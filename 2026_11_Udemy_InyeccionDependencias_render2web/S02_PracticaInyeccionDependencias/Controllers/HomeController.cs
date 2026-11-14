using Microsoft.AspNetCore.Mvc;
using PracticaInyeccionDependencias.Datos;
using PracticaInyeccionDependencias.Datos.Interfaces;
using PracticaInyeccionDependencias.Models;
using System.Diagnostics;

namespace PracticaInyeccionDependencias.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicioCiudades _ciudades;
        private readonly IServicioCiudades _ciudades2;
        private readonly IServicioCiudades _ciudades3;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        //Constructor Injection
        public HomeController(IServicioCiudades ciudades, 
            IServicioCiudades ciudades2, IServicioCiudades ciudades3, IServiceScopeFactory serviceScopeFactory)
        {
            //PROBLEMA - Dependencia directa
            //_ciudades = new ServicioCiudades();
            //_ciudades = null;//Crear el objeto
            _ciudades = ciudades; //Objeto desde el contenedor IoC IServiceCollection
            _ciudades2 = ciudades2;
            _ciudades3 = ciudades3;
            _serviceScopeFactory=serviceScopeFactory;
        }

        ////Method Injection
        public IActionResult Index(/*[FromServices] IServicioCiudades _ciudades*/)
        {
            List<string> ciudades = _ciudades.GetCiudades();

            //Enviar a la vista como viewbag
            ViewBag.InstanciaIdServicio1 = _ciudades.IdServicio;
            ViewBag.InstanciaIdServicio2 = _ciudades2.IdServicio;
            ViewBag.InstanciaIdServicio3 = _ciudades3.IdServicio;

            //Child Scoped o Alcance anidado
            using (IServiceScope alcance = _serviceScopeFactory.CreateScope())
            {
                //Inyecta el servicio
                IServicioCiudades servicioCiudades = alcance.ServiceProvider.GetRequiredService<IServicioCiudades>();
                //Funcionalidad de enviar a la vista
                ViewBag.InstanciaIdServicioChildScope = servicioCiudades.IdServicio;
            }//Aquí ser cierra automaticamente el alcance, se llama al ServicioCiudades.Dispose()


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