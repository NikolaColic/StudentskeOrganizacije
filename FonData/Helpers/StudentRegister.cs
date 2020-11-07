using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FonData.Helpers
{
    public class StudentRegister
    {
       
        public int StudentId { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password{ get; set; }
        public string InstagramUrl { get; set; }
        public string ImageUrl { get; set; }
        public string GodinaStudija { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public bool Administrator { get; set; }
        public string Biografija { get; set; }
    }
}
