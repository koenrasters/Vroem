using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vroem.DAL;
using Vroem.DATA;
using Vroem.LOGIC;
using Vroem.MODELS;
using Vroem.MVC.Models;

namespace Vroem.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly RegistreerManager _gebruiker = new RegistreerManager(new DataAccess("db"));
        private readonly LoginManager _login = new LoginManager(new DataAccess("db"));
        private readonly UserManager _user = new UserManager(new DataAccess("db"));

        [HttpGet]
        public IActionResult Registreer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registreer(AccountViewModel us)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Voornaam = us.Voornaam,
                    Achternaam = us.Achternaam,
                    Email = us.Email,
                    Gebruikersnaam = us.Gebruikersnaam,
                    Wachtwoord = us.Wachtwoord,
                    Telefoonnummer = us.Telefoonnummer,
                    Woonplaats = us.Woonplaats
                };
                switch (_gebruiker.Registreer(user))
                {
                    case StatusCodeEnum.GebruikerAangemaakt:
                        return RedirectToAction("Index", "Home");
                    case StatusCodeEnum.EmailBestaat:
                        ModelState.AddModelError("Email", "Dit e-mailadres is al in gebruik");
                        return View(us);
                    case StatusCodeEnum.GebruikerBestaat:
                        ModelState.AddModelError("Gebruikersnaam", "Deze gebruikersnaam is al in gebruik");
                        return View(us);
                    case StatusCodeEnum.GebruikerNietAangemaakt:
                        ModelState.AddModelError("Gebruikersnaam", "Deze gebruikersnaam is al in gebruik");
                        ModelState.AddModelError("Email", "Dit e-mailadres is al in gebruik");
                        return View(us);
                }
            }

            return View(us);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                switch (_login.Login(login.LoginString, login.Wachtwoord, login.Persistent, HttpContext))
                {
                    case StatusCodeEnum.GegevensKloppen:
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    case StatusCodeEnum.LoginKloptNiet:
                        ModelState.AddModelError("LoginString", "Deze gegevens zijn niet gevonden");
                        return View(login);
                    case StatusCodeEnum.WachtwoordKloptNiet:
                        ModelState.AddModelError("Wachtwoord", "Dit wachtwoord is niet correct");
                        return View(login);
                }
            }

            return View(login);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Bewerk()
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ViewData["Gebruiker"] = _user.GetUser(userId);
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Bewerk(AccountViewModel account, string gegevens)
        {
            if (gegevens == "user")
            {
                var user = new User
                {
                    Voornaam = account.Voornaam,
                    Achternaam = account.Achternaam,
                    Email = account.Email,
                    Gebruikersnaam = account.Gebruikersnaam,
                    Wachtwoord = account.Wachtwoord,
                    Telefoonnummer = account.Telefoonnummer,
                    Woonplaats = account.Woonplaats
                };
                user.Id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                if (_user.EditAccount(user))
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Bewerk", "Account");
                }
            }
            else
            {
                var user = new User
                {
                    Wachtwoord = account.Wachtwoord
                };
                user.Id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (_user.EditPassword(user))
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Bewerk", "Account");
                }
            }
        }

        public IActionResult SignOut()
        {
            _login.SignOut(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}