using ProyPage1.Model;
using System.Collections.Generic;

namespace ProyPage1.Servicios
{
    public class ProfesorServicio : IProfesorServicio
    {
        private List<Profesor> Profesores;
        public ProfesorServicio(){
          Profesores=new List<Profesor>(){
                new Profesor(){ Legajo=1111111, Nombre="Damian", Apellido="Rosso"},
                new Profesor(){ Legajo=2222222, Nombre="Analia", Apellido="Manfredi"},
            };
        }
        public IEnumerable<Profesor> GetAll(){
            return Profesores;
        }  
        public void Add(Profesor profesor){
             //mobile.id = _mobileList.Max(e => e.id) + 1;
            //_mobileList.Add(mobile);
            //return mobile;
            Profesores.Add(profesor);
        }
    }
}