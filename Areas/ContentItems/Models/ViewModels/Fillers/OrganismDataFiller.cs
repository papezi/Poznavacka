using Poznavacka.Data;
using Poznavacka.Data.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.ViewModels.Fillers
{
    public static class OrganismDataFiller
    {
        public static async Task<OrganismData> Fill(OrganismDbContext _context, OrganismData viewModel)
        {
            ChosenTaxons taxons = await ChosenTaxonsFiller.Fill(_context, viewModel);

            if (viewModel.KingdomID != null)
            {
                viewModel.Name = taxons.ChosenKingdom.Name;
            }

            if (viewModel.PhylumID != null)
            {
                viewModel.Name = taxons.ChosenPhylum.Name;
            }

            if (viewModel.ClassID != null)
            {
                viewModel.Name = taxons.ChosenClass.Name;
            }

            if (viewModel.OrderID != null)
            {
                viewModel.Name = taxons.ChosenOrder.Name;
            }

            if (viewModel.FamilyID != null)
            {
                viewModel.Name = taxons.ChosenFamily.Name;
            }

            if (viewModel.GenusID != null)
            {
                viewModel.Name = taxons.ChosenGenus.Name;
            }

            if (viewModel.SpeciesID != null)
            {
                viewModel.Name = taxons.ChosenSpecies.Name;
                viewModel.Description = taxons.ChosenSpecies.Description;
                viewModel.Class = taxons.ChosenSpecies.Class;
                viewModel.Classification = taxons.ChosenSpecies.Classification;
                viewModel.Size = taxons.ChosenSpecies.Size;
                viewModel.Use = taxons.ChosenSpecies.Use;
                viewModel.OccurenceCR = taxons.ChosenSpecies.OccurenceCR;
                viewModel.Protection = taxons.ChosenSpecies.Protection;
                viewModel.EcoFunction = taxons.ChosenSpecies.EcoFunction;
                viewModel.Ecosystems = taxons.ChosenSpecies.Ecosystems.Split(", ")
                    .Select(x => (EcosystemEnum)Enum.Parse(typeof(EcosystemEnum), x)).ToArray();
                viewModel.OccurencesWorld = taxons.ChosenSpecies.OccurencesWorld.Split(", ")
                    .Select(x => (OccurenceWorldEnum)Enum.Parse(typeof(OccurenceWorldEnum), x)).ToArray();
                viewModel.Imgs = taxons.ChosenSpecies.Imgs;
            }
            return viewModel;
        }
    }
}
