namespace Tarium_Web_API.Contexts.TariumMainDB.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Id_Sucursal { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }

        public Producto Producto { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
