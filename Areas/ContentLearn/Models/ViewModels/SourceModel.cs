using Microsoft.EntityFrameworkCore;
using Poznavacka.Areas.ContentLearn.Models.Strategies;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Learning;
using Poznavacka.Data.DbSystem.Taxons;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentLearn.Models.ViewModels
{
    public class SourceModel
    {
        public string Taxon { get; set; }
        public int? KingdomID { get; set; }
        public int? PhylumID { get; set; }
        public int? ClassID { get; set; }
        public int? OrderID { get; set; }
        public int? FamilyID { get; set; }
        public int? GenusID { get; set; }
        public int? SpeciesID { get; set; }
        public int LearningSetID { get; set; }


        public async Task GetItems(OrganismDbContext _context)
        {
            List<LearningSetItem> setItems = await new ItemsLoader().LoadItems(this, _context);

            LearningSet set = _context.LearningSets.Include(x => x.Items)
                .Single(x => x.LearningSetID == LearningSetID);

            foreach (LearningSetItem item in setItems)
            {
                if (ItemValidator.Validate(set, item))
                {
                    set.Items.Add(item);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
