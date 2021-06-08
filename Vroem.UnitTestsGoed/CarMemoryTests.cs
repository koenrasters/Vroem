using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DATA;
using Vroem.MODELS;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class CarMemoryTests
    {
        private readonly CarMemory carMem = new CarMemory();
        [TestMethod]
        public void AddValueToEntity_Null_ReturnsFalse()
        {
            //Arrange
            string entiteit = null;
            string merk = null;
            int? id = null;
            //Act
            var boolean = carMem.AddValueToEntity(entiteit, merk, id);
            //Assert
            Assert.AreEqual(false, boolean);
        }

        [TestMethod]
        public void AddValueToEntity_ModelBestaatAlMetRandomNummer_ReturnsTrue()
        {
            //Arrange
            string entiteit = "model";
            string model = "206";
            int? id = 3;
            //Act
            var boolean = carMem.AddValueToEntity(entiteit, model, id);
            //Assert
            Assert.AreEqual(true, boolean);
        }

        [TestMethod]
        public void AddValueToEntity_NieuwModelZonderMerkId_ReturnsFalse()
        {
            //Arrange
            string entiteit = "model";
            string model = "NieuweValue";
            int? id = null;
            //Act
            var boolean = carMem.AddValueToEntity(entiteit, model, id);
            //Assert
            Assert.AreEqual(false, boolean);
        }

        [TestMethod]
        public void AddValueToEntity_NieuwMerk_ReturnsTrue()
        {
            //Arrange
            string entiteit = "merk";
            string model = "NieuweValue";
            int? id = null;
            //Act
            var boolean = carMem.AddValueToEntity(entiteit, model, id);
            //Assert
            Assert.AreEqual(true, boolean);
        }

        [TestMethod]
        public void GetIdEntity_Null_ReturnsMinus1()
        {
            //Arrange
            string entiteit = null;
            string model = null;
            //Act
            var id = carMem.GetIdEntity(entiteit, model);
            //Assert
            Assert.AreEqual(-1, id);
        }

        [TestMethod]
        public void GetIdEntity_NietBestaandeModel_ReturnsMinus1()
        {
            //Arrange
            string entiteit = "model";
            string model = "Frikandel";
            //Act
            var id = carMem.GetIdEntity(entiteit, model);
            //Assert
            Assert.AreEqual(-1, id);
        }

        [TestMethod]
        public void GetIdEntity_ModelDatBestaat_ReturnsGreaterThanNull()
        {
            //Arrange
            string entiteit = "model";
            string model = "206";
            //Act
            var id = carMem.GetIdEntity(entiteit, model);
            //Assert
            Assert.IsTrue(id>0);
        }

        [TestMethod]
        public void AddCar_Null_ReturnsFalse()
        {
            //Arrange
            Car auto = null;
            int model = 0;
            int merk = 0;
            int brandstof = 0;
            int kleur = 0;
            int transmissie = 0;
            int carroserie = 0;
            //Act
            var boolean = carMem.AddCar(auto, model, merk, brandstof, transmissie, kleur, carroserie);
            //Assert
            Assert.AreEqual(false, boolean);
        }
        
        [TestMethod]
        public void AddCar_IDsBestaanNiet_ReturnsFalse()
        {
            //Arrange
            var auto = new Car
            {
                Beschrijving = " ",
                Titel = " ",
                Bieden = false,
                Bouwjaar = 0,
                Brandstof = " ",
                Carroserie = " ",
                DatumGeregistreerd = DateTime.Now,
                GebruikerID = 0,
                Kenteken = " ",
                Kilometerstand = 0,
                Vermogen = 0
            };
            int model = 0;
            int merk = 0;
            int brandstof = 0;
            int kleur = 0;
            int transmissie = 0;
            int carroserie = 0;
            //Act
            var boolean = carMem.AddCar(auto, model, merk, brandstof, transmissie, kleur, carroserie);
            //Assert
            Assert.AreEqual(false, boolean);
        }
        
        [TestMethod]
        public void AddCar_GoedeGegevens_ReturnsTrue()
        {
            //Arrange
            var auto = new Car
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
            };
            int model = 1;
            int merk = 1;
            int brandstof = 1;
            int kleur = 1;
            int transmissie = 1;
            int carroserie = 1;
            //Act
            var boolean = carMem.AddCar(auto, model, merk, brandstof, transmissie, kleur, carroserie);
            //Assert
            Assert.AreEqual(true, boolean);
        }
        
        [TestMethod]
        public void GetNameEntity_Null_ReturnsNull()
        {
            //Arrange
            string entiteit = null;
            int id = 0;
            //Act
            var name = carMem.GetNameEntity(entiteit, id);
            //Assert
            Assert.IsNull(name);
        }

        [TestMethod]
        public void GetNameEntity_NietBestaandeModel_ReturnsNull()
        {
            //Arrange
            string entiteit = "model";
            int id = 0;
            //Act
            var name = carMem.GetNameEntity(entiteit, id);
            //Assert
            Assert.IsNull(name);
        }

        [TestMethod]
        public void GetNameEntity_MerkDatBestaat_ReturnsValue()
        {
            //Arrange
            string entiteit = "merk";
            int id = 1;
            //Act
            var name = carMem.GetNameEntity(entiteit, id);
            //Assert
            Assert.IsNotNull(name);
        }

        [TestMethod]
        public void GetCars_ReturnsList()
        {
            //Arrange
            //Act
            var car = carMem.GetCars();
            //Assert
            Assert.IsTrue(car.Any());
        }
        
        [TestMethod]
        public void GetCar_IdBestaatNiet_ReturnsNull()
        {
            //Arrange
            var id = 0;
            //Act
            var car = carMem.GetCar(id);
            //Assert
            Assert.IsNull(car);
        }
        
        [TestMethod]
        public void GetCar_IdBestaat_ReturnsCar()
        {
            //Arrange
            var id = 1;
            //Act
            var car = carMem.GetCar(id);
            //Assert
            Assert.IsNotNull(car);
        }

        [TestMethod]
        public void GetLatestCarId_ReturnsGreaterThanNull()
        {
            //Arrange
            //Act
            var car = carMem.GetLatestCarId();
            //Assert
            Assert.IsTrue(car>0);
        }
        
        [TestMethod]
        public void GetImages_IdBestaatNiet_ReturnsEmptyList()
        {
            //Arrange
            var id = 0;
            //Act
            var car = carMem.GetImages(id);
            //Assert
            Assert.IsFalse(car.Any());
        }
        
        [TestMethod]
        public void GetImages_IdBestaat_ReturnsList()
        {
            //Arrange
            var id = 1;
            //Act
            var car = carMem.GetImages(id);
            //Assert
            Assert.IsTrue(car.Any());
        }
        
        [TestMethod]
        public void SaveImage_Null_ReturnsFalse()
        {
            //Arrange
            var afbeelding = new Afbeelding();
            var id = 1;
            //Act
            var boolean = carMem.SaveImage(afbeelding, id);
            //Assert
            Assert.AreEqual(false, boolean);
        }
        
        [TestMethod]
        public void SaveImage_GeenGeldigID_ReturnsFalse()
        {
            //Arrange
            var afbeelding = new Afbeelding
            {
                Bestand = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            };
            var id = 0;
            //Act
            var boolean = carMem.SaveImage(afbeelding, id);
            //Assert
            Assert.AreEqual(false, boolean);
        }
        
        [TestMethod]
        public void SaveImage_GeldigID_ReturnsTrue()
        {
            //Arrange
            var afbeelding = new Afbeelding
            {
                Bestand = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            };
            var id = 1;
            //Act
            var boolean = carMem.SaveImage(afbeelding, id);
            //Assert
            Assert.AreEqual(true, boolean);
        }
        
        [TestMethod]
        public void GetFirstImage_IdBestaatNiet_IsNull()
        {
            //Arrange
            var id = 0;
            //Act
            var car = carMem.GetFirstImage(id);
            //Assert
            Assert.IsNull(car);
        }
        
        [TestMethod]
        public void GetFirstImage_IdBestaat_IsNotNull()
        {
            //Arrange
            var id = 1;
            //Act
            var car = carMem.GetFirstImage(id);
            //Assert
            Assert.IsNotNull(car);
        }


    }
}
