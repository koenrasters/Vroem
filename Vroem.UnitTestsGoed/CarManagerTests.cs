using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DAL;
using Vroem.LOGIC;
using Vroem.MODELS;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class CarManagerTests
    {
        private readonly CarManager car = new CarManager(new DataAccess("mem"));
        [TestMethod] 
        public void GetCarInfo_KentekenNull_ReturnsNull()
        {
            //Arrange
            string kenteken = null;
            //Act
            var auto = car.GetCarInfo(kenteken);
            //Assert
            Assert.IsNull(auto);
        }
        
        [TestMethod] 
        public void GetCarInfo_KentekenBestaatNiet_ReturnsNull()
        {
            //Arrange
            string kenteken = "AAAAAA";
            //Act
            var auto = car.GetCarInfo(kenteken);
            //Assert
            Assert.IsNull(auto);
        }
        
        [TestMethod] 
        public void GetCarInfo_KentekenBestaat_ReturnsCar()
        {
            //Arrange
            string kenteken = "59snxl";
            //Act
            var auto = car.GetCarInfo(kenteken);
            //Assert
            Assert.IsNotNull(auto);
        }
        
        [TestMethod] 
        public void AddCar_Null_ReturnsFalse()
        {
            //Arrange
            Car auto = null;
            List<IFormFile> afbeeldingen = null;
            //Act
            var actual = car.AddCar(auto, afbeeldingen);
            //Assert
            Assert.AreEqual(false, actual);
        }
        
        [TestMethod] 
        public void AddCar_AutoNullAfbeeldingenNiet_ReturnsFalse()
        {
            //Arrange
            Car auto = null;
            var afbeeldingen = new List<IFormFile>
            {
                new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.png")
            };
            //Act
            var actual = car.AddCar(auto, afbeeldingen);
            //Assert
            Assert.AreEqual(false, actual);
        }
        
        [TestMethod] 
        public void AddCar_AfbeeldingenNullAutoNiet_ReturnsFalse()
        {
            //Arrange
            var auto = new Car
            {
                Beschrijving = " ",
                Titel = " ",
                Bieden = false,
                Bouwjaar = 0,
                DatumGeregistreerd = DateTime.Now,
                GebruikerID = 1,
                Kenteken = " ",
                Kilometerstand = 0,
                Vermogen = 0,
                Merk = "Unit",
                Model = "Test",
                Transmissie = "Handgeschakeld",
                Brandstof = " ",
                Carroserie = " ",
                Kleur = "Zwart",
                Prijs = 0
            };
            List<IFormFile> afbeeldingen = null;
            //Act
            var actual = car.AddCar(auto, afbeeldingen);
            //Assert
            Assert.AreEqual(false, actual);
        }
        
        [TestMethod] 
        public void AddCar_Klopt_ReturnsTrue()
        {
            //Arrange
            var auto = new Car
            {
                Beschrijving = " ",
                Titel = " ",
                Bieden = false,
                Bouwjaar = 0,
                DatumGeregistreerd = DateTime.Now,
                GebruikerID = 1,
                Kenteken = " ",
                Kilometerstand = 0,
                Vermogen = 0,
                Merk = "Unit",
                Model = "Test",
                Transmissie = "Handgeschakeld",
                Brandstof = "Benzine",
                Carroserie = "Hatchback",
                Kleur = "Zwart",
                Prijs = 0
            };
            var afbeeldingen = new List<IFormFile>
            {
                new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.png")
            };
            //Act
            var actual = car.AddCar(auto, afbeeldingen);
            //Assert
            Assert.AreEqual(true, actual);
        }
        
        [TestMethod] 
        public void GetCars_ReturnsTrue()
        {
            //Arrange
            //Act
            var list = car.GetCars();
            //Assert
            Assert.IsTrue(list.Any());
        }
        
        [TestMethod] 
        public void GetCar_VerkeerdId_ReturnsNull()
        {
            //Arrange
            int id = 0;
            //Act
            var auto = car.GetCar(id);
            //Assert
            Assert.IsNull(auto);
        }
        
        [TestMethod] 
        public void GetCar_GoedId_ReturnsCar()
        {
            //Arrange
            int id = 1;
            //Act
            var auto = car.GetCar(id);
            //Assert
            Assert.IsNotNull(auto);
        }
        
        [TestMethod] 
        public void GetImages_VerkeerdId_ReturnsEmptyList()
        {
            //Arrange
            int id = 0;
            //Act
            var afbeelding = car.GetImages(id);
            //Assert
            Assert.IsFalse(afbeelding.Any());
        }
        
        [TestMethod] 
        public void GetImages_GoedId_ReturnsList()
        {
            //Arrange
            int id = 1;
            //Act
            var afbeelding = car.GetImages(id);
            //Assert
            Assert.IsTrue(afbeelding.Any());
        }
        
        [TestMethod] 
        public void GetFirstImage_VerkeerdId_ReturnsNull()
        {
            //Arrange
            int id = 0;
            //Act
            var afbeelding = car.GetFirstImage(id);
            //Assert
            Assert.IsNull(afbeelding);
        }
        
        [TestMethod] 
        public void GetFirstImage_GoedId_ReturnsAfbeelding()
        {
            //Arrange
            int id = 1;
            //Act
            var afbeelding = car.GetFirstImage(id);
            //Assert
            Assert.IsNotNull(afbeelding);
        }
        
    }
}