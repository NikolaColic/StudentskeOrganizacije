using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models.SlabeKlase
{
    public class Post
    {
        [Key, ForeignKey("Id")]
        public StudentskaOrganizacija StudentskaOrganizacija { get; set; }
        [Key]
        public int PostId { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public string Naslov { get; set; }
        [Required]
        public string Sadrzaj { get; set; }

    }
}
