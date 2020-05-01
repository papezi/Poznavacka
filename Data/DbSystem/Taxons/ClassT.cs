using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poznavacka.Data.DbSystem.Taxons
{
    /// <summary>
    /// Třída
    /// </summary>
    public class ClassT
    {
        public int ClassTID { get; set; }
        [MaxLength(50), Required]
        [Display(Name = "Třída")]
        public string Name { get; set; }
        public int PhylumTID { get; set; }
        public PhylumT PhylumT { get; set; }
        public ICollection<OrderT> Orders { get; set; }
    }
}
