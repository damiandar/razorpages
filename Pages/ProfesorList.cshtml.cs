using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyPage1.Model;
using ProyPage1.Servicios;

namespace ProyPage1.Pages
{
    public class ProfesorListModel : PageModel
    {
        [BindProperty]
        public Profesor Profesor {get;set;}
        public List<Profesor> Profesores{get;set;}

        private IProfesorServicio _profService;
        
        public ProfesorListModel( IProfesorServicio profService)
        {
            _profService = profService;
        }


        public void OnGet(string sortOrder)
        {
            Profesores=_profService.GetAll().ToList();
            var valor=sortOrder;
            if(valor=="OrdenPorApellido"){
                Profesores=Profesores.OrderBy(x=> x.Apellido).ToList();
            }
            else if(valor=="OrdenPorNombre"){
                Profesores=Profesores.OrderBy(x=> x.Nombre).ToList();
            }

        }

        public void OnPost(){
            _profService.Add(Profesor);
        }

        
    }
}
