using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TirelireWebApp.Data;
using TirelireWebApp.Models;
using TirelireWebApp.Models.Panier;







namespace TirelireWebApp.Controllers
{
	public class HomeController : Controller
	{
		//ILogger : journal pour enregistrer les infos important de l'app
		private readonly ILogger<HomeController> _logger;

        private readonly TirelireContext _context;
        public HomeController(ILogger<HomeController> logger , TirelireContext context)
		{
			//constructeur
			_logger = logger;
			_context = context;
		}

        public async Task<IActionResult> Index(string SearchString)
        {
            var recherche = from d in _context.TirelireSet
                            select d;
            if (!string.IsNullOrEmpty(SearchString))
            {
                recherche = recherche.Where(d => d.NameTirelire.Contains(SearchString));
                return View(await recherche.ToListAsync());
            }
            
			return View(await recherche.ToListAsync()); 
        }

        //DeTAILS OK 
        /* public async Task<IActionResult> Details(int? id)
         {
             // Injecter dans le cookie un panier vide par défaut dans la page
             CookiePanier panier = new CookiePanier();
             string panierJson = JsonSerializer.Serialize(panier);

             Response.Cookies.Append("panier", panierJson);

             // Récupérer le premier élément d'une collection et faire null si aucun ne correspond aux conditions
             var tirelire = await _context.TirelireSet
                 .Include(t => t.DescriptionTirelire)
                 .ThenInclude(d => d.Detail)
                 .FirstOrDefaultAsync(t => t.Id == id);

             if (tirelire == null)
             {
                 return NotFound();
             }

             // Récupérer les URLs des images des tirelires de couleur rouge
             var imagesCouleur = await _context.TirelireSet
                 .Where(t => t.Couleur == tirelire.Couleur)
                 .Select(t => t.ImageUrlTirelire)
                 .ToListAsync();

             // Utiliser ViewBag pour passer les données des images de couleur à la vue
             ViewBag.ImagesCouleur = imagesCouleur;


             ViewBag.Panier = panier;

             // Retourner la vue avec le modèle de la tirelire
             return View(tirelire);
         }*/



        public async Task<IActionResult> Details(int? id)
        {
            // Injecter dans le cookie un panier vide par défaut dans la page


            // Récupérer le premier élément d'une collection et faire null si aucun ne correspond aux conditions
            var tirelire = await _context.TirelireSet
                .Include(t => t.DescriptionTirelire)
                .ThenInclude(d => d.Detail)
                .FirstOrDefaultAsync(t => t.Id == id); 
                

            if (tirelire == null)
            {
                return NotFound();
            }

            // Récupérer les URLs des images des tirelires de couleur rouge
            var imagesCouleur = await _context.TirelireSet
                .Where(t => t.Couleur == tirelire.Couleur)
                .Select(t => t.ImageUrlTirelire)
                .ToListAsync();

            // Utiliser ViewBag pour passer les données des images de couleur à la vue
            ViewBag.ImagesCouleur = imagesCouleur;
            ViewBag.TirelireData = tirelire ;
            ViewBag.IdDuPanierAjouter = id; 

            //var panierView = await CreatePanier();
            /* LignePanier pann = new LignePanier();
             pann.Add(tirelire);*/
           

            //return new JsonResult(p);

            return View(tirelire); 
        }


       


        [HttpPost]
        public ActionResult CreateCheckout(int ? Id)
        {
            
            /*List<PanierItem> p = new List<PanierItem>
            {
                new PanierItem
                {
                   Id = 1,
                   Quantite = 2,
                   Frais = 3
                }
            };*/
            List<PanierItem> p = new List<PanierItem>
            {
                new PanierItem  {
                   Id = 1,
                   Quantite = 2,
                   Frais = 3  } };
            
            if (p == null)
            {
                return NotFound();
            };

            
            //return new JsonResult(p);
            //*var recherche = from d in _context.TirelireSet
                            //select d;
           
            
            return View(p);





        }
        public IActionResult Admin()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
