using System;
namespace ProyectoCiclo3.App.Dominio{
    public class Rutas{
        public int id { get; set; }
        public Aeropuertos origen { get; set; }
        public Aeropuertos destino { get; set; }
        public int tiempo_estimado { get; set; }
    } 
}