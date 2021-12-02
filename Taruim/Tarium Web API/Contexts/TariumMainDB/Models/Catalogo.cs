namespace Tarium_Web_API.Contexts.TariumMainDB.Models
{
    public class Catalogo
    {
        public int Id { get; set; }

        public int Id_Sucursal { get; set; }

        public int Id_Producto { get; set; }

        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
    }
}
