namespace PracticaInyeccionDependencias_INROES.Datos.Interfaces
{
    public interface IServicioCiudades
    {
        Guid IdServicio { get; }
        List<String> GetCiudades();
    }
}
