using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.Strategies.DeleteStrategy;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies
{
    public class DeleteStrategyContext
    {
        public async Task Delete(OrganismClassification model, OrganismDbContext _context)
        {
            var action = typeof(DeleteBase).Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(DeleteBase)) && !t.IsAbstract)
                    .Select(t => (DeleteBase)Activator.CreateInstance(t))
                    .FirstOrDefault(a => a.ShouldExecute(model.Taxon));

            if (action == null)
            {
                throw new ArgumentException("Unknown case.");
            }

            await action.Execute(model, _context);
        }
    }
}
