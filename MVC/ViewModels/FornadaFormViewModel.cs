using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.ViewModels
{
    public class FornadaFormViewModel
    {
        public int? Id { get; set; }

        [Required, StringLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Range(0, 24)]
        public int Hora { get; set; }

        [Required]
        [Range(0, 60)]
        public int Minuto { get; set; }

        public FornadaFormViewModel()
        {
            Id = 0;
        }

        public FornadaFormViewModel(Fornada fornada)
        {
            Id = fornada.Id;
            Descricao = fornada.Descricao;
            Hora = fornada.DataHora.Hour;
            Minuto = fornada.DataHora.Minute;
        }

        public string Title
        {
            get
            {
                return Id != 0 ? "Editar Fornada" : "Nova Fornada";
            }
        }
    }
}