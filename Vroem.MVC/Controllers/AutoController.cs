using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Vroem.DAL;
using Vroem.LOGIC;
using Vroem.MODELS;
using Vroem.MVC.Models;

namespace Vroem.MVC.Controllers
{
    [Authorize(Roles = "1")]
    public class AutoController : Controller
    {
        private readonly CarManager _carManager = new CarManager(new DataAccess("db"));
        private readonly UserManager _userManager = new UserManager(new DataAccess("db"));
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewData["Auto"] = _carManager.GetCar(id);
            ViewData["Afbeelding"] = _carManager.GetImages(id);
            ViewData["Biedingen"] = _userManager.GetBids(id);
            return View();
        }

        [HttpPost]
        public IActionResult Index(BodViewModel bod)
        {
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (_userManager.BidOnCar(userId, bod.Prijs, bod.AutoID))
                {
                    return RedirectToAction("Index", new {bod.AutoID});
                }
                else
                {
                    ModelState.AddModelError("Prijs", "Vul een prijs hoger in dan het hoogste bod en een hoger bod dan de biedprijs");
                    ViewData["Auto"] = _carManager.GetCar(bod.AutoID);
                    ViewData["Afbeelding"] = _carManager.GetImages(bod.AutoID);
                    ViewData["Biedingen"] = _userManager.GetBids(bod.AutoID);
                    return View(bod);
                }
            }
            else
            {
                return RedirectToAction("Index", new {bod.AutoID});
            }
        }

        [HttpGet]
        public IActionResult Kenteken()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Kenteken(string kenteken)
        {
            if (_carManager.GetCarInfo(kenteken) == null)
            {
                ModelState.AddModelError("Kenteken", "Dit kenteken kan niet gevonden worden");
                return View();
            }
            else
            {
                var auto = kenteken;
                return RedirectToAction("Plaats", new {kenteken = auto});
                //return View("Plaats");
            }
        }

        [HttpGet]
        public IActionResult Plaats(string kenteken)
        {
            ViewData["Auto"] = _carManager.GetCarInfo(kenteken);
            var test = TempData["Carview"];
            TempData.Clear();
            
            CarViewModel carViewModel = null;
            if (test is string json)
            {
                carViewModel = JsonConvert.DeserializeObject<CarViewModel>(json);
                const string error = "Voeg minimaal 1 afbeelding toe";
                ModelState.AddModelError("Afbeelding", error);
                return View(carViewModel);
            }
            else
            {
                return View();
            }
        }
        
        [HttpPost]
        public IActionResult Plaats(CarViewModel auto)
        {
            var tempafbeeldingen = auto.Afbeelding;
            if (auto.Afbeelding == null)
            {
                TempData["Carview"] = JsonConvert.SerializeObject(auto);
                return RedirectToAction("Plaats", new {kenteken = auto.Kenteken});
            }
            else
            {
                auto.Afbeelding = null;
            }
            TempData["Carview"] = JsonConvert.SerializeObject(auto);
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var registreerAuto = new Car
                {
                    GebruikerID = userId,
                    Titel = auto.Titel,
                    Beschrijving = auto.Beschrijving,
                    Bouwjaar = auto.Bouwjaar,
                    Kilometerstand = auto.Kilometerstand,
                    Vermogen = auto.Vermogen,
                    Merk = auto.Merk,
                    Model = auto.Model,
                    Brandstof = auto.Brandstof,
                    Transmissie = auto.Transmissie,
                    Kleur = auto.Kleur,
                    Carroserie = auto.Carroserie,
                    Kenteken = auto.Kenteken,
                    Prijs = auto.Prijs,
                    Bieden = auto.Bieden
                };
                
                if (_carManager.AddCar(registreerAuto, tempafbeeldingen))
                {
                    TempData.Clear();
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    return RedirectToAction("Plaats", new {kenteken = auto.Kenteken});
                }
            }
            else
            {
                return RedirectToAction("Plaats", new {kenteken = auto.Kenteken});
            }
            
        }
        
    }
}