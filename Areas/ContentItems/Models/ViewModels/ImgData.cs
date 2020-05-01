using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem;
using Poznavacka.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.ViewModels
{
    public class ImgData : OrganismClassification
    {
        [Required]
        public IFormFile ImgFile { get; set; }

        [MaxLength(100), Display(Name = "Název obrázku")]
        public string ImgName { get; set; }

        [MaxLength(1000), Display(Name = "Popis obrázku")]
        [DisplayFormat(NullDisplayText = "Bez popisku")]
        public string ImgDescription { get; set; }

        [Display(Name = "Obsah obrázku")]
        public ImgTypeEnum[] ImgType { get; set; }


        public async Task AddTo(OrganismDbContext _context)
        {
            string uniqueFileName = UploadFile();


            ImgDb newImg = new ImgDb()
            {
                ImgPath = uniqueFileName,
                ImgName = ImgName,
                ImgDescription = ImgDescription,
                ImgType = string.Join(", ", ImgType.Select(a => a.ToString()))
            };
            _context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .ThenInclude(i => i.Families).ThenInclude(i => i.Genusses).ThenInclude(i => i.Species)
                .ThenInclude(i => i.Imgs)
                .Single(i => i.KingdomTID == KingdomID).Phylums
                .Single(i => i.PhylumTID == PhylumID).Classes
                .Single(i => i.ClassTID == ClassID).Orders
                .Single(i => i.OrderTID == OrderID).Families
                .Single(i => i.FamilyTID == FamilyID).Genusses
                .Single(i => i.GenusTID == GenusID).Species
                .Single(i => i.SpeciesTID == SpeciesID).Imgs
                .Add(newImg);
            await _context.SaveChangesAsync();
        }

        private string UploadFile()
        {
            string uniqueFileName = null;

            if (ImgFile != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgFile.FileName);
                string filePath = Path.Combine("wwwroot/Images", uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ImgFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task Delete(OrganismDbContext _context)
        {
            _context.Remove(_context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .ThenInclude(i => i.Families).ThenInclude(i => i.Genusses).ThenInclude(i => i.Species)
                .ThenInclude(i => i.Imgs)
                .Single(i => i.KingdomTID == KingdomID).Phylums
                .Single(i => i.PhylumTID == PhylumID).Classes
                .Single(i => i.ClassTID == ClassID).Orders
                .Single(i => i.OrderTID == OrderID).Families
                .Single(i => i.FamilyTID == FamilyID).Genusses
                .Single(i => i.GenusTID == GenusID).Species
                .Single(i => i.SpeciesTID == SpeciesID).Imgs
                .Single(i => i.ImgID == ImgID));
            await _context.SaveChangesAsync();
        }
    }
}
