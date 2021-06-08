using System;
using System.Collections.Generic;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class UserMemory : IUser
    {
        public User GetUser(int id)
        {
            var list = new List<User>
            {
                null,
                new User
                {
                    Voornaam = "unit",
                    Achternaam = "test"
                }
            };
            return list[id];
        }

        public User GetUser(string login)
        {
            if (login==null)
            {
                return null;
            }

            var user = new User
            {
                Voornaam = "unit",
                Achternaam = "test",
                Email = "unit@test.nl",
                Gebruikersnaam = "unittest"
            };
            if (login.Contains("@") && login == user.Email)
            {
                return user;
            }
            else if (login == user.Gebruikersnaam)
            {
                return user;
            }
            return null;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    Voornaam = "unit",
                    Achternaam = "test",
                    Email = "unit@test.nl",
                    Gebruikersnaam = "unittest"
                }
            };
            return users;
        }

        public bool EditAccount(User us)
        {
            if (us == null)
            {
                return false;
            }

            var user = new User
            {
                Gebruikersnaam = "unittest",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit",
                Id = 1
            };

            if (us.Id != user.Id)
            {
                return false;
            }
            
            return true;
        }

        public bool EditPassword(User us)
        {
            if (us == null)
            {
                return false;
            }

            var user = new User
            {
                Gebruikersnaam = "unittest",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit",
                Id = 1
            };

            if (us.Id != user.Id)
            {
                return false;
            }
            
            return true;
        }

        public bool BidOnCar(int usID, int price, int carID)
        {
            var cars = new List<int> {1,2,3};
            var users = new List<int> {1,2,3};
            if (cars.Contains(carID) && users.Contains(usID))
            {
                return true;
            }

            return false;
        }

        public List<Bod> GetBids(int carID)
        {
            var templist = new List<List<Bod>>
            {
                new List<Bod>(),
                new List<Bod>
                {
                    new Bod()
                    {
                        GebruikerID = 1,
                        AutoID = 1,
                        Prijs = 100,
                        Datum = DateTime.Now
                    } 
                },
                new List<Bod>()
            };
            
            return templist[carID];
        }
    }
}