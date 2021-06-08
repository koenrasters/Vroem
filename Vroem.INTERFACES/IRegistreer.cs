using System;
using System.Collections.Generic;
using System.Text;
using Vroem.MODELS;

namespace Vroem.INTERFACES
{
    public interface IRegistreer
    {
        bool Registreer(User us);
        bool CheckEmailExists(string email);
        bool CheckUsernameExists(string gebruikersnaam);
    }
}
