using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Vroem.DAL;
using Vroem.DATA;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.LOGIC
{
    public class LoginManager
    {
        private readonly IUser _user;
        private readonly ILogin _login;
        private readonly IDataAccess _dataAccess;

        public LoginManager(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _user = dataAccess.GetUser();
            _login = dataAccess.GetLogin();
        }

        /// <summary>
        /// Hiermee wordt de gebruiker ingelogd. Als de inloggegevens met de database kloppen dan word er een cookie aangemaakt.
        /// Dit gebeurt met een ClaimsPrincipal, hierin worden de gegevens van de persoon in opgeslagen zoals email en gebruikersnaam.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="persistent"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public StatusCodeEnum Login(string login, string password, bool persistent, HttpContext httpContext)
        {
            var statuscode = _login.VerifyUser(login, password);
            if (statuscode == StatusCodeEnum.GegevensKloppen)
            {
                var authProperties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = persistent,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1)
                };
                var userPrincipal = GetPrincipal(login);
                httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties); 
                return StatusCodeEnum.GegevensKloppen;
            }
            else
            {
                return statuscode;
            }
            
        }

        public ClaimsPrincipal GetPrincipal(string login)
        {
            var user = _user.GetUser(login);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Voornaam),
                new Claim(ClaimTypes.Surname, user.Achternaam),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Gebruikersnaam),
                new Claim(ClaimTypes.Role, user.Admin.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(identity);
            return userPrincipal;
        }

        public void SignOut(HttpContext httpContext)
        {
            httpContext.SignOutAsync();
        }


    }
}
