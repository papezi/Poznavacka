using Microsoft.EntityFrameworkCore;
using Poznavacka.Areas.ContentLearn.Models.ViewModels;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem;
using Poznavacka.Data.DbSystem.Learning;
using Poznavacka.Data.DbSystem.Taxons;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentLearn.Models.Strategies
{
    public class ItemsLoader
    {
        public async Task<List<LearningSetItem>> LoadItems(SourceModel model, OrganismDbContext _context)
        {
            List<KingdomT> Kingdoms = await _context.Kingdoms
                .Include(i => i.Phylums)
                    .ThenInclude(i => i.Classes)
                        .ThenInclude(i => i.Orders)
                            .ThenInclude(i => i.Families)
                                .ThenInclude(i => i.Genusses)
                                    .ThenInclude(i => i.Species)
                                        .ThenInclude(i => i.Imgs)
                .ToListAsync();

            List<SpeciesT> species = LoadSpecies(model, Kingdoms);
            return SpeciesToItems(species);
        }


        private List<LearningSetItem> SpeciesToItems(List<SpeciesT> species)
        {
            List<LearningSetItem> setItems = new List<LearningSetItem>();
            foreach (SpeciesT sp in species)
            {
                foreach (ImgDb img in sp.Imgs)
                {
                    LearningSetItem newItem = new LearningSetItem
                    {
                        Name = sp.Name,
                        Description = sp.Description,
                        Class = sp.Class,
                        Classification = sp.Classification,
                        Size = sp.Size,
                        Use = sp.Use,
                        OccurencesWorld = sp.OccurencesWorld,
                        Ecosystems = sp.Ecosystems,
                        OccurenceCR = sp.OccurenceCR,
                        Protection = sp.Protection,
                        EcoFunction = sp.EcoFunction,
                        ImgPath = img.ImgPath,
                        ImgName = img.ImgName,
                        ImgDescription = img.ImgDescription,
                        ImgType = img.ImgType
                    };
                    setItems.Add(newItem);
                }
            }
            return setItems;
        }


        private List<SpeciesT> LoadSpecies(SourceModel model, List<KingdomT> kingdoms)
        {
            switch (model.Taxon)
            {
                case "Říše":
                    return kingdoms
                        .Single(x => x.KingdomTID == model.KingdomID).Phylums
                        .SelectMany(x => x.Classes)
                        .SelectMany(x => x.Orders)
                        .SelectMany(x => x.Families)
                        .SelectMany(x => x.Genusses)
                        .SelectMany(x => x.Species)
                        .ToList();
                case "Kmen":
                    return kingdoms
                        .Single(x => x.KingdomTID == model.KingdomID).Phylums
                        .Single(x => x.PhylumTID == model.PhylumID).Classes
                        .SelectMany(x => x.Orders)
                        .SelectMany(x => x.Families)
                        .SelectMany(x => x.Genusses)
                        .SelectMany(x => x.Species)
                        .ToList();
                case "Třída":
                    return kingdoms
                        .Single(x => x.KingdomTID == model.KingdomID).Phylums
                        .Single(x => x.PhylumTID == model.PhylumID).Classes
                        .Single(x => x.ClassTID == model.ClassID).Orders
                        .SelectMany(x => x.Families)
                        .SelectMany(x => x.Genusses)
                        .SelectMany(x => x.Species)
                        .ToList();
                case "Řád":
                    return kingdoms
                        .Single(x => x.KingdomTID == model.KingdomID).Phylums
                        .Single(x => x.PhylumTID == model.PhylumID).Classes
                        .Single(x => x.ClassTID == model.ClassID).Orders
                        .Single(x => x.OrderTID == model.OrderID).Families
                        .SelectMany(x => x.Genusses)
                        .SelectMany(x => x.Species)
                        .ToList();
                case "Čeleď":
                    return kingdoms
                        .Single(x => x.KingdomTID == model.KingdomID).Phylums
                        .Single(x => x.PhylumTID == model.PhylumID).Classes
                        .Single(x => x.ClassTID == model.ClassID).Orders
                        .Single(x => x.OrderTID == model.OrderID).Families
                        .Single(x => x.FamilyTID == model.FamilyID).Genusses
                        .SelectMany(x => x.Species)
                        .ToList();
                case "Rod":
                    return kingdoms
                        .Single(x => x.KingdomTID == model.KingdomID).Phylums
                        .Single(x => x.PhylumTID == model.PhylumID).Classes
                        .Single(x => x.ClassTID == model.ClassID).Orders
                        .Single(x => x.OrderTID == model.OrderID).Families
                        .Single(x => x.FamilyTID == model.FamilyID).Genusses
                        .Single(x => x.GenusTID == model.GenusID).Species
                        .ToList();
                case "Druh":
                    return kingdoms
                        .Single(x => x.KingdomTID == model.KingdomID).Phylums
                        .Single(x => x.PhylumTID == model.PhylumID).Classes
                        .Single(x => x.ClassTID == model.ClassID).Orders
                        .Single(x => x.OrderTID == model.OrderID).Families
                        .Single(x => x.FamilyTID == model.FamilyID).Genusses
                        .Single(x => x.GenusTID == model.GenusID).Species
                        .Where(x => x.SpeciesTID == model.SpeciesID)
                        .ToList();
                default:
                    break;
            }
            return null;
        }
    }
}