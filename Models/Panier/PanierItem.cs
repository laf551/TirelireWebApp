using System.ComponentModel.DataAnnotations.Schema;

namespace TirelireWebApp.Models.Panier
{
    //Unitaire
    public class PanierItem
    {
        public int Id { get; set; }
        //public string Nom { get; set; }
        public int Quantite { get; set; }
        public decimal Frais { get; set; }
        
       // public Tirelire t { get; set; }
        
        
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
