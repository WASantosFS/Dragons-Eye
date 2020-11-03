using DatabaseConstruction.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Runtime.CompilerServices;

namespace DatabaseConstruction
{
    class Program
    {
        private static string databaseConnectionString;

        public string ReturnConnectionString()
        {
            return databaseConnectionString;
        }

        static void Main(string[] args)
        {
            var services = ServiceProviderBuilder.GetServiceProvider(args);
            var options = services.GetRequiredService<IOptions<MyOptions>>();

            string connectionString = options.Value.SecretOption;
            databaseConnectionString = connectionString;

            IDailySettingsDAO dailyDAO = new DailySettingsDAO(connectionString);

            // options.Value.SecretOption will be SQL Connection String and editable via secrets.json
            // options.Value.OpenOption is in appsettings.json

            UserInterface userInterface = new UserInterface();
            userInterface.Menus();
        }
    }
}
