using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models.SlabeKlase
{
    public class Projekat
    {
        [Key, ForeignKey("Id")]
        public StudentskaOrganizacija StudentskaOrganizacija { get; set; }
        [Key]
        public int ProjekatId { get; set; }
        [Required]
        public string NazivProjekta { get; set; }
        [Required]
        public string Opis { get; set; }
        public string UrlProjekta { get; set; }
        public string PeriodOdrzavanja { get; set; }



    }
}
