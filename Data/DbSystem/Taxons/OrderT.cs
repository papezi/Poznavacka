using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poznavacka.Data.DbSystem.Taxons
{
    /// <summary>
    /// Řád
    /// </summary>
    public class OrderT
    {
        public int OrderTID { get; set; }
        [MaxLength(50), Required]
        [Display(Name = "Řád")]
        public string Name { get; set; }
        public int ClassTID { get; set; }
        public ClassT ClassT { get; set; }
        public ICollection<FamilyT> Families { get; set; }
    }
}
