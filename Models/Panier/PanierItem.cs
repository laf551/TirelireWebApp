using System.ComponentModel.DataAnnotations.Schema;

namespace TirelireWebApp.Models.Panier
{
    //Unitaire
    public class PanierItem
    {
        public int Id { get; set; }

        //public int IdDuTirelire { get ; set; }
        //public string Nom { get; set; }
        public int Quantite { get; set; }
        public decimal Frais { get; set; }

        public int IdTirelire {get ; set; }
       
        public int Count { get; set; }
       public Tirelire t { get; set; }
       public DetailTirelire d { get; set; }

        public void MettreAJour(int quantite, decimal frais, Tirelire tirelire, DetailTirelire detailTirelire)
        {
            this.Quantite = quantite;
            this.Frais = frais;
            this.t = tirelire;
            this.d = detailTirelire;
        
        }

        public void afficher(PanierItem p)
        {
            p.ToString(); 
        }
        /* public int ID { get; set; }
         public int TirelireID { get; set; }

         public int Qte { get; set; }

         public int PanierID { get; set; }
         [ForeignKey("PanierID")]
         public Panier Panier { get; set; }
         public int FraisLivraison { get; set; }

         public Tirelire GetTirelire { get; set; } 


         public double  Montant()
         {
             var cout = Qte * GetTirelire.PriceTirelire;
             return cout; 
         }*/

    }
}
