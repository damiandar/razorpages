using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyPage1.Model;
using ProyPage1.Servicios;
 
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyPage1.Pages.Profesores
{
    public class EditarModel : PageModel
    {
        private IProfesorServicio _profService; 
        private IMateriaServicio _mateService;

        public EditarModel(IProfesorServicio profServicio,IMateriaServicio mateServicio){
            _profService=profServicio;
            _mateService=mateServicio;
        }
    
        [BindProperty]
        public Profesor profesor {get;set;}
        public void OnGet(int leg)
        {
            var materias=_mateService.GetAll();
            ViewData["Materias"] =new SelectList(materias,"Id", "Descripcion");
            ViewData["MateriasDirecto"]=materias;
            

            profesor=_profService.GetAll().Where(x=>x.Legajo==leg).First();
        }

        public IActionResult OnPost(  ){
           _profService.Modificar(profesor);
           //var profe2=profesor;
           return RedirectToPage("Listado");
       }
    }
}
