using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.CreateStrategy
{
    public abstract class CreateBase
    {
        public abstract string RequiredCase { get; }

        public abstract Task<int> Execute(OrganismData organism, OrganismDbContext _context);

        public bool ShouldExecute(string inputCase)
        {
            return inputCase.Equals(RequiredCase, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
