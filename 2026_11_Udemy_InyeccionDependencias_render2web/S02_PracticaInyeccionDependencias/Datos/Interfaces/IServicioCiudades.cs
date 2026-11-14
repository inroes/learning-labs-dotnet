namespace PracticaInyeccionDependencias.Datos.Interfaces
{
    public interface IServicioCiudades
    {
        Guid IdServicio { get; }
        List<string> GetCiudades();
    }
}
