using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Vroem.MODELS;

namespace Vroem.MVC.Models
{
    public class CarViewModel
    {
        [Required(ErrorMessage = "Vul een titel in")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Vul een beschrijving in")]
        public string Beschrijving { get; set; }
        [Required(ErrorMessage = "Vul het kenteken in")]
        public string Kenteken { get; set; }
        [Required(ErrorMessage = "Vul het bouwjaar van uw auto in")]
        [Range(1900, 3000, ErrorMessage = "Vul een geldig jaar in")]
        public int Bouwjaar { get; set; }
        [Required(ErrorMessage = "Vul de kilometerstand van uw auto in")]
        [Range(0, 1000000, ErrorMessage = "Vul een geldige kilometerstand in")]
        public int Kilometerstand { get; set; }
        [Required(ErrorMessage = "Vul het vermogen van uw auto in in")]
        [Range(0, 10000,ErrorMessage = "Vul een geldig vermogen in")]
        public int Vermogen { get; set; }
        [Required(ErrorMessage = "Vul het merk van uw auto in")]
        public string Merk { get; set; }
        [Required(ErrorMessage = "Vul het model van uw auto in")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Vul de brandstof van uw auto in")]
        public string Brandstof { get; set; }
        [Required(ErrorMessage = "Vul transmissie van uw auto in")]
        public string Transmissie { get; set; }
        [Required]
        public string Kleur { get; set; }
        [Required]
        public string Carroserie { get; set; }
        public int? Prijs { get; set; }
        [Required]
        public bool Bieden { get; set; }
        [Required]
        public List<IFormFile> Afbeelding { get; set; }
    }
}