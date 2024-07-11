using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TirelireWebApp.Data;
using TirelireWebApp.Models;


namespace TirelireController.Controllers
{
    public class TirelireController : Controller
    {
        //ILogger : journal pour enregistrer les infos important de l'app
        private readonly ILogger<TirelireController> _logger;

        private readonly TirelireContext _context;
        public TirelireController(ILogger<TirelireController> logger, TirelireContext context)
        {
            //constructeur
            _logger = logger;
            _context = context;
        }

       /* public async Task<IActionResult> De( int ? IdBtnTirelire)
        {
            var rqt = await _context.TirelireSet
                .Include(d => d.DescriptionTirelire)//chargé avec tirelire
                .ThenInclude (i => i.Detail) //inclus sous-niveaux
                .FirstOrDefaultAsync(t => t.Id == IdBtnTirelire); //rqt LINQ: FirstOrDefaultAsync pour recup un elt unique du BD 
            
            if (rqt == null)
            {
                return NotFound();
            }

            return View(rqt);
        }

        public async Task<IActionResult> Index()
        {
            var tirelireView = await _context.TirelireSet.ToListAsync();
            return View(tirelireView);
        }*/



    }
}
