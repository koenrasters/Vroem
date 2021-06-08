using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Vroem.DAL;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.LOGIC
{
    public class CarManager
    {
        private readonly ICarAPI _apiConnection;
        private readonly ICar _connection;
        private readonly IDataAccess _dataAccess;

        public CarManager(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _apiConnection = dataAccess.GetApiConnection();
            _connection = dataAccess.GetCar();
        }

        public Car GetCarInfo(string kenteken) 
        {
            return _apiConnection.GetCar(kenteken);
        }

        /// <summary>
        /// Eerst worden de koppeltabellen gevuld met de waarden van de auto. Daarna word de auto toegevoegd met de ID's van de tabellen
        /// </summary>
        /// <param name="auto"></param>
        /// <param name="tempafbeeldingen"></param>
        /// <returns></returns>
        public bool AddCar(Car auto, List<IFormFile> tempafbeeldingen)
        {
            try
            {
                _connection.AddValueToEntity("merk", auto.Merk, null);
                var merkID = _connection.GetIdEntity("merk", auto.Merk);
                _connection.AddValueToEntity("model", auto.Model, merkID);
                _connection.AddValueToEntity("brandstof", auto.Brandstof, null);
                _connection.AddValueToEntity("transmissie", auto.Transmissie, null);
                _connection.AddValueToEntity("kleur", auto.Kleur, null);
                _connection.AddValueToEntity("carroserie", auto.Carroserie, null);
                var modelID = _connection.GetIdEntity("model", auto.Model);
                var brandstofID = _connection.GetIdEntity("brandstof", auto.Brandstof);
                var transmissieID = _connection.GetIdEntity("transmissie", auto.Transmissie);
                var kleurID = _connection.GetIdEntity("kleur", auto.Kleur);
                var carroserieID = _connection.GetIdEntity("carroserie", auto.Carroserie);
                if (_connection.AddCar(auto, modelID, merkID, brandstofID, transmissieID, kleurID, carroserieID))
                {
                    var id = GetLatestCarId();
                    foreach (var afbeelding in tempafbeeldingen)
                    {
                        AddImagesToCar(afbeelding, id);
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
            return false;
        }

        public List<Car> GetCars()
        {
            return _connection.GetCars();
        }
        public Car GetCar(int id)
        {
            return _connection.GetCar(id);
        }

        public int GetLatestCarId()
        {
            return _connection.GetLatestCarId();
        }

        public void SaveImage(Afbeelding afbeelding, int id)
        {
            _connection.SaveImage(afbeelding, id);
        }

        public List<Afbeelding> GetImages(int id)
        {
            return _connection.GetImages(id);
        }

        public Afbeelding GetFirstImage(int id)
        {
            return _connection.GetFirstImage(id);
        }
        
        public void AddImagesToCar(IFormFile afbelding, int id)
        {
            var stream = new MemoryStream();
            afbelding.OpenReadStream().CopyTo(stream);
            var testt = stream.ToArray();
            var image = new Afbeelding
            {
                Bestand = testt
            };
            SaveImage(image, id);
        }

    }
}
