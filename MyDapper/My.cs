using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace MyDapper
{
    public class My
    {
        public static Action<string> Write;

        public static DbConnection ConnectionFactory()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        }
    }
}
