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
            return View(await _context.LearningSet.ToListAsync());
        }

        // GET: Learning/Details/5
        public async Task<IActionResult> Details(int? LearningSetID)
        {
            if (LearningSetID == null)
            {
                return NotFound();
            }

            var learningSet = await _context.LearningSet
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
                _context.Add(newSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Edit",
                routeValues: new
                {
                    newSet.LearningSetID
                });
        }

        // GET: Learning/Edit/5
        public async Task<IActionResult> Edit(int? LearningSetID)
        {
            if (LearningSetID == null)
            {
                return NotFound();
            }

            var learningSet = await _context.LearningSet.FindAsync(LearningSetID);
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
                    //await new EditStrategyContext().Edit(organism, _context);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }
            return View(set);
        }

        // GET: Learning/Delete/5
        public async Task<IActionResult> Delete(int? LearningSetID)
        {
            var learningSet = await _context.LearningSet.FindAsync(LearningSetID);
            _context.LearningSet.Remove(learningSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Learning/DeleteItem/5
        public async Task<IActionResult> DeleteItem(int? learningSetID, int? learningSetItemID)
        {
            _context.Remove(_context.LearningSet.Include(x => x.Items)
                 .First(x => x.LearningSetID == learningSetID).Items
                 .FirstOrDefault(x => x.LearningSetItemID == learningSetItemID));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningSetExists(int id)
        {
            return _context.LearningSet.Any(e => e.LearningSetID == id);
        }
    }
}
