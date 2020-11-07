using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FonData.Models
{
    public class DrustvenaMreza
    {
        [Key]
        public int MrezaId { get; set; }
        [Required]
        public string NazivMreze { get; set; }

    }
}
