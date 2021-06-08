using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vroem.MODELS;

namespace Vroem.MVC.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Vul een voornaam in")]
        [DisplayName("Voornaam")]
        public string Voornaam { get; set; }
        [Required(ErrorMessage = "Vul een achternaam in")]
        [DisplayName("Achternaam")]
        public string Achternaam { get; set; }
        [Required(ErrorMessage = "Vul een e-mailadres in")]
        [DisplayName("E-mailadres")]
        [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vul een gebruikersnaam in")]
        [DisplayName("Gebruikersnaam")]
        public string Gebruikersnaam { get; set; }
        [Required(ErrorMessage = "Vul een wachtwoord in")]
        [DisplayName("Wachtwoord")]
        public string Wachtwoord { get; set; }
        [Required(ErrorMessage = "Vul een wachtwoord in")]
        [DisplayName("Herhaal Wachtwoord")]
        [Compare("Wachtwoord", ErrorMessage = "Wachtwoorden zijn niet gelijk")]
        public string HerhaalWachtwoord { get; set; }
        [Required(ErrorMessage = "Vul een woonplaats in")]
        [DisplayName("Woonplaats")]
        public string Woonplaats { get; set; }
        [Required(ErrorMessage = "Vul een telefoonnummer in")]
        [DisplayName("Telefoonnummer")]
        [Phone]
        [MinLength(10), MaxLength(12)]
        public string Telefoonnummer { get; set; }

    }
}
