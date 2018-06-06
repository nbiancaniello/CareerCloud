using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADO
    {
        protected readonly SqlConnection _connection;
        public BaseADO()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        }

    }
}
