using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyPage1.Servicios;
using ProyPage1.Model;

namespace ProyPage1.Pages.Profesores
{
    public class ListadoModel : PageModel
    {
        [BindProperty]
        public List<Profesor> Profesores{get;set;}
         private IProfesorServicio _profServicio;

        public ListadoModel(IProfesorServicio profServicio){
            _profServicio=profServicio;
        }
        public void OnGet()
        {
            Profesores=_profServicio.GetAll().ToList();
        }

        public void OnGetDelete(int legajoborrar){
            var ProfesorBuscado=_profServicio.GetAll().Where(x=> x.Legajo==legajoborrar).First();
            _profServicio.Eliminar(ProfesorBuscado);
            Profesores=_profServicio.GetAll().ToList();
        }
    }
}
