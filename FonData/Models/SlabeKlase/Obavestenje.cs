using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models.SlabeKlase
{
    public class Obavestenje
    {
        [Key, ForeignKey("Id")]
        public StudentskaOrganizacija StudentskaOrganizacija { get; set; }
        [Key]
        public int ObavestenjeId { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        
        public string NazivObavestenja { get; set; }
        [Required]
        public string Opis { get; set; }
        [ForeignKey("MrezaId")]
        public DrustvenaMreza DrustvenaMreza { get; set; }
    }
}
