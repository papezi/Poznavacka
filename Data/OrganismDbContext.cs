using Microsoft.EntityFrameworkCore;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Data.DbSystem.Learning;

namespace Poznavacka.Data
{
    public class OrganismDbContext : DbContext
    {
        public DbSet<KingdomT> Kingdoms { get; set; }

        public OrganismDbContext(DbContextOptions<OrganismDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=OrganismsDb;Integrated Security=True");
        }

        public DbSet<DbSystem.ImgDb> ImgDb { get; set; }

        public DbSet<Poznavacka.Data.DbSystem.Learning.LearningSet> LearningSet { get; set; }
    }
}
