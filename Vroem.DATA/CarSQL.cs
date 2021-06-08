using System;
using System.Collections.Generic;
using Vroem.INTERFACES;
using Vroem.MODELS;

namespace Vroem.DATA
{
    public class CarSQL : ICar
    {
        private readonly DatabaseConnection _con = new DatabaseConnection();

        public bool AddValueToEntity(string entity, string name, int? id)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                if (entity == "model")
                {
                    if (id == null)
                    {
                        return false;
                    }
                    command.CommandText =
                        "INSERT IGNORE INTO model(Naam,Merk_ID) VALUES(@name,@id)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@id", id);
                }
                else
                {
                    command.CommandText =
                        $"INSERT IGNORE INTO {entity}(Naam) VALUES(@name)";
                    command.Parameters.AddWithValue("@name", name);
                }
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public int GetIdEntity(string entity, string naam)
        {
            if (entity == null || naam == null)
            {
                return -1;
            }
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT ID FROM {entity} WHERE Naam = @name";
            command.Parameters.AddWithValue("@name", naam);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows) return -1;
            reader.Read();
            var id = reader.GetInt32("ID");
            return (id);
        }

        public bool AddCar(Car auto, int model, int merk, int brandstof, int transmissie, int kleur, int carroserie)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO auto(Kenteken, Titel, Beschrijving, Bouwjaar, Kilometerstand, Vermogen, Prijs, Bieden, Datum_geregistreerd, GebruikerID, MerkID, ModelID, KleurID, BrandstofID, TransmissieID, CarroserieID) " 
                    + "VALUES(@kenteken, @title, @description, @year, @kilometers, @power, @price, @bieden, @date, @userID, @brandID, @modelID, @colorID, @fuelID, @transmissionID, @bodyworkID)";
                command.Parameters.AddWithValue("@kenteken", auto.Kenteken);
                command.Parameters.AddWithValue("@title", auto.Titel);
                command.Parameters.AddWithValue("@description", auto.Beschrijving);
                command.Parameters.AddWithValue("@year", auto.Bouwjaar);
                command.Parameters.AddWithValue("@kilometers", auto.Kilometerstand);
                command.Parameters.AddWithValue("@power", auto.Vermogen);
                command.Parameters.AddWithValue("@price", auto.Prijs);
                command.Parameters.AddWithValue("@bieden", auto.Bieden);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@userID", auto.GebruikerID);
                command.Parameters.AddWithValue("@brandID", merk);
                command.Parameters.AddWithValue("@modelID", model);
                command.Parameters.AddWithValue("@colorID", kleur);
                command.Parameters.AddWithValue("@fuelID", brandstof);
                command.Parameters.AddWithValue("@transmissionID", transmissie);
                command.Parameters.AddWithValue("@bodyworkID", carroserie);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public string GetNameEntity(string entity, int id)
        {
            if (entity == null)
            {
                return null;
            }
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Naam FROM {entity} WHERE ID=@id";
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows) return null;
            reader.Read();
            var naam = reader.GetString("Naam");
            return naam;
        }

        public List<Car> GetCars()
        {
            var templist = new List<Car>();
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM auto ORDER BY Datum_geregistreerd DESC";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int? price = null;
                if (reader["Prijs"] != DBNull.Value)
                {
                    price = reader.GetInt32("Prijs");
                }
                var auto = new Car()
                {
                    Id = reader.GetInt32("ID"),
                    GebruikerID = reader.GetInt32("GebruikerID"),
                    Titel = reader.GetString("Titel"),
                    Beschrijving = reader.GetString("Beschrijving"),
                    Bouwjaar = reader.GetInt32("Bouwjaar"),
                    Kilometerstand = reader.GetInt32("Kilometerstand"),
                    Vermogen = reader.GetInt32("Vermogen"),
                    Merk = GetNameEntity("merk", reader.GetInt32("MerkID")),
                    Model = GetNameEntity("model", reader.GetInt32("ModelID")),
                    Brandstof = GetNameEntity("brandstof", reader.GetInt32("BrandstofID")),
                    Transmissie = GetNameEntity("transmissie", reader.GetInt32("TransmissieID")),
                    Kleur = GetNameEntity("kleur", reader.GetInt32("KleurID")),
                    Carroserie = GetNameEntity("carroserie", reader.GetInt32("CarroserieID")),
                    DatumGeregistreerd = reader.GetDateTime("Datum_geregistreerd"),
                    Kenteken = reader.GetString("Kenteken"),
                    Prijs = price,
                    Bieden = reader.GetBoolean("Bieden")
                };
                templist.Add(auto);
            }
            
            return templist;
        }

        public Car GetCar(int id)
        {
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM auto WHERE ID=@id";
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            reader.Read();
            try
            {
                int? price = null;
                if (reader["Prijs"] != DBNull.Value)
                {
                    price = reader.GetInt32("Prijs");
                }
                var auto = new Car()
                {
                    Id = reader.GetInt32("ID"),
                    GebruikerID = reader.GetInt32("GebruikerID"),
                    Titel = reader.GetString("Titel"),
                    Beschrijving = reader.GetString("Beschrijving"),
                    Bouwjaar = reader.GetInt32("Bouwjaar"),
                    Kilometerstand = reader.GetInt32("Kilometerstand"),
                    Vermogen = reader.GetInt32("Vermogen"),
                    Merk = GetNameEntity("merk", reader.GetInt32("MerkID")),
                    Model = GetNameEntity("model", reader.GetInt32("ModelID")),
                    Brandstof = GetNameEntity("brandstof", reader.GetInt32("BrandstofID")),
                    Transmissie = GetNameEntity("transmissie", reader.GetInt32("TransmissieID")),
                    Kleur = GetNameEntity("kleur", reader.GetInt32("KleurID")),
                    Carroserie = GetNameEntity("carroserie", reader.GetInt32("CarroserieID")),
                    DatumGeregistreerd = reader.GetDateTime("Datum_geregistreerd"),
                    Kenteken = reader.GetString("Kenteken"),
                    Prijs = price,
                    Bieden = reader.GetBoolean("Bieden")
                };
                return auto;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int GetLatestCarId()
        {
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(ID) AS ID FROM auto";
            using var reader = command.ExecuteReader();
            reader.Read();
            return reader.GetInt32("ID");
        }

        public bool SaveImage(Afbeelding afbeelding, int id)
        {
            using var connection = _con.Connection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO afbeelding(Bestand, `Auto-ID`) VALUES(@afbeelding, @id)";
                command.Parameters.AddWithValue("@afbeelding", afbeelding.Bestand);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public List<Afbeelding> GetImages(int id)
        {
            var templist = new List<Afbeelding>();
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM afbeelding WHERE `Auto-ID`=@id";
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var afbeelding = new Afbeelding()
                {
                    Bestand = (byte[])reader["Bestand"]
                };
                templist.Add(afbeelding);
            }

            return templist;
        }

        public Afbeelding GetFirstImage(int id)
        {
            using var connection = _con.Connection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM afbeelding WHERE ID IN (SELECT MIN(ID) as ID FROM afbeelding WHERE `Auto-ID` = @id)";
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows) return null;
            reader.Read();
            var afbeelding = new Afbeelding()
            {
                Bestand = (byte[]) reader["Bestand"]
            };
            return afbeelding;
        }
    }
}