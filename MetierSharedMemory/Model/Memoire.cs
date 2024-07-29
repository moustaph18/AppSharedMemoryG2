using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierSharedMemory.Model
{
    public class Memoire
    {
        [Key]
        public int IdMemoire { get; set; }

        [Display(Name = "Sujet du memoire")]
        [MaxLength(300, ErrorMessage = "La taille minimale est de 300"), Required(ErrorMessage = "*")]
        public string Sujet { get; set; }

        [Display(Name = "Nom du fichier")]
        [MaxLength(80, ErrorMessage = "La taille minimale est de 80"), Required(ErrorMessage = "*")]
        public string FileName { get; set;}

        [Required(ErrorMessage = "*")]
        public int Annee { get; set; }

        public int? IdEncadreur { get; set; }
        [ForeignKey("IdEncadreur")]
        public Encadreur encadreur { get; set; }
    }
}