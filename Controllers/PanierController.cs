using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using TirelireWebApp.Data;
using TirelireWebApp.Models;
using TirelireWebApp.Models.Panier;


namespace TirelireWebApp.Controllers
{
    public class PanierController : Controller
    {
        private readonly TirelireContext _context;

        

        public PanierController( TirelireContext context)
        {
            //constructeur
           
            _context = context;
        }

        private static List<PanierItem> p = new List<PanierItem>
        {
        new PanierItem
               {
                    Id = 1,
                    Quantite = 1,
                    Frais = 3,
                    t = new  Tirelire(), // tirelire objet
                    d =new  DetailTirelire()  // objet detail equivalent 
                    


                }
         };
        //modif

        public async Task<IActionResult>  CreateCheckout(int ? id )
        {
            

            var result = from d in _context.TirelireSet
                         select d;
            var tirelire = result.Where(t => t.Id == id).FirstOrDefault();

            
            // Récupérer les ID des détails de manière asynchrone
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

            if (detail == null)
            {
                // Gérer le cas où aucun détail n'est trouvé
                return null;
            }


            /*var rqt = dataDetail.Where(i => i.Id == recupIdDetail).FirstOrDefault();*/
            // d = tirelire.DescriptionTirelire; 

            List<PanierItem> p = new List<PanierItem>
            {
                //list 
                new PanierItem
                {
                    Id = 1,
                    Quantite = 1,
                    Frais = 3,
                    t = tirelire, // tirelire objet
                    d = detail  // objet detail equivalent 



                },
                new PanierItem
                {
                    Id = 2,
                    Quantite = 1,
                    Frais = 3,
                    t = tirelire, // tirelire objet
                    d = detail  // objet detail equivalent 



                }
            };
            if (tirelire == null)
            {

                return View(p);
            }
            // };

            //derniere modif 
            //var modelview = new List<PanierItem>);
            //ViewBag.Test = p; 
            // return PartialView("Home/Details.cshtml", p);
            return View(p); 
          



		}

        [HttpPost]
        public IActionResult Supprimer(int index)

        {
           // List<PanierItem> p = new List<PanierItem>();
            /*if (index >= 0 && index < p.Count)
            {
                p.RemoveAt(index);
            }
            return RedirectToAction("CreateCheckout");*/

            if (p == null)
            {
               // Debug.WriteLine("La liste '_panier' est null.");
                return BadRequest("La liste est introuvable.");
            }

            if (index < 0 || index >= p.Count)
            {
               // Debug.WriteLine($"Index invalide : {index}");
                return NotFound("Index invalide.");
            }
            try
            {
                p.RemoveAt(index);
                return RedirectToAction("CreateCheckout"); 


            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Erreur interne lors de la suppression.");
            }
        }


        /*[HttpPost]
        public IActionResult Ajouter(PanierItem pan)
        {
            PanierItem.Add(2, 1, 3, Tirelire t, // tirelire objet
                    DetailTirelire d); 
            return View(nameof(CreateCheckout)); 
        }*/
        /*[HttpPost]
        public ActionResult MettreAJour(int id, int quantite)
        {
            var item = panier.Find(p => p.Id == id);
            if (item != null)
            {
                item.MettreAJour(quantite, frais, new Tirelire { Description = tirelireDescription }, new DetailTirelire { Details = detailTirelireDetails });
            }
            return RedirectToAction("Index");
        }*/
    }
}
