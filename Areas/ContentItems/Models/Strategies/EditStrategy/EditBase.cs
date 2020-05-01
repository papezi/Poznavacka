using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.EditStrategy
{
    public abstract class EditBase
    {
        public abstract string RequiredCase { get; }

        public abstract Task Execute(OrganismData organism, OrganismDbContext _context);

        public bool ShouldExecute(string inputCase)
        {
            return inputCase.Equals(RequiredCase, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
