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
    public class NuevoModel : PageModel
    {
        private IProfesorServicio _profServicio;

        public NuevoModel(IProfesorServicio profServicio){
            _profServicio=profServicio;
        }
    
        [BindProperty]
        public Profesor ProfesorNuevo {get;set;}
        public void OnGet()
        {
        }

        public IActionResult OnPost(){
            if (ModelState.IsValid)
            {
                _profServicio.Add(ProfesorNuevo);
                return RedirectToPage("Listado");
            }
            return Page();
        }
    }
}
