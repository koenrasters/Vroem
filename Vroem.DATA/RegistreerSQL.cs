using System;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class RegistreerSQL : IRegistreer
    {
        private readonly DatabaseConnection _con = new DatabaseConnection();

        public bool Registreer(User us)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO gebruiker(Voornaam, Achternaam, Email, Gebruikersnaam, Wachtwoord, Woonplaats, Telefoonnummer, Admin) VALUES(@name, @lastname, @email, @username, @password, @adres, @number, 0)";
                command.Parameters.AddWithValue("@name", us.Voornaam);
                command.Parameters.AddWithValue("@lastname", us.Achternaam);
                command.Parameters.AddWithValue("@email", us.Email);
                command.Parameters.AddWithValue("@username", us.Gebruikersnaam);
                command.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.EnhancedHashPassword(us.Wachtwoord));
                command.Parameters.AddWithValue("@adres", us.Woonplaats);
                command.Parameters.AddWithValue("@number", us.Telefoonnummer);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns true when reader has no rows
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmailExists(string email)
        {
            if (email == null)
            {
                return true;
            }
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Email, Gebruikersnaam FROM gebruiker WHERE Email = @email";
            command.Parameters.AddWithValue("@email", email);
            using var reader = command.ExecuteReader();
            var uniekemail = !reader.HasRows;
            return (uniekemail);
        }

        /// <summary>
        /// Returns true when reader has no rows
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        /// <returns></returns>
        public bool CheckUsernameExists(string gebruikersnaam)
        {
            if (gebruikersnaam == null)
            {
                return true;
            }
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Email, Gebruikersnaam FROM gebruiker WHERE Gebruikersnaam = @username";
            command.Parameters.AddWithValue("@username", gebruikersnaam);
            using var reader = command.ExecuteReader();
            var uniekuser = !reader.HasRows;
            return (uniekuser);

        }

    }
}