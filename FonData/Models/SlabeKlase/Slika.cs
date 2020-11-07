using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models.SlabeKlase
{
    public class Slika
    {
        [Key, ForeignKey("Id")]
        public StudentskaOrganizacija StudentskaOrganizacija { get; set; }
        [Key]
        public int SlikaId { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Namena { get; set; }
        public string Napomena { get; set; }
    }
}
