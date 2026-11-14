using PracticaInyeccionDependencias.Datos.Interfaces;

namespace PracticaInyeccionDependencias.Datos
{
    public class ServicioCiudadesV2 : IServicioCiudades
    {
        private List<string> _ciudades;

        //Id Servicio
        private Guid idServicio;

        public Guid IdServicio
        {
            get { return idServicio; }
        }

        public ServicioCiudadesV2()
        {
            idServicio = Guid.NewGuid();

            _ciudades = new List<string>
            {
                "Zúrich",
                "Los Ángeles",
                "Shanghai",
                "París",
                "Madrid",
                "Ciudad de México",
                "Rio de Janeiro"
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
