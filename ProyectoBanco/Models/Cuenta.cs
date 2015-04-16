using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBanco.Models
{
    public class Cuenta
    {
        [Required]
        [Key]
        public int Id { get; set; }


        [StringLength(10, MinimumLength = 7)]
        public string Cuenta { get; set; }

        public int IdTipo { get; set; }
        public TipoCuenta TipoCuenta { get; set; }


        public int saldo { get; set; }
        
        public int IdPersona{ get; set; }
        public Persona Persona { get; set; }
    }
}