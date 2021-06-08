using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class LoginMemory : ILogin
    {
        private readonly User user = new User
        {
            Id = 0,
            Gebruikersnaam = "unit",
            Achternaam = "Test",
            Admin = 0,
            Email = "unit@test.com",
            Telefoonnummer = "0612344567",
            Wachtwoord = "Unit",
            Woonplaats = "Test",
            Voornaam = "Unit"
        };
        public StatusCodeEnum VerifyUser(string login, string password)
        {
            if (login == null || password == null)
            {
                return StatusCodeEnum.LoginKloptNiet;
            }

            if (login == user.Gebruikersnaam || login == user.Email)
            {
                if (password !=user.Wachtwoord)
                {
                    return StatusCodeEnum.WachtwoordKloptNiet;
                }
                else
                {
                    return StatusCodeEnum.GegevensKloppen;
                }
            }
            
            return StatusCodeEnum.LoginKloptNiet;
        }
    }
}