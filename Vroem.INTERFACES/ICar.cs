using System.Collections.Generic;
using Vroem.MODELS;

namespace Vroem.INTERFACES
{
    public interface ICar
    {
        bool AddValueToEntity(string entity, string name, int? id);
        int GetIdEntity(string entity, string naam);
        bool AddCar(Car auto, int model, int merk, int brandstof, int transmissie, int kleur, int carroserie);
        string GetNameEntity(string entity, int id);
        List<Car> GetCars();
        Car GetCar(int id);
        int GetLatestCarId();
        bool SaveImage(Afbeelding afbeelding, int id);
        List<Afbeelding> GetImages(int id);
        Afbeelding GetFirstImage(int id);
    }
}