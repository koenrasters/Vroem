using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DAL;
using Vroem.LOGIC;
using Vroem.MODELS;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class UserManagerTests
    {
        private readonly UserManager userManager = new UserManager(new DataAccess("mem"));
        
        [TestMethod] 
        public void GetUsers_ReturnsList()
        {
            //Arrange
            //Act
            var list = userManager.GetUsers();
            //Assert
            Assert.IsTrue(list.Any());
        }
        
        [TestMethod]
        public void GetUser_IdBestaatNiet_ReturnsNull()
        {
            //Arrange
            int id = 0;
            //Act
            var user = userManager.GetUser(id);
            //Assert
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void GetUser_IdBestaat_ReturnsUser()
        {
            //Arrange
            int id = 1;
            //Act
            var user = userManager.GetUser(id);
            //Assert
            Assert.IsNotNull(user);
        }
        
        [TestMethod]
        public void EditAccount_Null_ReturnsFalse()
        {
            //Arrange
            User user = null;
            //Act
            var boolean = userManager.EditAccount(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditAccount_VerkeerdId_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                Gebruikersnaam = "unittest",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit" 
            };
            user.Id = 0;
            //Act
            var boolean = userManager.EditAccount(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditAccount_GoedeGegevens_ReturnsTrue()
        {
            //Arrange
            
            var user = new User
            {
                Gebruikersnaam = "unittest",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit" 
            };
            user.Id = 1;
            //Act
            var boolean = userManager.EditAccount(user);
            //Assert
            Assert.AreEqual(true,boolean);
        }
        
        [TestMethod]
        public void EditPassword_Null_ReturnsFalse()
        {
            //Arrange
            
            var user = new User
            {
                
            };
            //Act
            var boolean = userManager.EditPassword(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditPassword_VerkeerdId_ReturnsFalse()
        {
            //Arrange
            
            var user = new User
            {
                Wachtwoord = "Unit"
            };
            user.Id = 0;
            //Act
            var boolean = userManager.EditPassword(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditPassword_GoedeGegevens_ReturnsTrue()
        {
            //Arrange
            var user = new User
            {
                Wachtwoord = "Unit"
            };
            user.Id = 1;
            //Act
            var boolean = userManager.EditPassword(user);
            //Assert
            Assert.AreEqual(true,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_Null_ReturnsFalse()
        {
            //Arrange
            int userId = 0;
            int price = 0;
            int carId = 0;
            //Act
            var boolean = userManager.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_AutoIdKloptNiet_ReturnsFalse()
        {
            //Arrange
            int userId = 1;
            int price = 1000;
            int carId = 0;
            //Act
            var boolean = userManager.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_GegevensKloppen_ReturnsTrue()
        {
            //Arrange
            int userId = 1;
            int price = 1000;
            int carId = 1;
            //Act
            var boolean = userManager.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(true,boolean);
        }

        [TestMethod] 
        public void GetBids_IdKloptNiet_ReturnsEmptyList()
        {
            //Arrange
            int carId = 0;
            //Act
            var list = userManager.GetBids(carId);
            //Assert
            Assert.IsFalse(list.Any());
        }
        
        [TestMethod] 
        public void GetBids_AutoWaarNietOpGebodenWordt_ReturnsEmptyList()
        {
            //Arrange
            int carId = 2;
            //Act
            var list = userManager.GetBids(carId);
            //Assert
            Assert.IsFalse(list.Any());
        }
        
        [TestMethod] 
        public void GetBids_IdKlopt_ReturnsList()
        {
            //Arrange
            int carId = 1;
            //Act
            var list = userManager.GetBids(carId);
            //Assert
            Assert.IsTrue(list.Any());
        }
    }
}