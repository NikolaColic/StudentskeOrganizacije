using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FonData.Models.AsocijativneKlase
{
    public class DrustveneOrganizacija
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DrustvenaMreza DrustvenaMreza { get; set; }
        [Required]
        public StudentskaOrganizacija StudentskaOrganizacija { get; set; }

        public string Url { get; set; }

    }
}
