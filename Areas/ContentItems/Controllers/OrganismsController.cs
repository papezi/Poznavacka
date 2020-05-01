using Microsoft.AspNetCore.Mvc;
using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using Poznavacka.Areas.ContentItems.Models.ViewModels.Fillers;
using System.Threading.Tasks;
using Poznavacka.Areas.ContentItems.Models.Strategies;
using System;

namespace Poznavacka.Areas.ContentItems.Controllers
{
    [Area("ContentItems")]
    public class OrganismsController : Controller
    {
        private readonly OrganismDbContext _context;

        public OrganismsController(OrganismDbContext context)
        {
            _context = context;
        }


        //=INDEX===============================================================

        // GET: Organism
        public async Task<IActionResult> Index()
        {
            OrganismClassification OrganismC = new OrganismClassification();
            await TryUpdateModelAsync(OrganismC);
            ChosenTaxons viewModel = await ChosenTaxonsFiller.Fill(_context, OrganismC);
            return View(viewModel);
        }

        //=CREATE==============================================================

        // GET: Organism/Create
        public async Task<IActionResult> Create()
        {
            OrganismData Organism = new OrganismData();
            await TryUpdateModelAsync(Organism);
            return View(Organism);
        }

        // POST: Organism/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            OrganismData organism = new OrganismData();
            if (await TryUpdateModelAsync(organism))
            {
                try
                {
                    await new CreateStrategyContext().Create(organism, _context);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction("IndexImg", "Img",
                routeValues: new
                {
                    organism.KingdomID,
                    organism.PhylumID,
                    organism.ClassID,
                    organism.OrderID,
                    organism.FamilyID,
                    organism.GenusID,
                    organism.SpeciesID
                });
        }

        //=EDIT================================================================

        // GET: Organism/Edit/5
        public async Task<IActionResult> Edit()
        {
            OrganismData viewModel = new OrganismData();
            await TryUpdateModelAsync(viewModel);
            viewModel = await OrganismDataFiller.Fill(_context, viewModel);
            return View(viewModel);
        }

        // POST: Organism/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost()
        {
            OrganismData organism = new OrganismData();
            if (await TryUpdateModelAsync(organism))
            {
                try
                {
                    await new EditStrategyContext().Edit(organism, _context);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction("IndexImg", "Img",
                routeValues: new
                {
                    organism.KingdomID,
                    organism.PhylumID,
                    organism.ClassID,
                    organism.OrderID,
                    organism.FamilyID,
                    organism.GenusID,
                    organism.SpeciesID
                });
        }

        //=DELETE==============================================================

        // GET: Organism/Delete/5
        public async Task<IActionResult> Delete()
        {
            OrganismData viewModel = new OrganismData();
            await TryUpdateModelAsync(viewModel);
            viewModel = await OrganismDataFiller.Fill(_context, viewModel);
            return View(viewModel);
        }

        // POST: Organism/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            OrganismClassification organism = new OrganismClassification();
            if (await TryUpdateModelAsync(organism))
            {
                try
                {
                    await new DeleteStrategyContext().Delete(organism, _context);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
