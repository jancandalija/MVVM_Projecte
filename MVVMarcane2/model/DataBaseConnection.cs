using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MVVMarcane2.model
{
    public class DataBaseConnection
    {
        private string connectionString = "Data Source=PC-JAN;Initial Catalog=modeldb;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=True;TrustServerCertificate=True";

        private string Taula;

        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        
        public SqlCommand sqlCommand;

        public DataBaseConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
            useSql("");
        }

        public DataBaseConnection useSql(string sql)
        {
            if (!String.IsNullOrEmpty(sql))
            {
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
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
