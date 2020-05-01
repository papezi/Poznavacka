using Poznavacka.Data.DbSystem;
using Poznavacka.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poznavacka.Areas.ContentItems.Models.ViewModels
{
    public class OrganismData : OrganismClassification
    {
        [MaxLength(50), Required]
        [Display(Name = "Název")]
        public string Name { get; set; }

        [MaxLength(1000), Display(Name = "Popis")]
        public string Description { get; set; }

        [MaxLength(200), Display(Name = "Velikost")]
        public string Size { get; set; }

        [MaxLength(500), Display(Name = "Využití")]
        public string Use { get; set; }

        [Display(Name = "Výskyt ve světě")]
        public OccurenceWorldEnum[] OccurencesWorld { get; set; }

        [Display(Name = "Ekosystémy")]
        public EcosystemEnum[] Ecosystems { get; set; }

        [EnumDataType(typeof(OccurenceCREnum)), Display(Name = "Výskyt ČR")]
        public OccurenceCREnum OccurenceCR { get; set; }

        [EnumDataType(typeof(ProtectionEnum)), Display(Name = "Ochrana")]
        public ProtectionEnum Protection { get; set; }

        [EnumDataType(typeof(EcosystemFunctionEnum)), Display(Name = "Funkce v ekosystému")]
        public EcosystemFunctionEnum EcoFunction { get; set; }

        public ICollection<ImgDb> Imgs { get; set; }

    }
}
