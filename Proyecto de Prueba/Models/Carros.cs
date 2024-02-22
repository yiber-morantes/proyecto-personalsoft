namespace Proyecto_de_Prueba.Models
{
    public class Carros
    {
        public int IdCarro { get; set; }
        public string PlacaCarro { get; set; }
        public string ModeloCarro { get; set; }
        public Ciudad CiudadRecogida { get; set; }
        public Ciudad CiudadDevolucion { get; set; }
        public bool Activo { get; set; }
    }
}
