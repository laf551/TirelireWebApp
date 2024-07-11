namespace TirelireWebApp.Models.Panier
{
    public class PanierTirelire
    {
        
        public int IdPanier { get; set; }
        
        public List<Tirelire> TirelirePan { get; set; }
        public List<Description> DescriptionPan { get; set; }
        public int Qte {  get; set; }
        public int FraisLivraison { get; set; }

    }
}
