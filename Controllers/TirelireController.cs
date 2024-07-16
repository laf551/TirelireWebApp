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

       



    }
}
