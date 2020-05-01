using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.Strategies.EditStrategy;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies
{
    public class EditStrategyContext
    {
        public async Task Edit(OrganismData model, OrganismDbContext _context)
        {
            var action = typeof(EditBase).Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(EditBase)) && !t.IsAbstract)
                    .Select(t => (EditBase)Activator.CreateInstance(t))
                    .FirstOrDefault(a => a.ShouldExecute(model.Taxon));

            if (action == null)
            {
                throw new ArgumentException("Unknown case.");
            }

            await action.Execute(model, _context);
        }
    }
}
