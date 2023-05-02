using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models
{
    public class Kisiler
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string AnneAdi { get; set; }
        public string BabaAdi { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        
    }

    public class IndexViewModel
    {
        public List<SelectListItem> Kisiler { get; set; }
    }
    public class DetailsViewModel
    {
        
        public int Id { get; set; }
        public string Isim { get; set; }
        public string AnneAdi { get; set; }
        public string BabaAdi { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
    }
}
