using System;

namespace Tarium_Web_API.Contexts.TariumMainDB.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public string CodigoBarra { get; set; }

        public string Nombre { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public int? Id_Proveedor { get; set; }

        public Proveedor Proveedor { get; set; }

        public string Comentario { get; set; }

        public string Estado { get; set; }
    }
}
