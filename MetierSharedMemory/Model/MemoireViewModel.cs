using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Model
{
    public class MemoireViewModel
    {
        public int IdMemoire { get; set; }
        public string Sujet { get; set; }
        public string FileName { get; set; }
        public int Annee { get; set; }
        public int? IdEncadreur { get; set; }
        public string Encadreur { get; set; }
    }
}