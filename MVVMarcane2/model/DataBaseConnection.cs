using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace MVVMarcane2.model
{
    public class DataBaseConnection
    {
        private string connectionString = "Data Source=PC-JAN;Initial Catalog=modeldb;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=True;TrustServerCertificate=True";
        private string connectionString2 = "Data Source=http://ellaboratori.cat/phpmyadmin;Initial Catalog=jan;Persist Security Info=True;User ID=jan;Password=jan1234;Encrypt=True;TrustServerCertificate=True";
        private string connectionString3 = "Server=http://ellaboratori.cat/phpmyadmin;Initial Catalog=jan;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";
        private string connectionString4 = "SERVER=http://ellaboratori.cat/phpmyadmin;DATABASE=jan;UID=jan;PASSWORD=jan1234";
        private string connectionString5 = "Server=ellaboratori.cat;Database=jan;User ID=jan;Password=jan1234;SslMode=none";

		private string Taula;

        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        
        public SqlCommand sqlCommand;

        public DataBaseConnection()
        {
            sqlConnection = new SqlConnection(connectionString5);
            useSql("");
        }

        public DataBaseConnection useSql(string sql)
        {
			//if (!String.IsNullOrEmpty(sql))
			//{
			//    sqlCommand = new SqlCommand(sql, sqlConnection);
			//    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			//}
			//return this;

			if (!String.IsNullOrEmpty(sql))
			{
				MySql.Data.MySqlClient.MySqlCommand mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(sql, new MySql.Data.MySqlClient.MySqlConnection(connectionString5));
				MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(mySqlCommand);

			}
			return this;
		}

        public DataTable getData()
        {
            return dataTable;
        }

        public object getPrimerResultat(string clau)
        {
            return dataTable.Rows[0][clau];
        }

        public void addWithValue(string clau, object valor)
        {
            sqlCommand.Parameters.AddWithValue(clau, valor);
        }

        public DataBaseConnection fill()
        {
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return this;
        }

    }
}
