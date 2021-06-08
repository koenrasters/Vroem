using Microsoft.Extensions.Configuration;
using System.IO;
using MySql.Data.MySqlClient;

namespace Vroem.DATA
{
    public class DatabaseConnection
    {
        public IConfigurationRoot GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            return builder.Build();
        }

        public string ConnectionString()
        {
            var appSettingsJson = GetAppSettings();
            var connectionString = appSettingsJson["Connections:MySQL"];
            return connectionString;
        }

        public MySqlConnection Connection()
        {
            return new MySqlConnection(ConnectionString());
        }
    }
}
