using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DAL;
using Vroem.LOGIC;
using Vroem.MODELS;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class LoginManagerTests
    {
        [TestMethod] 
        public void Login_Null_ReturnsLoginKloptNiet()
        {
            //Arrange
            var login = new LoginManager(new DataAccess("mem"));
            string loginstring = null;
            string password = null;
            bool persistence = false;
            HttpContext httpContext = null;
            //Act
            var statuscode = login.Login(loginstring, password, persistence, httpContext);
            //Assert
            Assert.AreEqual(StatusCodeEnum.LoginKloptNiet, statuscode);
        }   
        
        
    }
}