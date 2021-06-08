using System;
using Vroem.MODELS;

namespace Vroem.INTERFACES
{
    public interface ICarAPI
    {
        Car GetCar(string kenteken);
    }
}
