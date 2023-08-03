using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public abstract class ConnectionToSql
    {
        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Server=DESKTOP-H971MRM;DataBase= MyCompany; integrated security= true";
            connectionString = "Server=DESKTOP-H971MRM;DataBase= dbMUNi; integrated security= true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


    }
}
