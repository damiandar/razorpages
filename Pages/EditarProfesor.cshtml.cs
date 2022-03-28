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
    public class EditarProfesorModel : PageModel
    {                 
        [BindProperty]
        public Profesor ProfesorBuscado {get;set;}


        private IProfesorServicio _profService;
        
        public EditarProfesorModel( IProfesorServicio profService)
        {
            _profService = profService;
        }
       public void OnGet(int leg)
       {
            ProfesorBuscado=_profService.GetAll().Where(x=>x.Legajo==leg).First();
       }
       public IActionResult OnPost(){
           _profService.Modificar(ProfesorBuscado);
           return RedirectToPage("ProfesorList");
       }
    }
}
