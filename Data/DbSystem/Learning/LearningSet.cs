using Poznavacka.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poznavacka.Data.DbSystem.Learning
{
    public class LearningSet
    {
        public int LearningSetID { get; set; }

        public ICollection<LearningSetItem> Items { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Název")]
        public string Name { get; set; }

        [MaxLength(1000), Display(Name = "Popis")]
        public string Description { get; set; }

        [Display(Name = "Počet položek")]
        public int NumberOfItems { get; set; }

        [Display(Name = "Třída"), Required]
        public sbyte Class { get; set; }

        [EnumDataType(typeof(OccurenceCREnum)), Display(Name = "Výskyt ČR")]
        public OccurenceCREnum OccurenceCR { get; set; }
    }
}
