using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vroem.MVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vul een e-mailadres of gebruikersnaam in")]
        [DisplayName("E-mailadres/Gebruikersnaam")]
        public string LoginString { get; set; }
        [Required(ErrorMessage = "Vul een wachtwoord in")]
        [DisplayName("Wachtwoord")]
        public string Wachtwoord { get; set; }
        [DisplayName("Blijf ingelogd")]
        public bool Persistent { get; set; }
    }
}
