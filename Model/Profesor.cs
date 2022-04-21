using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProyPage1.Model{
    public class Profesor{

        [Required]
        [Range(1111111, 9999999)]
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
        public Materia MateriaDictada {get;set;}
        public int MateriaDictada_Id {get;set;}

        public string FotoRuta {get;set;}
        [NotMapped()]
        public IFormFile Foto {get;set;}
        /*
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required, Compare(nameof(Password))]
        public string Password2 { get; set; }
        */
    }
}