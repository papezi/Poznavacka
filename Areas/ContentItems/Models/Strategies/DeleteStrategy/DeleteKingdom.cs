using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.DeleteStrategy
{
    public class DeleteKingdom : DeleteBase
    {
        public override string RequiredCase { get { return "Říše"; } }

        public override async Task Execute(OrganismClassification model, OrganismDbContext _context)
        {
            _context.Remove(_context.Kingdoms
                .Single(i => i.KingdomTID == model.KingdomID));
                
            await _context.SaveChangesAsync();
        }
    }
}
