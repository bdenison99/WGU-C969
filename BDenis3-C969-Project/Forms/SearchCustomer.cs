using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDenis3_C969_Project
{
    public partial class SearchCustomer : Form
    {
        public bool isDelete = false;
        public SearchCustomer()
        {
            InitializeComponent();
            dgCustomerSearch.DataSource = Dal.CustomerList.ToList<CustomerRecord>();
            dgCustomerSearch.RowHeadersVisible = false;
            dgCustomerSearch.Columns["AddressID"].Visible = false;  // Don't need to see the customers address id
        }

        private void ButtonSearchCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSearchEdit_Click(object sender, EventArgs e)
        {
            if (isDelete)
            {
                int selectedRowCount = dgCustomerSearch.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    Dal.DeleteCustomer(Convert.ToInt32(dgCustomerSearch.CurrentRow.Cells["customerId"].Value));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select a record below, then click the Delete button");
                }
            }
            else
            {
                LaunchCustomerEditor();
            }
        }

        private void LaunchCustomerEditor()
        {
            int selectedRowCount = dgCustomerSearch.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                // Overloading the AddCustomer form to handle editing a customer record also
                AddCustomer editCustomer = new AddCustomer
                {
                    isUpdate = true  // The isupdate property is not tied to a control on the form - it's just a boolean flag to let the form know this is an update operation
                };
                editCustomer.PopulateCustomer(Convert.ToInt32(dgCustomerSearch.CurrentRow.Cells["customerId"].Value));
                editCustomer.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a record below, then click the edit button");
            }

        }


        private void ButtonSearchExecute_Click(object sender, EventArgs e)
        {
            List<int> searchIDs = new List<int>();

            if (String.IsNullOrEmpty(textSearchValue.Text))
            {
                MessageBox.Show("Please enter a search value in the text box");
                return;
            }

            foreach (DataGridViewRow cr in dgCustomerSearch.Rows)
            {
                // if the customer name cell doesn't contain the search value, then hide the row
                if (! cr.Cells["CustomerName"].Value.ToString().ToLower().Contains(textSearchValue.Text.ToString().ToLower()))
                {
                    cr.Visible = false;
                }
            }
        }
    }
}
