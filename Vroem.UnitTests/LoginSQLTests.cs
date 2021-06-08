using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DATA;
using Vroem.MODELS;

namespace Vroem.UnitTests
{
    [TestClass]
    public class LoginSQLTests
    {
        [TestMethod]
        public void VerifyUser_Null_ReturnsLoginKloptNiet()
        {   
            //Arrange
            var login = new LoginSQL();
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
            var login = new LoginSQL();
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
            var login = new LoginSQL();
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
            var login = new LoginSQL();
            var loginstring = "koen124";
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
            var login = new LoginSQL();
            var loginstring = "koen124";
            var wachtwoord = "koentje";
            //Act
            var returnvalue = login.VerifyUser(loginstring, wachtwoord);
            //Assert
            Assert.AreEqual(StatusCodeEnum.GegevensKloppen,returnvalue);
        }
        
    }
}