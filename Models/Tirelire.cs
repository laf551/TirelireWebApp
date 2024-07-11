
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
        
        public string Couleur { get; set; }
        
        //DetailsArticle 
      
        public List <Description> DescriptionTirelire { get ; set; }

        
    }
}
