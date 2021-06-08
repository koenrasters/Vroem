using System.Collections.Generic;
using System.Linq;
using Vroem.DAL;
using Vroem.DATA;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.LOGIC
{
    public class UserManager
    {
        private readonly IUser _user;
        private readonly ICar _car;
        private readonly IDataAccess _dataAccess;

        public UserManager(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _user = _dataAccess.GetUser();
            _car = _dataAccess.GetCar();
        }

        public List<User> GetUsers()
        {
            return _user.GetUsers();
        }

        public User GetUser(int id)
        {
            return _user.GetUser(id);
        }

        public bool EditAccount(User us)
        {
            return _user.EditAccount(us);
        }

        public bool EditPassword(User us)
        {
            return _user.EditPassword(us);
        }

        /// <summary>
        /// Iemand mag alleen op een auto bieden als bieden is toegestaan, het bod hoger is dan andere bods en het bod hoger is dan de prijs van de auto.
        /// </summary>
        /// <param name="usID"></param>
        /// <param name="price"></param>
        /// <param name="carID"></param>
        /// <returns></returns>
        public bool BidOnCar(int usID, int price, int carID)
        {
            var car = _car.GetCar(carID);
            if (car==null)
            {
                return false;
            }
            var bids = GetBids(carID);
            var max = 0;
            if (bids.Count != 0)
            {
                max = bids.Max(item => item.Prijs);
            }
            if (price > max && price > car.Prijs && car.Bieden)
            {
                return _user.BidOnCar(usID, price, carID);
            }
            else
            {
                return false;
            }
            
        }
        
        public List<Bod> GetBids(int carID)
        {
            return _user.GetBids(carID);
        }
    }
}
