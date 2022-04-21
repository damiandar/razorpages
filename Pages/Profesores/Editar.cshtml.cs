using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyPage1.Model;
using ProyPage1.Servicios;
 
using Microsoft.AspNetCore.Mvc.Rendering;

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ProyPage1.Pages.Profesores
{
    public class EditarModel : PageModel
    {
        private readonly IProfesorServicio _profService; 
        private readonly IMateriaServicio _mateService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EditarModel(IProfesorServicio profServicio,IMateriaServicio mateServicio,IWebHostEnvironment hostingEnviroment){
            _profService=profServicio;
            _mateService=mateServicio;
            _hostingEnvironment=hostingEnviroment;
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
             if(profesor.Foto!=null){
                string carpetaFotos=Path.Combine(_hostingEnvironment.WebRootPath,"images");
                string nombreArchivo=profesor.Foto.FileName;
                string rutaCompleta=Path.Combine(carpetaFotos,nombreArchivo);
                //subimos la imagen al servidor
                profesor.Foto.CopyTo(new FileStream(rutaCompleta,FileMode.Create));
                //guardar la ruta de la imagen en la base de datos
                profesor.FotoRuta=nombreArchivo;
            }
           _profService.Modificar(profesor);
           //var profe2=profesor;
           return RedirectToPage("Listado");
       }



    }
}
