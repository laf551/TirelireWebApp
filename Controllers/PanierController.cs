using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TirelireWebApp.Models;
using TirelireWebApp.Models.Panier;

namespace TirelireWebApp.Controllers
{
    public class PanierController : Controller
    {

        /*public IActionResult Index()
        {
            return View();
        }*/
        [HttpPost]
        public ActionResult CreateCheckout()
        {

            /*List<PanierItem> p = new List<PanierItem>
            {
                new PanierItem
                {
                   Id = 1,
                   Quantite = 2,
                   Frais = 3
                }
            };
            if (p == null)
            {
                return NotFound();
            };

            ViewData["hi"] = p.ToList();*/
            //return new JsonResult(p);
            return View();
               
               
               

           
        }
    }
}
