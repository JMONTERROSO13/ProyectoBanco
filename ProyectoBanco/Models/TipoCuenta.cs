using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;  

namespace ProyectoBanco.Models
{
    public class TipoCuenta
    {
        [Key]
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
    }
}