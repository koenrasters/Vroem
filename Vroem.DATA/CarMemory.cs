using System;
using System.Collections.Generic;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class CarMemory : ICar
    {
        public bool AddValueToEntity(string entity, string name, int? id)
        {
            if (entity == null || name == null)
            {
                return false;
            }

            if (entity == "model")
            {
                if (id == null)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetIdEntity(string entity, string naam)
        {
            if (entity == null || naam == null)
            {
                return -1;
            }

            var model = new List<string>
            {
                "Ka",
                "206"
            };

            if (entity == "model")
            {
                if (model.Contains(naam))
                {
                    return model.IndexOf(naam);
                }
            }

            return -1;
        }

        public bool AddCar(Car auto, int model, int merk, int brandstof, int transmissie, int kleur, int carroserie)
        {
            if (auto == null)
            {
                return false;
            }

            if (model == 0 || merk == 0 || brandstof == 0 || transmissie == 0 || kleur == 0 || carroserie == 0)
            {
                return false;
            }

            return true;
        }

        public string GetNameEntity(string entity, int id)
        {
            if (entity == null || id == 0)
            {
                return null;
            }

            var merk = new List<string>
            {
                "Peugeot",
                "Ford"
            };

            if (entity == "merk")
            {
                return merk[id];
            }

            return null;
        }

        public List<Car> GetCars()
        {
            var list = new List<Car>
            {
                new Car
                {
                    Beschrijving = "Test",
                    Titel = "Unit",
                    Bieden = false,
                    Bouwjaar = 0,
                    Brandstof = " ",
                    Carroserie = " ",
                    DatumGeregistreerd = DateTime.Now,
                    GebruikerID = 1,
                    Kenteken = " ",
                    Kilometerstand = 0,
                    Vermogen = 0
                }
            };
            return list;
        }

        public Car GetCar(int id)
        {
            var list = new List<Car>
            {
                null,
                new Car
                {
                    Beschrijving = "Test",
                    Titel = "Unit",
                    Bieden = true,
                    Bouwjaar = 0,
                    Brandstof = " ",
                    Carroserie = " ",
                    DatumGeregistreerd = DateTime.Now,
                    GebruikerID = 1,
                    Kenteken = " ",
                    Kilometerstand = 0,
                    Vermogen = 0,
                    Prijs = 10
                }
            };

            return list[id];

        }

        public int GetLatestCarId()
        {
            return 1;
        }

        public bool SaveImage(Afbeelding afbeelding, int id)
        {
            if (afbeelding.Bestand == null || id == 0)
            {
                return false;
            }
            return true;
        }

        public List<Afbeelding> GetImages(int id)
        {
            var templist = new List<List<Afbeelding>>();
            var afbeeldinglijst = new List<Afbeelding>
            {
                new Afbeelding
                {
                    Bestand = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
                }
            };
            templist.Add(new List<Afbeelding>());
            templist.Add(afbeeldinglijst);

            return templist[id];
        }

        public Afbeelding GetFirstImage(int id)
        {
            var afbeeldinglijst = new List<Afbeelding>
            {
                null,
                new Afbeelding
                {
                    Bestand = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
                }
            };
            return afbeeldinglijst[id];
        }
    }
}