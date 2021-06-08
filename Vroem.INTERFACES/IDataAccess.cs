namespace Vroem.INTERFACES
{
    public interface IDataAccess
    {
        IRegistreer GetRegistreer();
        
        ILogin GetLogin();

        IUser GetUser();

        ICarAPI GetApiConnection();
        
        ICar GetCar();

    }
}