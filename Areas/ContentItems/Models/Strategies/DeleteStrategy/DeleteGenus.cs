using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.DeleteStrategy
{
    public class DeleteGenus : DeleteBase
    {
        public override string RequiredCase { get { return "Rod"; } }

        public override async Task Execute(OrganismClassification model, OrganismDbContext _context)
        {
            _context.Remove(_context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .ThenInclude(i => i.Families).ThenInclude(i => i.Genusses)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID).Orders
                .Single(i => i.OrderTID == model.OrderID).Families
                .Single(i => i.FamilyTID == model.FamilyID).Genusses
                .Single(i => i.GenusTID == model.GenusID));
            await _context.SaveChangesAsync();
        }
    }
}
