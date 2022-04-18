using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyPage1.Model;
using ProyPage1.Servicios;

namespace ProyPage1.Pages.Profesores
{
    public class EditarModel : PageModel
    {
        private IProfesorServicio _profService; 

        public EditarModel(IProfesorServicio profServicio){
            _profService=profServicio;
        }
    
        [BindProperty]
        public Profesor profesor {get;set;}
        public void OnGet(int leg)
        {
            profesor=_profService.GetAll().Where(x=>x.Legajo==leg).First();
        }

        public IActionResult OnPost(  ){
           _profService.Modificar(profesor);
           //var profe2=profesor;
           return RedirectToPage("Listado");
       }
    }
}
