using Poznavacka.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Poznavacka.Data.DbSystem.EnumClasses;

namespace Poznavacka.Data.DbSystem.Taxons
{
    /// <summary>
    /// Druh
    /// </summary>
    public class SpeciesT
    {
        public int SpeciesTID { get; set; }
        public int GenusTID { get; set; }
        public GenusT GenusT { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Druh")]
        public string Name { get; set; }

        [MaxLength(1000), Display(Name = "Popis")]
        public string Description { get; set; }

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

        [EnumDataType(typeof(ProtectionEnum)), Display(Name = "Ochrana")]
        public ProtectionEnum Protection { get; set; }

        [EnumDataType(typeof(EcosystemFunctionEnum)), Display(Name = "Funkce v ekosystému")]
        public EcosystemFunctionEnum EcoFunction { get; set; }

        public ICollection<ImgDb> Imgs { get; set; }
        
    }
}
