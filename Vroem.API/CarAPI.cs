using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.API
{
    public class CarAPI : ICarAPI
    {
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

            var basicCarInfo = GetCarInfo(kenteken, "basic");
            var otherCarInfo = GetCarInfo(kenteken, "other");

            if (basicCarInfo != null && otherCarInfo != null)
            {
                var bouwjaar = DateTime.ParseExact((string) basicCarInfo["datum_eerste_toelating"], "yyyyMMdd",
                    CultureInfo.InvariantCulture).Year;
                var pkvermogen = 0;
                try
                {
                    pkvermogen = Convert.ToInt32((double) otherCarInfo["nettomaximumvermogen"] * 1.36);
                }
                catch (Exception e)
                {
                    pkvermogen = 0;
                }

                var merk = (string) basicCarInfo["merk"];
                merk = merk.First() + merk.Substring(1).ToLower();
                var model = (string) basicCarInfo["handelsbenaming"];
                if (!Char.IsDigit(model[0]))
                {
                    model = model.First() + model.Substring(1).ToLower();
                }

                var kleur = (string) basicCarInfo["eerste_kleur"];
                kleur = kleur.First() + kleur.Substring(1).ToLower();
                var brandstof = (string) otherCarInfo["brandstof_omschrijving"];
                var carrosserie = (string) basicCarInfo["inrichting"];
                var auto = new Car
                {
                    Bouwjaar = bouwjaar,
                    Vermogen = pkvermogen,
                    Merk = merk,
                    Model = model,
                    Kenteken = GetOpmaak(kenteken),
                    Kleur = kleur,
                    Brandstof = brandstof,
                    Carroserie = carrosserie.First().ToString().ToUpper() + carrosserie.Substring(1),
                };
                return auto;
            }
            else
            {
                return null;
            }
        }

        public JObject GetCarInfo(string kenteken, string info)
        {
            using (var client = new HttpClient())
            {
                if (info == "basic")
                {
                    client.BaseAddress = new Uri("https://opendata.rdw.nl/resource/m9d7-ebf2.json");
                }
                else
                {
                    client.BaseAddress = new Uri("https://opendata.rdw.nl/resource/8ys7-d773.json");
                }

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    client.GetAsync($"?$$app_token=rJHrisN8fs3DnuNPEZbOXTTwg&kenteken={kenteken}").Result;

                string json = response.Content.ReadAsStringAsync().Result;

                json = json.Replace("[", "").Replace("]", "");
                try
                {
                    JObject obj = JObject.Parse(json);
                    return obj;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
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