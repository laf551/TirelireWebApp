
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
       /* public int FabricantId { get; set; }
        [ForeignKey("FabricantId")]
        public Fabricant Fabricant { get; set; }*/

        public List <Description> DescriptionTirelire { get ; set; }

        
    }
}
