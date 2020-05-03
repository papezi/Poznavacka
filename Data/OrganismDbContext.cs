using Microsoft.EntityFrameworkCore;
using Poznavacka.Data.DbSystem.Taxons;
using Poznavacka.Data.DbSystem.Learning;
using Poznavacka.Data.DbSystem;

namespace Poznavacka.Data
{
    public class OrganismDbContext : DbContext
    {


        public OrganismDbContext(DbContextOptions<OrganismDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=OrganismsDb;Integrated Security=True");
        }

        public DbSet<KingdomT> Kingdoms { get; set; }
        public DbSet<ImgDb> ImgDb { get; set; }
        public DbSet<LearningSet> LearningSets { get; set; }
    }
}
