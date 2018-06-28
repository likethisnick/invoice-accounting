using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace invoice_accounting
{
    class SQLFunctions
    {

        // Path to Database

        private static readonly SqlConnection Connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog = Invoice; Integrated Security=true;");

        // Refresh database method

        public static void Refresh(DataGridView dataGridView)
        {
            try
            {
                Connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Invoice", Connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        // Insert new line in database method

        public static void Insert(string Name, decimal Money)
        {
            try
            {
                Connection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Invoice(ClientName, InvoiceAmount) VALUES(@ClientName, @Money)", Connection);
                sqlCommand.Parameters.AddWithValue("@ClientName", Name);
                sqlCommand.Parameters.AddWithValue("@Money", Money);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        // Delete existing line in database by id method

        public static void Delete(int id)
        {
            try
            {
                Connection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM Invoice WHERE ID = @ID", Connection);
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        // Changing existing line in database method

        public static void Update(int ID, string newUserName, decimal newMoney)
        {
            try
            {
                Connection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Invoice SET ClientName = @newUsername, InvoiceAmount = @newMoney WHERE ID = @ID", Connection);
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@newUsername", newUserName);
                sqlCommand.Parameters.AddWithValue("@newMoney", newMoney);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        // Display lines from database by name of clients method

        public static void Select(DataGridView dataGridView, string ClientName)
        {
            try
            {
                Connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Invoice WHERE ClientName like '" + ClientName + "%'", Connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        // Sum up the clients money and writing it in the bottom of datagrid method

        public static void Sum(DataGridView dataGridView, string ClientName)
        {
            try
            {
                Connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Invoice WHERE ClientName like '" + ClientName + "%'", Connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

    }
}
