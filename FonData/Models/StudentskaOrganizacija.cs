using FonData.Helpers;
using FonData.Models.SlabeKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models
{
    #region StudentskaOrganizacija
    public class StudentskaOrganizacija
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NazivOrganizacije { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UrlSajta { get; set; }

        [ForeignKey("StudentId")]
        public Student Predsednik { get; set; }

        

        public OrganizacijaInfo OrganizacijaInfo { get; set; }
    }
    #endregion
}
