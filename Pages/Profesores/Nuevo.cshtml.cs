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
    public class NuevoModel : PageModel
    {
        private readonly IProfesorServicio _profService; 
        private readonly IMateriaServicio _mateService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public NuevoModel(IProfesorServicio profServicio,IMateriaServicio mateServicio,IWebHostEnvironment hostingEnviroment){
            _profService=profServicio;
            _mateService=mateServicio;
            _hostingEnvironment=hostingEnviroment;
        }
    
        [BindProperty]
        public Profesor ProfesorNuevo {get;set;}
        public void OnGet()
        {
        }

        public IActionResult OnPost(){
            if (ModelState.IsValid)
            {
                if(ProfesorNuevo.Foto!=null){
                    string carpetaFotos=Path.Combine(_hostingEnvironment.WebRootPath,"images");
                    string nombreArchivo=ProfesorNuevo.Foto.FileName;
                    string rutaCompleta=Path.Combine(carpetaFotos,nombreArchivo);
                    //subimos la imagen al servidor
                    ProfesorNuevo.Foto.CopyTo(new FileStream(rutaCompleta,FileMode.Create));
                    //guardar la ruta de la imagen en la base de datos
                    ProfesorNuevo.FotoRuta=nombreArchivo;
                }
                _profService.Add(ProfesorNuevo);
                return RedirectToPage("Listado");
            }
            return Page();
        }
    }
}
