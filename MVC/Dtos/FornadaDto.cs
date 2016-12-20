using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Dtos
{
    public class FornadaDto
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        public bool Futura { get; set; }
    }
}