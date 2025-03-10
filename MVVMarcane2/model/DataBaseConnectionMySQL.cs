using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMarcane2.model
{
	public class DataBaseConnectionMySQL
	{
		private string connectionString = "Server=ellaboratori.cat;Database=jan;User ID=jan;Password=jan1234;SslMode=none";

		private MySqlConnection mySqlConnection;
		private MySqlDataAdapter mySqlDataAdapter;
		private DataTable dataTable;

		public MySqlCommand mySqlCommand;

		public DataBaseConnectionMySQL()
		{
			mySqlConnection = new MySqlConnection(connectionString);
			useSql("");
		}

		public DataBaseConnectionMySQL useSql(string sql)
		{
			if (!String.IsNullOrEmpty(sql))
			{
				mySqlCommand = new MySqlCommand(sql, mySqlConnection);
				mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
			}
			return this;
		}

		public DataTable getData()
		{
			return dataTable;
		}

		public int getDataCount()
		{
			return dataTable.Rows.Count;
		}

		public object getPrimerResultat(string clau)
		{
			return dataTable.Rows[0][clau];
		}

		public void addWithValue(string clau, object valor)
		{
			mySqlCommand.Parameters.AddWithValue(clau, valor);
		}

		public DataBaseConnectionMySQL fill()
		{
			try {
				dataTable = new DataTable();
				mySqlDataAdapter.Fill(dataTable);
				//mySqlConnection.Close();
			} 
			catch (Exception e)
			{
				dataTable = new DataTable();
				mySqlDataAdapter.Fill(dataTable);
				//mySqlConnection.Close();
			}
			
			return this;
		}

		public void exec()
		{
			mySqlCommand.ExecuteNonQuery();
			mySqlConnection.Close();
		}
	}
}
