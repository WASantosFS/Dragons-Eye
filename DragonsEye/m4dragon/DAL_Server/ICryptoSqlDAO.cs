using m4dragon.Models_Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace m4dragon.DAL_Server
{
    public interface ICryptoSqlDAO
    {
        public List<Crypto> SelectDailySettings(int dayOfYear, int hour);
    }
}
