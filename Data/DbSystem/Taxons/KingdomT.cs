using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poznavacka.Data.DbSystem.Taxons
{
    /// <summary>
    /// Říše
    /// </summary>
    public class KingdomT
    {
        public int KingdomTID { get; set; }
        [MaxLength(50), Required]
        [Display(Name = "Říše")]
        public string Name { get; set; }
        [Display(Name = "Kmeny")]
        public ICollection<PhylumT> Phylums { get; set; }
    }
}
