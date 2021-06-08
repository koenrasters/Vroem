using System.Collections.Generic;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class RegistreerMemory : IRegistreer
    {
        private List<User> users = new List<User>
        {
            new User
            {
                Id = 0,
                Gebruikersnaam = "unit",
                Achternaam = "Test",
                Admin = 0,
                Email = "koen@gmail.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit"
            },
            new User
            {
                Id = 1,
                Gebruikersnaam = "test",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit"
            }
        };

        public bool Registreer(User us)
        {
            if (us == null || us.Email == null || us.Gebruikersnaam == null)
            {
                return false;
            }
            
            int indexEmail = users.FindIndex(u => u.Email == us.Email);
            int indexGebruikersnaam = users.FindIndex(u => u.Gebruikersnaam == us.Gebruikersnaam);
            if (indexEmail >=0 || indexGebruikersnaam >=0)
            {
                return false;
            }

            return true;
        }

        public bool CheckEmailExists(string email)
        {
            if (email == null)
            {
                return true;
            }

            int index = users.FindIndex(u => u.Email == email);

            if (index>=0)
            {
                return false;
            }

            return true;
        }

        public bool CheckUsernameExists(string gebruikersnaam)
        {
            if (gebruikersnaam == null)
            {
                return true;
            }
            int index = users.FindIndex(u => u.Gebruikersnaam == gebruikersnaam);

            if (index>=0)
            {
                return false;
            }

            return true;
        }
    }
}