using DatabaseConstruction.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;


namespace DatabaseConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ServiceProviderBuilder.GetServiceProvider(args);
            var options = services.GetRequiredService<IOptions<MyOptions>>();

            string connectionString = options.Value.SecretOption;

            IDailySettingsDAO dailyDAO = new DailySettingsDAO(connectionString);

            // options.Value.SecretOption will be SQL Connection String and editable via secrets.json
            // options.Value.OpenOption is in appsettings.json

            UserInterface userInterface = new UserInterface();
            userInterface.Menus();
        }
    }
}
