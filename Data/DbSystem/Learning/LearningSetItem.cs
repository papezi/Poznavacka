using Poznavacka.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Poznavacka.Data.DbSystem.Learning
{
    public class LearningSetItem
    {

        public int LearningSetItemID { get; set; }

        public int LearningSetID { get; set; }
        public LearningSet LearningSet { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Jméno")]
        public string Name { get; set; }

        [MaxLength(1000), Display(Name = "Popis")]
        public string Description { get; set; }

        [MaxLength(1000), Display(Name = "Zařazení")]
        public string Classification { get; set; }

        [MaxLength(200), Display(Name = "Velikost")]
        public string Size { get; set; }

        [MaxLength(500), Display(Name = "Využití")]
        public string Use { get; set; }

        [MaxLength(1000), Display(Name = "Výskyt ve světě")]
        public string OccurencesWorld { get; set; }

        [MaxLength(1000), Display(Name = "Ekosystémy")]
        public string Ecosystems { get; set; }

        [EnumDataType(typeof(OccurenceCREnum)), Display(Name = "Výskyt ČR")]
        public OccurenceCREnum OccurenceCR { get; set; }

        [MaxLength(50), Display(Name = "Ochrana")]
        public string Protection { get; set; }

        [MaxLength(50), Display(Name = "Funkce v ekosystému")]
        public string EcoFunction { get; set; }

        [MaxLength(500)]
        public string ImgPath { get; set; }

        [MaxLength(1000), Display(Name = "Popis obrázku")]
        public string ImgDescription { get; set; }
    }
}
