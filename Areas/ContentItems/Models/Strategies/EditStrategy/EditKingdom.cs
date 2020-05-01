using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.EditStrategy
{
    public class EditKingdom : EditBase
    {
        public override string RequiredCase { get { return "Říše"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            KingdomT oldKingdom = _context.Kingdoms
                .Single(i => i.KingdomTID == model.KingdomID);
            oldKingdom.Name = model.Name;
            await _context.SaveChangesAsync();
        }
    }
}
