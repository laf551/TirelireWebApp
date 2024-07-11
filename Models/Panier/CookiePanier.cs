namespace TirelireWebApp.Models.Panier
{
    public class CookiePanier 
    {
        public int Id { get; set; }
        public List<PanierTirelire> Pan { get; set; } = new List<PanierTirelire>();
        
        
    }

    
   
}
