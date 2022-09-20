﻿using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Beneficio
    {
        [Key]
        public int BeneficioId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
