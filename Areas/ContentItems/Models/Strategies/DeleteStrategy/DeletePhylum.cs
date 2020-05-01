using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.DeleteStrategy
{
    public class DeletePhylum : DeleteBase
    {
        public override string RequiredCase { get { return "Kmen"; } }

        public override async Task Execute(OrganismClassification model, OrganismDbContext _context)
        {
            _context.Remove(_context.Kingdoms.Include(i => i.Phylums)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID));
            await _context.SaveChangesAsync();
        }
    }
}
