using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poznavacka.Data;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using Poznavacka.Areas.ContentItems.Models.ViewModels.Fillers;

namespace Poznavacka.Areas.ContentItems.Controllers
{
    [Area("ContentItems")]
    public class ImgController : Controller
    {
        private readonly OrganismDbContext _context;

        public ImgController(OrganismDbContext context)
        {
            _context = context;
        }

        //=INDEX=IMG===========================================================

        // GET: Organism/IndexImg/5
        public async Task<IActionResult> IndexImg()
        {
            OrganismData viewModel = new OrganismData();
            await TryUpdateModelAsync(viewModel);
            viewModel = await OrganismDataFiller.Fill(_context, viewModel);
            return View(viewModel);
        }

        //=CREATE=IMG==========================================================

        // GET: Organism/CreateImg
        public async Task<IActionResult> CreateImg()
        {
            ImgData Img = new ImgData();
            await TryUpdateModelAsync(Img);
            return View(Img);
        }

        // POST: Organism/CreateImg
        [HttpPost, ActionName("CreateImg")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateImgPost()
        {
            ImgData Img = new ImgData();
            if (await TryUpdateModelAsync(Img))
            {
                try
                {
                    await Img.AddTo(_context);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction("IndexImg",
                routeValues: new
                {
                    Img.KingdomID,
                    Img.PhylumID,
                    Img.ClassID,
                    Img.OrderID,
                    Img.FamilyID,
                    Img.GenusID,
                    Img.SpeciesID
                });
        }

        // GET: Img/DeleteImg/5
        public async Task<IActionResult> DeleteImg()
        {
            ImgData Img = new ImgData();
            await TryUpdateModelAsync(Img);
            await Img.Delete(_context);

            return RedirectToAction("IndexImg",
                routeValues: new
                {
                    Img.KingdomID,
                    Img.PhylumID,
                    Img.ClassID,
                    Img.OrderID,
                    Img.FamilyID,
                    Img.GenusID,
                    Img.SpeciesID
                });
        }
    }
}
