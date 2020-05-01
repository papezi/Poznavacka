using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poznavacka.Data.DbSystem.Taxons
{
    /// <summary>
    /// Rod
    /// </summary>
    public class GenusT
    {
        public int GenusTID { get; set; }
        [MaxLength(50), Required]
        [Display(Name = "Rod")]
        public string Name { get; set; }
        public int FamilyTID { get; set; }
        public FamilyT FamilyT { get; set; }
        public ICollection<SpeciesT> Species { get; set; }
    }
}
