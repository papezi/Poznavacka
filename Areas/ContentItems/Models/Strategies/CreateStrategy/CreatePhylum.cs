using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.CreateStrategy
{
    public class CreatePhylum : CreateBase
    {
        public override string RequiredCase { get { return "Kmen"; } }

        public override async Task<int> Execute(OrganismData model, OrganismDbContext _context)
        {
            PhylumT newPhylum = new PhylumT()
            {
                Name = model.Name
            };
            _context.Kingdoms.Include(i => i.Phylums)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Add(newPhylum);
            await _context.SaveChangesAsync();
            return newPhylum.PhylumTID;
        }
    }
}
