using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.EditStrategy
{
    public class EditClass : EditBase
    {
        public override string RequiredCase { get { return "Třída"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            ClassT oldClass = _context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID);
            oldClass.Name = model.Name;
            await _context.SaveChangesAsync();
        }
    }
}
