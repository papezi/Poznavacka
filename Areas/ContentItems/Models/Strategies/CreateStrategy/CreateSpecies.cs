using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.CreateStrategy
{
    public class CreateSpecies : CreateBase
    {
        public override string RequiredCase { get { return "Druh"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            SpeciesT newSpecies = new SpeciesT()
            {
                Name = model.Name,
                Description = model.Description,
                Size = model.Size,
                Use = model.Use,
                OccurenceCR = model.OccurenceCR,
                Protection = model.Protection,
                EcoFunction = model.EcoFunction,
                Ecosystems = string.Join(", ", model.Ecosystems.Select(a => a.ToString())),
                OccurencesWorld = string.Join(", ", model.OccurencesWorld.Select(a => a.ToString()))
        };
            _context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .ThenInclude(i => i.Families).ThenInclude(i => i.Genusses).ThenInclude(i => i.Species)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID).Orders
                .Single(i => i.OrderTID == model.OrderID).Families
                .Single(i => i.FamilyTID == model.FamilyID).Genusses
                .Single(i => i.GenusTID == model.GenusID).Species
                .Add(newSpecies);
            await _context.SaveChangesAsync();
        }
    }
}
