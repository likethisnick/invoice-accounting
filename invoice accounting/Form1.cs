using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace invoice_accounting
{
    public partial class Invoice : Form
    {

        public Invoice()
        {
            InitializeComponent();
        }

        // Staring initialization of Invoice table

        private void Invoice_Load(object sender, EventArgs e)
        {
            SQLFunctions.Refresh(this.dataGridView1);
        }

        // Insert into Invoice table new line with name and sum of money 

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(insertBox.Text !="")
            {
                SQLFunctions.Insert(insertBox.Text, numInvoice.Value);
                SQLFunctions.Refresh(this.dataGridView1);
            }
        }

        // Delete from Invoice table new line using ID of Client

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                SQLFunctions.Delete(Convert.ToInt32(txtID.Text));
                SQLFunctions.Refresh(this.dataGridView1);
            }
        }

        // Update name and invoise amount of client in Invoice table using ID

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdId.Text != "")
            {
                SQLFunctions.Update(Convert.ToInt32(txtUpdId.Text), txtNewClientName.Text, numNewInvoice.Value);
                SQLFunctions.Refresh(this.dataGridView1);
            }
        }

        // Filter data in grid by name written in textbox

        private void textboxNameFilter_TextChanged(object sender, EventArgs e)
        {
            SQLFunctions.Select(this.dataGridView1, textboxNameFilter.Text);
        }

        // Add summ of all Invoice amount of money in the end of table

        private void btnSum_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                var value = dataGridView1.Rows[i].Cells[2].Value;
                total += Convert.ToDecimal(value);
            }
            if(total!=0)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = "Total: ";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = total.ToString();
            }
        }
    }
}
