using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DATA;
using Vroem.MODELS;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class LoginMemoryTests
    {
        private readonly LoginMemory login = new LoginMemory();
        [TestMethod]
        public void VerifyUser_Null_ReturnsLoginKloptNiet()
        {   
            //Arrange
            string loginstring= null;
            string wachtwoord = null;
            //Act
            var returnvalue = login.VerifyUser(loginstring, wachtwoord);
            //Assert
            Assert.AreEqual(StatusCodeEnum.LoginKloptNiet,returnvalue);
        }
        
        [TestMethod]
        public void VerifyUser_EmailKloptNiet_ReturnsLoginKloptNiet()
        {   
            //Arrange
            var loginstring = "koenr@gmail.com";
            var wachtwoord = " ";
            //Act
            var returnvalue = login.VerifyUser(loginstring, wachtwoord);
            //Assert
            Assert.AreEqual(StatusCodeEnum.LoginKloptNiet,returnvalue);
        }
        
        [TestMethod]
        public void VerifyUser_UsernameKloptNiet_ReturnsLoginKloptNiet()
        {   
            //Arrange
            var loginstring = "koenr";
            var wachtwoord = " ";
            //Act
            var returnvalue = login.VerifyUser(loginstring, wachtwoord);
            //Assert
            Assert.AreEqual(StatusCodeEnum.LoginKloptNiet,returnvalue);
        }
        
        [TestMethod]
        public void VerifyUser_WachtwoordKloptNiet_ReturnsWachtwoordKloptNiet()
        {   
            //Arrange
            var loginstring = "unit@test.com";
            var wachtwoord = "hoiditkloptniet";
            //Act
            var returnvalue = login.VerifyUser(loginstring, wachtwoord);
            //Assert
            Assert.AreEqual(StatusCodeEnum.WachtwoordKloptNiet,returnvalue);
        }
        
        [TestMethod]
        public void VerifyUser_GegevensKloppen_ReturnsGegevensKloppen()
        {   
            //Arrange
            var loginstring = "unit";
            var wachtwoord = "Unit";
            //Act
            var returnvalue = login.VerifyUser(loginstring, wachtwoord);
            //Assert
            Assert.AreEqual(StatusCodeEnum.GegevensKloppen,returnvalue);
        }
    }
}