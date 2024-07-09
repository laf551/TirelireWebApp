namespace TirelireWebApp.Models
{
    public class DetailTirelire
    {
        public int Id { get; set;  }
        public double Hauteur { get; set; }
        public double Largeur { get; set; }
        public double Longeur { get; set; }
        public double Poids { get; set; }

        public string Capacité { get; set; }

        //public List <Fabricant> DescriptFabricant { get; set; }

        //public string CouleurPrincipale { get; set; }

        public string Fabricant { get; set; }

       // public List <string> Reference { get; set;  }

        public List<Description> DescriptionTirelire { get; set; }
    }
}
