using System;

namespace Vroem.MODELS
{
    public class Car
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string Kenteken { get; set; }
        public int? Bouwjaar { get; set; }
        public int? Kilometerstand { get; set; }
        public int? Vermogen { get; set; }
        public string Merk { get; set; }
        public string Model { get; set; }
        public string Brandstof { get; set; }
        public string Transmissie { get; set; }
        public string Kleur { get; set; }
        public string Carroserie { get; set; }
        public int? Prijs { get; set; }
        public DateTime? DatumGeregistreerd { get; set; }
        public int GebruikerID { get; set; }
        public bool Bieden { get; set; }

    }
}
