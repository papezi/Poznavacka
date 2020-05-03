using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using Poznavacka.Areas.ContentItems.Models.Strategies.CreateStrategy;

namespace Poznavacka.Areas.ContentItems.Models.Strategies
{
    public class CreateStrategyContext
    {
        public async Task<int> Create(OrganismData model, OrganismDbContext _context)
        {
            var action = typeof(CreateBase).Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(CreateBase)) && !t.IsAbstract)
                    .Select(t => (CreateBase)Activator.CreateInstance(t))
                    .FirstOrDefault(a => a.ShouldExecute(model.Taxon));

            if (action == null)
            {
                throw new ArgumentException("Unknown case.");
            }

            return await action.Execute(model, _context);
        }
    }
}
