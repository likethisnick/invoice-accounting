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

        private static readonly SqlConnection Connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog = Invoice; Integrated Security=true;");


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
