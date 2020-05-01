using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.CreateStrategy
{
    public class CreateOrder : CreateBase
    {
        public override string RequiredCase { get { return "Řád"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            OrderT newOrder = new OrderT()
            {
                Name = model.Name
            };
            _context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID).Orders
                .Add(newOrder);
            await _context.SaveChangesAsync();
        }
    }
}
