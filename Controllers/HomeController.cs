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
using Microsoft.AspNetCore.Authorization;







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



        [HttpGet]
       // [Authorize]
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

            // passe les données des images de couleur à la vue
            ViewBag.ImagesCouleur = imagesCouleur;


            var getIdDetails = await _context.DescriptionSet
                .Where(i => i.IdTirelire == id)
                .Select(i => i.IdDetail)
                .ToListAsync();

            //vérification si l'ID existe dans la liste des ID récupérés
            var ContenuDetail = await (from d in _context.DetailTireliresSet
                                       where getIdDetails.Contains(d.Id)
                                       select d).ToListAsync();
            // Si vous avez plusieurs détails, choisissez-en un, par exemple le premier
            var detail = ContenuDetail.FirstOrDefault();
            //modif 
            /* var modelview = new List<PanierItem>();
            // ViewBag.PanierView = modelview;*//*
            if (modelview != null)
            {
                // Rediriger vers une action dans un autre contrôleur
                return RedirectToAction("CreateCheckout", "Panier");
            }*

            /var panierView = await CreatePanier();
            /* LignePanier pann = new LignePanier();
             pann.Add(tirelire);*/


            //return new JsonResult(p);
            List<PanierItem> MaListe = new List<PanierItem>
            {

            };
            PanierItem pan = new()
            {
                t = tirelire,
                Count = 0,
                IdTirelire = tirelire.Id,
                d = detail


            };

            return View(pan); 
        }
        [HttpPost]
        //fait rentrer les donner en quelque sorte
        //[Authorize] : exige l'authentification 
        //c'est celui ci qui va faire fonctionner le bouton 
        public async Task<IActionResult>  Details(PanierItem p  )
        {

            p.Count = 1;
            p.Frais = 3;

            var imagesCouleur = await _context.TirelireSet
               .Where(t => t.Couleur == p.t.Couleur)
               .Select(t => t.ImageUrlTirelire)
               .ToListAsync();

            // Passe les données des images de couleur à la vue
            ViewBag.ImagesCouleur = imagesCouleur;


            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id , PanierItem p )
        {
            var pandelete = p.ToString(); 
             // Redirigez vers la liste des objets après suppression
             return View(pandelete);
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
