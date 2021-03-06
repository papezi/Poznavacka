﻿using Microsoft.EntityFrameworkCore;
using Poznavacka.Data;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Areas.ContentItems.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poznavacka.Areas.ContentItems.Models.Strategies.CreateStrategy
{
    public class CreateGenus : CreateBase
    {
        public override string RequiredCase { get { return "Rod"; } }

        public override async Task<int> Execute(OrganismData model, OrganismDbContext _context)
        {
            GenusT newGenus = new GenusT()
            {
                Name = model.Name
            };
            _context.Kingdoms
                .Include(i => i.Phylums).ThenInclude(i => i.Classes).ThenInclude(i => i.Orders)
                .ThenInclude(i => i.Families).ThenInclude(i => i.Genusses)
                .Single(i => i.KingdomTID == model.KingdomID).Phylums
                .Single(i => i.PhylumTID == model.PhylumID).Classes
                .Single(i => i.ClassTID == model.ClassID).Orders
                .Single(i => i.OrderTID == model.OrderID).Families
                .Single(i => i.FamilyTID == model.FamilyID).Genusses
                .Add(newGenus);
            await _context.SaveChangesAsync();
            return newGenus.GenusTID;
        }
    }
}
