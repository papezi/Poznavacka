using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.ViewModels.Fillers
{
    public static class ChosenTaxonsFiller
    {
        public static async Task<ChosenTaxons> Fill(OrganismDbContext _context, OrganismClassification OIDs)
        {
            //TODO: explicit loading
            ChosenTaxons viewModel = new ChosenTaxons
            {
                Kingdoms = await _context.Kingdoms
                .Include(i => i.Phylums)
                    .ThenInclude(i => i.Classes)
                        .ThenInclude(i => i.Orders)
                            .ThenInclude(i => i.Families)
                                .ThenInclude(i => i.Genusses)
                                    .ThenInclude(i => i.Species)
                .OrderBy(i => i.Name)
                .ToListAsync()
            };

            if (OIDs.KingdomID != null)
            {
                viewModel.ChosenKingdom = viewModel.Kingdoms
                    .Single(x => x.KingdomTID == OIDs.KingdomID);
            }

            if (OIDs.PhylumID != null)
            {
                viewModel.ChosenPhylum = viewModel.ChosenKingdom.Phylums
                    .Single(x => x.PhylumTID == OIDs.PhylumID);
            }

            if (OIDs.ClassID != null)
            {
                viewModel.ChosenClass = viewModel.ChosenPhylum.Classes
                    .Single(x => x.ClassTID == OIDs.ClassID);
            }

            if (OIDs.OrderID != null)
            {
                viewModel.ChosenOrder = viewModel.ChosenClass.Orders
                    .Single(x => x.OrderTID == OIDs.OrderID);
            }

            if (OIDs.FamilyID != null)
            {
                viewModel.ChosenFamily = viewModel.ChosenOrder.Families
                    .Single(x => x.FamilyTID == OIDs.FamilyID);
            }

            if (OIDs.GenusID != null)
            {
                viewModel.ChosenGenus = viewModel.ChosenFamily.Genusses
                    .Single(x => x.GenusTID == OIDs.GenusID);
            }

            if (OIDs.SpeciesID != null)
            {
                viewModel.ChosenSpecies = viewModel.ChosenGenus.Species
                    .Single(x => x.SpeciesTID == OIDs.SpeciesID);
                await _context.Entry(viewModel.ChosenSpecies)
                    .Collection(x => x.Imgs).LoadAsync();
            }

            return viewModel;
        }
    }
}
