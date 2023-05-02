using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

       public HomeController(ILogger<HomeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

        public IActionResult Index()
        {

            var kisiler = _context.Kisiler.ToList();

            //Kişileri List<SelectListItem> objesine çevirin
            var selectListItems = kisiler.Select(k => new SelectListItem { Text = k.Isim, Value = k.Id.ToString() }).ToList();

            //ComboBox'ı ViewModel'da tutun
            var viewModel = new IndexViewModel { Kisiler = selectListItems };

            //View'a ViewModel'i gönderin
            return View(viewModel);

            
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kisiler kisi)
        {
            using (var context = new MyDbContext())
            {
                context.Kisiler.Add(kisi);
                context.SaveChanges();
            }

            TempData["Mesaj"] = "Kişi başarıyla eklendi."; // Mesajı TempData'ya ekle

            return RedirectToAction("Index"); // Index sayfasına yönlendir
        }

        [HttpGet]
        public ActionResult Getir()


        {
            var kisiler = _context.Kisiler.ToList();

            var selectListItems = kisiler.Select(k => new SelectListItem { Text = k.Isim, Value = k.Id.ToString() }).ToList();

            var viewModel = new IndexViewModel { Kisiler = selectListItems };

            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            var kisi = _context.Kisiler.Find(id);

            if (kisi == null)
            {
                return NotFound();
            }

            var viewModel = new DetailsViewModel
            {
                Id = kisi.Id,
                Isim = kisi.Isim,
                BabaAdi = kisi.BabaAdi,
                AnneAdi = kisi.AnneAdi,
                Cinsiyet = kisi.Cinsiyet,
                Yas = kisi.Yas
            };

            return View(viewModel);
        }

        public IActionResult GetKisiDetails(int id)
        {
            var kisi = _context.Kisiler.FirstOrDefault(k => k.Id == id);

            if (kisi == null)
            {
                return NotFound();
            }

            return Json(kisi);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}