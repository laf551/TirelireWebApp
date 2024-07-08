namespace TirelireWebApp.Models
{
    public class Tirelire
    {
        public int Id { get; set; }
        public string ? NameTirelire { get; set; }

        public double PriceTirelire { get; set; }

        public string ? ImageUrlTirelire { get; set; }
        public List<DetailTirelire>? DescriptionTirelire { get;set; }


    }
}
