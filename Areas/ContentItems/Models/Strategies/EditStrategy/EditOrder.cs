using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.EditStrategy
{
    public class EditOrder : EditBase
    {
        public override string RequiredCase { get { return "Řád"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            OrderT oldOrder = _context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID).Orders
                .Single(i => i.OrderTID == model.OrderID);
            oldOrder.Name = model.Name;
            await _context.SaveChangesAsync();
        }
    }
}
