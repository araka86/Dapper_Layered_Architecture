using Microsoft.Data.SqlClient;

namespace DapperTest.Dal.Implementation
{
    public class DbConnections
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("Data Source=DESKTOP-ESCI621; Initial Catalog=DapperTest; Integrated Security=true; Trust Server Certificate=true;");
        }
    }
}
