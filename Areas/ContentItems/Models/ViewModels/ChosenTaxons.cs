using Poznavacka.Data.DbSystem.Taxons;
using System.Collections.Generic;


namespace Poznavacka.Areas.ContentItems.Models.ViewModels
{
    public class ChosenTaxons
    {
        public IEnumerable<KingdomT> Kingdoms { get; set; }
        public KingdomT ChosenKingdom { get; set; }
        public PhylumT ChosenPhylum { get; set; }
        public ClassT ChosenClass { get; set; }
        public OrderT ChosenOrder { get; set; }
        public FamilyT ChosenFamily { get; set; }
        public GenusT ChosenGenus { get; set; }
        public SpeciesT ChosenSpecies { get; set; }
    }
}
