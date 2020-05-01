using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.EditStrategy
{
    public class EditPhylum : EditBase
    {
        public override string RequiredCase { get { return "Kmen"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            PhylumT oldPhylum = _context.Kingdoms.Include(i => i.Phylums)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID);
            oldPhylum.Name = model.Name;
            await _context.SaveChangesAsync();
        }
    }
}
