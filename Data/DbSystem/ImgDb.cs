using Poznavacka.Data.DbSystem.Taxons;
using System.ComponentModel.DataAnnotations;

namespace Poznavacka.Data.DbSystem
{
    public class ImgDb
    {
        [Key]
        public int ImgID { get; set; }

        [MaxLength(1000), Required]
        public string ImgPath { get; set; }

        [MaxLength(100), Required]
        public string ImgName { get; set; }

        [MaxLength(1000), Display(Name = "Popis obrázku")]
        [DisplayFormat(NullDisplayText = "Bez popisku")]
        public string ImgDescription { get; set; }

        [MaxLength(1000), Display(Name = "Obsah obrázku")]
        public string ImgType { get; set; }

        public int SpeciesTID { get; set; }
        public SpeciesT SpeciesT { get; set; }
    }
}
