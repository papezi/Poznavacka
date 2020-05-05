using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using Poznavacka.Areas.ContentItems.Models.ViewModels.Fillers;
using Poznavacka.Areas.ContentLearn.Models.ViewModels;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Learning;

namespace Poznavacka.Areas.ContentLearn.Controllers
{
    [Area("ContentLearn")]
    public class SetSourceController : Controller
    {
        private readonly OrganismDbContext _context;

        public SetSourceController(OrganismDbContext context)
        {
            _context = context;
        }

        // GET: Learning/AddSource/5
        public async Task<IActionResult> SourceIndex(int learningSetID)
        {
            OrganismClassification OrganismC = new OrganismClassification();
            await TryUpdateModelAsync(OrganismC);
            ChosenTaxons viewModel = await ChosenTaxonsFiller.Fill(_context, OrganismC);
            ViewBag.LearningSetID = learningSetID;
            return View(viewModel);
        }

        // GET: Learning/AddSource/5
        public async Task<IActionResult> AddSource()
        {
            SourceModel source = new SourceModel();
            if (await TryUpdateModelAsync(source))
            {
                await source.GetItems(_context);

                LearningSet set = _context.LearningSets.Single(x => x.LearningSetID == source.LearningSetID);
                set.NumberOfItems = set.Items.Count();
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Edit", "LearningSets",
                routeValues: new
                {
                    source.LearningSetID
                });
        }
    }
}
