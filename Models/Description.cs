namespace TirelireWebApp.Models
{
    public class Description
    {
        public int IdTirelire { get; set; }
        public Tirelire Tirelire { get; set; }
        public int IdDetail { get; set; }
        public DetailTirelire Detail { get; set; }

        


    }
}
