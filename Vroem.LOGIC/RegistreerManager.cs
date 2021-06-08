using System;
using Vroem.DATA;
using Vroem.MODELS;
using Vroem.DAL;
using Vroem.INTERFACES;

namespace Vroem.LOGIC
{
    public class RegistreerManager
    {
        private readonly IRegistreer RegisterService;
        private readonly IDataAccess _dataAccess;

        public RegistreerManager(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            RegisterService = dataAccess.GetRegistreer();
        }

        public StatusCodeEnum Registreer(User us)
        {
            if (us == null)
            {
                return 0;
            }
            else
            {
                var email = RegisterService.CheckEmailExists(us.Email);
                var username = RegisterService.CheckUsernameExists(us.Gebruikersnaam);
                if (email && username || !email && !username)
                {
                    return (StatusCodeEnum)Convert.ToInt32(RegisterService.Registreer(us));
                }
                else if(!RegisterService.CheckEmailExists(us.Email))
                {
                    return StatusCodeEnum.EmailBestaat;
                } 
                else if (!RegisterService.CheckUsernameExists(us.Gebruikersnaam))
                {
                    return StatusCodeEnum.GebruikerBestaat;
                }
                return 0;
            }
            
        }

    }

}
