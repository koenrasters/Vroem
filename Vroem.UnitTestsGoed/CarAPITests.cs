using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.API;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class CarAPITests
    {
        private readonly CarAPIMem carApi = new CarAPIMem();
        [TestMethod] 
        public void GetCar_KentekenNull_ReturnsNull()
        {
            //Arrange
            string kenteken = null;
            //Act
            var auto = carApi.GetCar(kenteken);
            //Assert
            Assert.IsNull(auto);
        }
        
        [TestMethod] 
        public void GetCar_KentekenBestaatNiet_ReturnsNull()
        {
            //Arrange
            string kenteken = "HHHHHH";
            //Act
            var auto = carApi.GetCar(kenteken);
            //Assert
            Assert.IsNull(auto);
        }
        
        [TestMethod] 
        public void GetCar_KentekenBestaat_ReturnsCar()
        {
            //Arrange
            string kenteken = "77dtnh";
            //Act
            var auto = carApi.GetCar(kenteken);
            //Assert
            Assert.IsNotNull(auto);
        }
        
        [TestMethod] 
        public void GetCar_KentekenBestaatMetStreepjes_ReturnsCar()
        {
            //Arrange
            string kenteken = "77-dt-nh";
            //Act
            var auto = carApi.GetCar(kenteken);
            //Assert
            Assert.IsNotNull(auto);
        }
        
        [TestMethod] 
        public void GetCar_KentekenBestaatHoofdLetterModel_ReturnsCar()
        {
            //Arrange
            string kenteken = "59snxl";
            //Act
            var auto = carApi.GetCar(kenteken);
            //Assert
            Assert.IsNotNull(auto);
        }
    }
}