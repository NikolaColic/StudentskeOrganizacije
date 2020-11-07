using FonData.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FonData.Models.SlabeKlase
{
    #region OrganizacijaInfo
    public class OrganizacijaInfo
    {
        //[Key, ForeignKey("Id")]
        //public StudentskaOrganizacija StudentskaOrganizacija { get; set; }
        [Key]
        public int Id { get; set; }
        public string Misija { get; set; }
        public string Vizija { get; set; }
        public string Istorija { get; set; }
        public string ProjektiOpste { get; set; }
        public string Napomena { get; set; }
        


    }
    #endregion
}
