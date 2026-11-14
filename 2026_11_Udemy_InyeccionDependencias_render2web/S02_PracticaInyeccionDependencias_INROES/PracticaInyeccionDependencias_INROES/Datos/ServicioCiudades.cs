using PracticaInyeccionDependencias_INROES.Datos.Interfaces;

namespace PracticaInyeccionDependencias_INROES.Datos
{
    public class ServicioCiudades : IServicioCiudades, IDisposable
    {
        private List<string> _ciudades;

    //IdServicio es un identificador único para cada instancia de la clase ServicioCiudades. Se utiliza para demostrar que cada vez que se crea una nueva instancia de ServicioCiudades, se genera un nuevo GUID, lo que permite diferenciar entre diferentes instancias del servicio.
    private Guid idServicio;
        public Guid IdServicio
        {
            get { 
                return idServicio;
            }
        }

        public ServicioCiudades()
        {
            idServicio = Guid.NewGuid();
            _ciudades = new List<string>()
            {
                "Madrid",
                "Barcelona",
                "Valencia",
                "Sevilla",
                "Zaragoza"
            };

            //Aquí agregar funcionalidad para abrir conexión a BD
        }


        public List<string> GetCiudades()
        {
            return _ciudades;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            //Aquí se cerraría la conexion a la BD
        }
    }
}
