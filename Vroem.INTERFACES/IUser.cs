using System;
using System.Collections.Generic;
using System.Text;
using Vroem.MODELS;

namespace Vroem.INTERFACES
{
    public interface IUser
    {
        User GetUser(int id);
        User GetUser(string login);
        List<User> GetUsers();
        bool EditAccount(User us);
        bool EditPassword(User us);
        bool BidOnCar(int usID, int price, int carID);
        List<Bod> GetBids(int carID);
    }
}
