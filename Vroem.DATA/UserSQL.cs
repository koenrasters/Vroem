using System;
using System.Collections.Generic;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class UserSQL : IUser
    {
        private readonly DatabaseConnection _con = new DatabaseConnection();

        public User GetUser(int id)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM gebruiker WHERE ID=@id";
                command.Parameters.AddWithValue("@id", id);
                using var reader = command.ExecuteReader();
                reader.Read();

                var user = new User()
                {
                    Id = reader.GetInt32("ID"),
                    Voornaam = reader.GetString("Voornaam"),
                    Achternaam = reader.GetString("Achternaam"),
                    Email = reader.GetString("Email"),
                    Gebruikersnaam = reader.GetString("Gebruikersnaam"),
                    Woonplaats = reader.GetString("Woonplaats"),
                    Telefoonnummer = reader.GetString("Telefoonnummer"),
                    Admin = reader.GetInt32("Admin")
                };
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public User GetUser(string login)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                if (login.Contains("@"))
                {
                    command.CommandText = "SELECT * FROM gebruiker WHERE Email=@email";
                    command.Parameters.AddWithValue("@email", login);
                }
                else
                {
                    command.CommandText = "SELECT * FROM gebruiker WHERE Gebruikersnaam=@username";
                    command.Parameters.AddWithValue("@username", login);
                }

                using var reader = command.ExecuteReader();
                reader.Read();

                var user = new User()
                {
                    Id = reader.GetInt32("ID"),
                    Voornaam = reader.GetString("Voornaam"),
                    Achternaam = reader.GetString("Achternaam"),
                    Email = reader.GetString("Email"),
                    Gebruikersnaam = reader.GetString("Gebruikersnaam"),
                    Woonplaats = reader.GetString("Woonplaats"),
                    Telefoonnummer = reader.GetString("Telefoonnummer"),
                    Admin = reader.GetInt32("Admin")
                };
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM gebruiker";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var user = new User()
                {
                    Id = reader.GetInt32("ID"),
                    Voornaam = reader.GetString("Voornaam"),
                    Achternaam = reader.GetString("Achternaam"),
                    Email = reader.GetString("Email"),
                    Gebruikersnaam = reader.GetString("Gebruikersnaam"),
                    Woonplaats = reader.GetString("Woonplaats"),
                    Telefoonnummer = reader.GetString("Telefoonnummer"),
                    Admin = reader.GetInt32("Admin")
                };
                users.Add(user);
            }

            return users;
        }

        public bool EditAccount(User us)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText =
                    "UPDATE gebruiker SET Voornaam=@name, Achternaam=@lastname, Email=@email, Gebruikersnaam=@username, Woonplaats=@adres, Telefoonnummer=@number WHERE ID=@id";
                command.Parameters.AddWithValue("@name", us.Voornaam);
                command.Parameters.AddWithValue("@lastname", us.Achternaam);
                command.Parameters.AddWithValue("@email", us.Email);
                command.Parameters.AddWithValue("@username", us.Gebruikersnaam);
                command.Parameters.AddWithValue("@adres", us.Woonplaats);
                command.Parameters.AddWithValue("@number", us.Telefoonnummer);
                command.Parameters.AddWithValue("@id", us.Id);
                if (command.ExecuteNonQuery() == 0)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool EditPassword(User us)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText =
                    "UPDATE gebruiker SET Wachtwoord=@password WHERE ID=@id";
                command.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.EnhancedHashPassword(us.Wachtwoord));
                command.Parameters.AddWithValue("@id", us.Id);
                if (command.ExecuteNonQuery() == 0)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool BidOnCar(int usID, int price, int carID)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO bod(Gebruiker_ID, Auto_ID, Prijs, Datum) VALUES(@userID, @carID, @price, @date)";
                command.Parameters.AddWithValue("@userID", usID);
                command.Parameters.AddWithValue("@carID", carID);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public List<Bod> GetBids(int carID)
        {
            List<Bod> templist = new List<Bod>();
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM bod WHERE Auto_ID=@id ORDER BY Prijs DESC";
            command.Parameters.AddWithValue("@id", carID);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var bod = new Bod()
                {
                    GebruikerID = reader.GetInt32("Gebruiker_ID"),
                    AutoID = reader.GetInt32("Auto_ID"),
                    Prijs = reader.GetInt32("Prijs"),
                    Datum = reader.GetDateTime("Datum")
                };
                templist.Add(bod);
            }

            return templist;
        }
    }
}