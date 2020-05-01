using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.EditStrategy
{
    public class EditSpecies : EditBase
    {
        public override string RequiredCase { get { return "Druh"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            SpeciesT oldSpecies = _context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .ThenInclude(i => i.Families).ThenInclude(i => i.Genusses).ThenInclude(i => i.Species)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID).Orders
                .Single(i => i.OrderTID == model.OrderID).Families
                .Single(i => i.FamilyTID == model.FamilyID).Genusses
                .Single(i => i.GenusTID == model.GenusID).Species
                .Single(i => i.SpeciesTID == model.SpeciesID);
            oldSpecies.Name = model.Name;
            oldSpecies.Description = model.Description;
            oldSpecies.Size = model.Size;
            oldSpecies.Use = model.Use;
            oldSpecies.OccurenceCR = model.OccurenceCR;
            oldSpecies.Protection = model.Protection;
            oldSpecies.EcoFunction = model.EcoFunction;
            oldSpecies.Ecosystems = string.Join(", ", model.Ecosystems.Select(a => a.ToString()));
            oldSpecies.OccurencesWorld = string.Join(", ", model.OccurencesWorld.Select(a => a.ToString()));
            await _context.SaveChangesAsync();
        }
    }
}
