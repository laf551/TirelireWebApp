using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TirelireWebApp.Data;
using TirelireWebApp.Models;



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

        /*public IActionResult Index()
        {
            return View();
        }*/
       /* public async Task<IActionResult> Details(int? IdBtnTirelire)
        {
            var rqt = await _context.TirelireSet
                .Include(d => d.DescriptionTirelire)//chargé avec tirelire
                .ThenInclude(i => i.Detail) //inclus sous-niveaux
                .FirstOrDefaultAsync(t => t.Id == IdBtnTirelire); //rqt LINQ: FirstOrDefaultAsync pour recup un elt unique du BD 

            if (rqt == null)
            {
                return NotFound();
            }

            return View(rqt);
        }*/

        public async Task<IActionResult> Details(int? id)

        {
            //récupérer le premier élément d'une collection faire  null si aucun ne correspond au condition
            var dish = await _context.TirelireSet
                 .Include(di => di.DescriptionTirelire)
                 .ThenInclude(i => i.Detail)
                 .FirstOrDefaultAsync(x => x.Id == id);
            //awiat : elle permet d'exécuter cette opération de manière asynchrone, libérant ainsi le thread d'appel
            //pour d'autres tâches pendant l'attente de la réponse de la base de données.
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }


        /*public IActionResult Details()
		{
			return View();
		}*/

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
