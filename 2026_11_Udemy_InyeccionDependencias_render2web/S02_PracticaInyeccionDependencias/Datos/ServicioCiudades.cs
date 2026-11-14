using PracticaInyeccionDependencias.Datos.Interfaces;

namespace PracticaInyeccionDependencias.Datos
{
    public class ServicioCiudades : IServicioCiudades, IDisposable
    {
        private List<string> _ciudades;

        //Id Servicio
        private Guid idServicio;

        public Guid IdServicio
        {
            get { return idServicio; }
        }

        public ServicioCiudades()
        {
            idServicio = Guid.NewGuid();

            _ciudades = new List<string>
            {
                "Bogotá",
                "Lima",
                "New York",
                "Tokyo",
                "Buenos Aires",
                "Roma",
                "Miami"
            };

            //Aquí agregar funcionalidad para abrir conexión a BD
        }

        public List<string> GetCiudades()
        {
            return _ciudades;
        }

        public void Dispose()
        {
            //Aquí se cerraría la conexion a la BD
        }
    }
}
