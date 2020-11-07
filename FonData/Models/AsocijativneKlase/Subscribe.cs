using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models.AsocijativneKlase
{
    public class Subscribe
    {
        [Key]
        public int SubscribeId { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        public StudentskaOrganizacija StudentskaOrganizacija { get; set; }

    }
}
