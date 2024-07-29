using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Model
{
    public class test
    {
        [Key]
        public int IdPersonne { get; set; }
        [Display(Name = "Nom")]
        [MaxLength(80, ErrorMessage = "La taille minimale est de 80"), Required(ErrorMessage = "*")]
        public string Nom { get; set; }
        [Display(Name = "Prenom")]
        [MaxLength(80, ErrorMessage = "La taille minimale est de 80"), Required(ErrorMessage = "*")]
        public string Prenom { get; set; }
    }
}