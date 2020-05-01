using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poznavacka.Data.DbSystem.Taxons
{
    /// <summary>
    /// Čeleď
    /// </summary>
    public class FamilyT
    {
        public int FamilyTID { get; set; }
        [MaxLength(50), Required]
        [Display(Name = "Čeleď")]
        public string Name { get; set; }
        public int OrderTID { get; set; }
        public OrderT OrderT { get; set; }
        public ICollection<GenusT> Genusses { get; set; }
    }
}
