using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models.SlabeKlase
{
    public class Sektor
    {
       
        [Key]
        public int SektorId { get; set; }
        [Required]
        public string NazivSektora { get; set; }
        public string OpisSektora { get; set; }
       
    }
}
