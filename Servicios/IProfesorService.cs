using ProyPage1.Model;
using System.Collections.Generic;

namespace ProyPage1.Servicios
{
    public interface IProfesorServicio
    {
  
        public IEnumerable<Profesor> GetAll();   
        public void Add(Profesor profesor);
        void Eliminar(Profesor profesor);
        void Modificar(Profesor profesor);
    }
}