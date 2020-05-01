using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.CreateStrategy
{
    public class CreateKingdom : CreateBase
    {
        public override string RequiredCase { get { return "Říše"; } }

        public override async Task Execute(OrganismData model, OrganismDbContext _context)
        {
            KingdomT newKingdom = new KingdomT
            {
                Name = model.Name
            };
            _context.Kingdoms.Add(newKingdom);
            await _context.SaveChangesAsync();
        }
    }
}
