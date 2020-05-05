using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Learning;

namespace Poznavacka.Areas.ContentLearn.Controllers
{
    [Area("ContentLearn")]
    public class LearningController : Controller
    {
        private readonly OrganismDbContext _context;

        public LearningController(OrganismDbContext context)
        {
            _context = context;
        }

        public IActionResult Slide(int learningSetID, int item)
        {
            ViewBag.item = item;
            LearningSet set = _context.LearningSets.Include(x => x.Items)
                .Single(x => x.LearningSetID == learningSetID);
            item = item >= set.NumberOfItems ? set.NumberOfItems - 1 : item;
            item = item < 0 ? 0 : item;

            LearningSetItem currentItem = set.Items.ElementAt(item);
            ViewBag.item = item;
            return View(currentItem);
        }
    }
}
