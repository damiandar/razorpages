using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProyPage1
{
    public class Model : PageModel
    {
        [BindProperty]
        public List<Alumno> Alumnos 
        {
            get;set;
        }
        public  List<Alumno> ListaAlumnos=new List<Alumno>{
            new Alumno(){DNI=11111111,Nombre="Laura",Apellido="Alonso"},
            new Alumno(){DNI=22222222,Nombre="Marina",Apellido="Lopez"},
            new Alumno(){DNI=33333333,Nombre="Juan",Apellido="Martinez"},
        };
        public void OnGet()
        {
            Alumnos=ListaAlumnos;
        }
    }
    public class Alumno{
        public int DNI {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
    }
}
