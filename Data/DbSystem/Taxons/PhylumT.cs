using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poznavacka.Data.DbSystem.Taxons
{
    /// <summary>
    /// Kmen
    /// </summary>
    public class PhylumT
    {
        public int PhylumTID { get; set; }
        [MaxLength(50), Required]
        [Display(Name = "Kmen")]
        public string Name { get; set; }
        public int KingdomTID { get; set; }
        public KingdomT KingdomT { get; set; }
        public ICollection<ClassT> Classes { get; set; }
    }
}
