using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Nome { get; set; }

        [Required, StringLength(255)]
        public string Email { get; set; }

        [Required, StringLength(255)]
        public string Endereco { get; set; }
    }
}