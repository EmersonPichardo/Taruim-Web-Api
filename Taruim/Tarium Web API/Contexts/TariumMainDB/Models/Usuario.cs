﻿namespace Tarium_Web_API.Contexts.TariumMainDB.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

        public int Rol { get; set; }
    }
}
