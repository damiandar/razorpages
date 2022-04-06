using ProyPage1.Model;
using System.Collections.Generic;

namespace ProyPage1.Servicios
{
    public interface IMateriaServicio
    {
  
        public IEnumerable<Materia> GetAll();   
        public void Add(Materia materia);
        void Eliminar(Materia materia);
        void Modificar(Materia materia);
    }
}