using System;
using System.Collections.Generic;
using System.Text;
using Vroem.MODELS;

namespace Vroem.INTERFACES
{
    public interface ILogin
    {
        StatusCodeEnum VerifyUser(string login, string password);
    }
}
