namespace Vroem.MODELS
{
    public class User
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Woonplaats { get; set; }
        public string Telefoonnummer { get; set; }
        public int Admin { get; set; }
    }

}
