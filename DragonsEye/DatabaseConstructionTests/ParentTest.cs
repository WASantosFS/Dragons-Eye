using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using DatabaseConstruction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace DatabaseConstructionTests
{
    [TestClass]
    public class ParentTest
    {
        private TransactionScope trans;

        [TestInitialize]
        public void Setup(string[] args)
        {
            var services = ServiceProviderBuilder.GetServiceProvider(args);
            var options = services.GetRequiredService<IOptions<MyOptions>>();
            string connectionString = options.Value.SecretOption;

            trans = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql_insert =
                    "Insert Into daily_settings (day_of_year, time_period, rotors, reflectors, beta_or_gamma, offset, plugs) Values(1,0,'VIII III I','B','Gamma','8 3 4','X Z J O V K Y L D F I E W C P Q B S U A');" +
                    "Insert Into daily_settings (day_of_year, time_period, rotors, reflectors, beta_or_gamma, offset, plugs) Values(1,8,'VII II III','C','Beta','2 12 6','O Y H E G X J D S R Z T B I K N V U M P');" +
                    "Insert Into daily_settings (day_of_year, time_period, rotors, reflectors, beta_or_gamma, offset, plugs) Values(1,16,'II V I','B','Gamma','10 24 18','Q P N K I M H W X F L Y G Z R D C J O B');" +
                    "Insert Into daily_settings (day_of_year, time_period, rotors, reflectors, beta_or_gamma, offset, plugs) Values(2,0,'III VI VII','C','Gamma','19 20 21','A Q B Z V W H D Y N L J U K G O M C E I');" +
                    "Insert Into daily_settings (day_of_year, time_period, rotors, reflectors, beta_or_gamma, offset, plugs) Values(2,8,'II I IV','B','Gamma','23 16 19','F I M K N Q Z B W T S G X R P H L J D E');" +
                    "Insert Into daily_settings (day_of_year, time_period, rotors, reflectors, beta_or_gamma, offset, plugs) Values(2,16,'V III VIII','C','Gamma','4 12 21','I H L P Y S R D M W O Z B N U F Q K C A');";

                SqlCommand cmd = new SqlCommand(sql_insert, conn);
                int count = cmd.ExecuteNonQuery();

                Assert.AreEqual(6, count, "Insert into daily_settings failed.");
            }
        }

        [TestCleanup]
        public void Reset()
        {
            trans.Dispose();
        }
    }
}
