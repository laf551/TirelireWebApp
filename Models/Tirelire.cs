
using System.ComponentModel.DataAnnotations;

namespace TirelireWebApp.Models
{
    public class Tirelire
    {
        [Key]
        public int Id { get; set; }
        public string ? NameTirelire { get; set; }

        public double PriceTirelire { get; set; }

        public string ? ImageUrlTirelire { get; set; }
        //new
        public string Couleur { get; set; }
        
        //DetailsArticle 
       // public List<DetailTirelire> Description { get;set; }
        public List <Description> DescriptionTirelire { get ; set; }


    }
}
