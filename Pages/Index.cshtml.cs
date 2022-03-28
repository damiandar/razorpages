using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProyPage1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Alumno alumno {get;set;}
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost(string param1)
        {
            
        }
        public void OnPostAlumnoFormulario(string param1)
        {
            
        }
    }
    public class Alumno{
        public int DNI {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
    }
}
