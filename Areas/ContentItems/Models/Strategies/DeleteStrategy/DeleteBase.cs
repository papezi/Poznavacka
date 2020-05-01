using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.DeleteStrategy
{
    public abstract class DeleteBase
    {
        public abstract string RequiredCase { get; }

        public abstract Task Execute(OrganismClassification organism, OrganismDbContext _context);

        public bool ShouldExecute(string inputCase)
        {
            return inputCase.Equals(RequiredCase, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
