using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.DeleteStrategy
{
    public class DeleteClass : DeleteBase
    {
        public override string RequiredCase { get { return "Třída"; } }

        public override async Task Execute(OrganismClassification model, OrganismDbContext _context)
        {
            _context.Remove(_context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID));
            await _context.SaveChangesAsync();
        }
    }
}
