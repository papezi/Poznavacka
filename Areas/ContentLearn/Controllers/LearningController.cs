using System;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: Learning
        public async Task<IActionResult> Index()
        {
            return View(await _context.LearningSets.ToListAsync());
        }

        // GET: Learning/Details/5
        public async Task<IActionResult> Details(int? LearningSetID)
        {
            if (LearningSetID == null)
            {
                return NotFound();
            }

            LearningSet learningSet = await _context.LearningSets
                .FirstOrDefaultAsync(m => m.LearningSetID == LearningSetID);
            if (learningSet == null)
            {
                return NotFound();
            }

            return View(learningSet);
        }

        // GET: Learning/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Learning/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            LearningSet newSet = new LearningSet();
            if (await TryUpdateModelAsync(newSet))
            {
                _context.LearningSets.Add(newSet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit",
                routeValues: new
                {
                    newSet.LearningSetID
                });
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Learning/Edit/5
        public async Task<IActionResult> Edit(int? learningSetID)
        {
            if (learningSetID == null)
            {
                return NotFound();
            }

            var learningSet = await _context.LearningSets.Include(x => x.Items)
                .FirstAsync(x => x.LearningSetID == learningSetID);
            if (learningSet == null)
            {
                return NotFound();
            }
            return View(learningSet);
        }

        // POST: Learning/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost()
        {
            LearningSet set = new LearningSet();
            if (await TryUpdateModelAsync(set))
            {
                try
                {
                    LearningSet oldSet = _context.LearningSets.Single(x => x.LearningSetID == set.LearningSetID);
                    oldSet.Name = set.Name;
                    oldSet.Description = set.Description;
                    oldSet.Class = set.Class;
                    await _context.SaveChangesAsync();
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Learning/Delete/5
        public async Task<IActionResult> Delete(int? LearningSetID)
        {
            var learningSet = await _context.LearningSets.FindAsync(LearningSetID);
            _context.LearningSets.Remove(learningSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Learning/DeleteItem/5
        public async Task<IActionResult> DeleteItem(int? learningSetID, int? learningSetItemID)
        {
            _context.Remove(_context.LearningSets.Include(x => x.Items)
                 .First(x => x.LearningSetID == learningSetID).Items
                 .FirstOrDefault(x => x.LearningSetItemID == learningSetItemID));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
