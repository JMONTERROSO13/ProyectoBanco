﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBanco.Models
{
    public class Persona
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(13)]
        [RegularExpression(@"^[0-9]", ErrorMessage = "Un DPI Correcto")]
        public string  Dpi { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Apellido { get; set; }
        
        [StringLength(200, MinimumLength = 20)]
        public string direccion{ get; set; }

        [StringLength(10, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string telefono{ get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string Referencia1 { get; set; }

        [StringLength(10, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia1 { get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string Referencia2 { get; set; }

        [StringLength(12, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ingrese un numero telefonico correcto")]
        public string TelefonoReferencia2 { get; set; }

    }
}