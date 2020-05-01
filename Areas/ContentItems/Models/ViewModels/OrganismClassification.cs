using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.ViewModels
{
    public class OrganismClassification
    {
        public string Taxon { get; set; }
        public int? KingdomID { get; set; }
        public int? PhylumID { get; set; }
        public int? ClassID { get; set; }
        public int? OrderID { get; set; }
        public int? FamilyID { get; set; }
        public int? GenusID { get; set; }
        public int? SpeciesID { get; set; }
        public int? ImgID { get; set; }
    }
}
