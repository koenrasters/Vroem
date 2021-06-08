using System;
using Vroem.API;
using Vroem.DATA;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DAL
{
    public class DataAccess : IDataAccess
    {
        private readonly string _context;
        public DataAccess(string context)
        {
            _context = context;
        }
        public IRegistreer GetRegistreer()
        {
            if (_context == "db")
            {
                return new RegistreerSQL();
            }
            else
            {
                return new RegistreerMemory();
            }
        }

        public ILogin GetLogin()
        {
            if (_context == "db")
            {
                return new LoginSQL();
            }
            else
            {
                return new LoginMemory();
            }
        }

        public IUser GetUser()
        {
            if (_context == "db")
            {
                return new UserSQL();
            }
            else
            {
                return new UserMemory();
            }
        }

        public ICarAPI GetApiConnection()
        {
            if (_context == "db")
            {
                return new CarAPI();
            }
            else
            {
                return new CarAPIMem();
            }
        }

        public ICar GetCar()
        {
            if (_context == "db")
            {
                return new CarSQL();
            }
            else
            {
                return new CarMemory();
            }
        }
    }
    
}
