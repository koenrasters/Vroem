using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class LoginSQL : ILogin
    {
        private readonly DatabaseConnection _con = new DatabaseConnection();
        public StatusCodeEnum VerifyUser(string login, string password)
        {
            if (login == null || password == null)
            {
                return StatusCodeEnum.LoginKloptNiet;
            }
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            if (login.Contains("@"))
            {
                command.CommandText = "SELECT Email, Wachtwoord FROM gebruiker WHERE Email=@email";
                command.Parameters.AddWithValue("@email", login);
            }
            else
            {
                command.CommandText = "SELECT Email, Wachtwoord FROM gebruiker WHERE Gebruikersnaam=@name";
                command.Parameters.AddWithValue("@name", login);
            }
            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var pass = reader.GetString("Wachtwoord");
                var check = BCrypt.Net.BCrypt.EnhancedVerify(password, pass);
                if (check)
                {
                    return StatusCodeEnum.GegevensKloppen;
                }
                else
                {
                    return StatusCodeEnum.WachtwoordKloptNiet;
                }
            }

            return StatusCodeEnum.LoginKloptNiet;
        }
    }

    
}
