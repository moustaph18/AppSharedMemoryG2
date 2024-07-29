using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierSharedMemory.Model
{
    public class Encadreur:Personne
    {
       
        [Display(Name = "Specialite de l'encadreur")]
        [MaxLength(80, ErrorMessage = "La taille minimale est de 80"), Required(ErrorMessage = "*")]
        public string Specialite { get; set; }
    }
}