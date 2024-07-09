using Microsoft.EntityFrameworkCore;
using TirelireWebApp.Models;
namespace TirelireWebApp.Data
{
    public class TirelireContext : DbContext
    {
        //config via le constructeur : 
        public TirelireContext(DbContextOptions<TirelireContext> options) : base(options)
        {
        }

        //first Code
        protected override void OnModelCreating(ModelBuilder modelB)
        {
            //relation 
            modelB.Entity<Description>().HasKey(d => new
            {
                d.IdTirelire,
                d.IdDetail
            });
            modelB.Entity<Description>().HasOne(d => d.Tirelire).WithMany(di => di.DescriptionTirelire).HasForeignKey(e => e.IdTirelire);
            modelB.Entity<Description>().HasOne(e => e.Detail).WithMany(de => de.DescriptionTirelire).HasForeignKey(e => e.IdDetail);

            //datafirst 
            modelB.Entity<Tirelire>().HasData(
                new Tirelire
                {
                    Id = 1,
                    NameTirelire = "Tirelire Cochon",
                    PriceTirelire = 19.99,
                    ImageUrlTirelire = "https://www.allbranded.fr/out/shop-fr/pictures/generated/product/1/480_480_80/mo8132-48.jpg",
                    Couleur = "Vert pomme"
                }
            );
            modelB.Entity<DetailTirelire>().HasData(
               new DetailTirelire
               {
                   Id = 1,
                   Hauteur = 5,
                   Largeur = 5,
                   Longeur = 5,
                   Poids = 0.5,
                   Capacité = "petit format",
                   Fabricant = "Robert"
                 


               },
                new DetailTirelire
                {
                    Id = 2,
                    Hauteur = 10,
                    Largeur = 10,
                    Longeur = 10,
                    Poids = 1,
                    Capacité = "moyen format",
                    Fabricant = "Robert"
                   


                },
                 new DetailTirelire
                 {
                     Id = 3,
                     Hauteur = 15,
                     Largeur = 15,
                     Longeur = 15,
                     Poids = 1.5,
                     Capacité = "grand format",
                     Fabricant = "Robert"
                    


                 }
           );


            modelB.Entity<Description>().HasData(
                new Description
                {
                    IdTirelire = 1,
                    IdDetail = 2
                },
                new Description
                {
                    IdTirelire = 1,
                    IdDetail = 1
                }
            );

            base.OnModelCreating(modelB);
        }

        public DbSet<Tirelire> TirelireSet { get; set; }
        public DbSet<DetailTirelire> DetailTireliresSet { get; set; }
        public DbSet<Description> DescriptionSet { get; set; }
    }
}
