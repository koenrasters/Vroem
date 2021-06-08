using System.Collections.Generic;
using System.Text.RegularExpressions;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.API
{
    public class CarAPIMem : ICarAPI
    {
        private readonly List<Car> cars = new List<Car>
        {
            new Car
            {
                Bouwjaar = 2000,
                Vermogen = 100,
                Merk = "Peugeot",
                Model = "206",
                Kenteken = "77-DT-NH",
                Kleur = "Grijs",
                Brandstof = "Benzine",
                Carroserie = "Hatchback"
            },
            new Car
            {
                Bouwjaar = 2000,
                Vermogen = 100,
                Merk = "Ford",
                Model = "Ka",
                Kenteken = "59-SN-XL",
                Kleur = "Zwart",
                Brandstof = "Benzine",
                Carroserie = "Hatchback"
            }
        };
        public Car GetCar(string kenteken)
        {
            if (kenteken == null)
            {
                return null;
            }
            kenteken = kenteken.ToUpper();
            if (kenteken.Contains("-"))
            {
                kenteken = kenteken.Replace("-", "");
            }

            kenteken = GetOpmaak(kenteken);

            int index = cars.FindIndex(u => u.Kenteken == kenteken);

            if (index >=0)
            {
                return cars[index];
            }
            
            return null;
        }
        
        public string GetOpmaak(string kenteken)
        {
            string[] codeArray =
            {
                "^[a-zA-Z]{2}[0-9]{2}[0-9]{2}$", //   1       XX-99-99
                "^[0-9]{2}[0-9]{2}[a-zA-Z]{2}$", //   2       99-99-XX
                "^[0-9]{2}[a-zA-Z]{2}[0-9]{2}$", //   3       99-XX-99
                "^[a-zA-Z]{2}[0-9]{2}[a-zA-Z]{2}$", //   4       XX-99-XX
                "^[a-zA-Z]{2}[a-zA-Z]{2}[0-9]{2}$", //   5       XX-XX-99
                "^[0-9]{2}[a-zA-Z]{2}[a-zA-Z]{2}$", //   6       99-XX-XX
                "^[0-9]{2}[a-zA-Z]{3}[0-9]{1}$", //   7       99-XXX-9
                "^[0-9]{1}[a-zA-Z]{3}[0-9]{2}$", //   8       9-XXX-99
                "^[a-zA-Z]{2}[0-9]{3}[a-zA-Z]{1}$", //   9       XX-999-X
                "^[a-zA-Z]{1}[0-9]{3}[a-zA-Z]{2}$", //   10      X-999-XX
                "^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}$", //   11      XXX-99-X
                "^[a-zA-Z]{1}[0-9]{2}[a-zA-Z]{3}$", //   12      X-99-XXX
                "^[0-9]{1}[a-zA-Z]{2}[0-9]{3}$", //   13      9-XX-999
                "^[0-9]{3}[a-zA-Z]{2}[0-9]{1}$" //   14      999-XX-9	
            };
            int code = 0;
            for (int i = 0; i < codeArray.Length; i++)
            {
                if (Regex.IsMatch(kenteken, codeArray[i]))
                {
                    code = i + 1;
                }
            }

            if (code <= 6)
            {
                return kenteken.Substring(0, 2) + '-' + kenteken.Substring(2, 2) + '-' + kenteken.Substring(4, 2);
            }

            if (code == 7 || code == 9)
            {
                return kenteken.Substring(0, 2) + '-' + kenteken.Substring(2, 3) + '-' + kenteken.Substring(5, 1);
            }

            if (code == 8 || code == 10)
            {
                return kenteken.Substring(0, 1) + '-' + kenteken.Substring(1, 3) + '-' + kenteken.Substring(4, 2);
            }

            if (code == 11 || code == 14)
            {
                return kenteken.Substring(0, 3) + '-' + kenteken.Substring(3, 2) + '-' + kenteken.Substring(5, 1);
            }

            if (code == 12 || code == 13)
            {
                return kenteken.Substring(0, 1) + '-' + kenteken.Substring(1, 2) + '-' + kenteken.Substring(3, 3);
            }

            return kenteken;
        }
    }
}