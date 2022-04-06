using System;
using System.ComponentModel.DataAnnotations;

namespace ProyPage1.Model{
    public class Profesor{

        [Required]
        [Range(111111, 999999)]
        public int Legajo{get;set;}
        [Required,MaxLength(20)]
        public string Nombre {get;set;}
        [Required]
        [MaxLength(20)]
        public string Apellido {get;set;}
        public bool Activo {get;set;}
        [Required(ErrorMessage ="Debe ingresar la fecha de nacimiento")]
        public DateTime FechaNacimiento {get;set;}
        [Range(1,3)]
        public int EstudioTipo {get;set;}

        /*
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required, Compare(nameof(Password))]
        public string Password2 { get; set; }
        */
    }
}