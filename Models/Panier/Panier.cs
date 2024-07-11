using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace TirelireWebApp.Models.Panier
{
    //gerer la ligne panier
    public class Panier
    {
        
            public List<PanierItem> Items { get; set; } = new List<PanierItem>();

            public void AjouterItem(PanierItem item)
            {
                Items.Add(item);
            }
       

        /* 
         public int Id { get; set; }

         //public List<LignePanier> MesAchats { get; set; }

         public PanierItem? NewTirelire; */



    }
}
