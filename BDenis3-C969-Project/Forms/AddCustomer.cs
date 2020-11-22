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
    public partial class AddCustomer : Form
    {
        private bool needsUpdate = false;  // a flag to indicate that at least one field on the form changed contents
        // These records are used only for updating an existing customer and shouldn't be used for adding a new customer
        private CustomerRecord customer = new CustomerRecord();
        private AddressRecord address = new AddressRecord();
        private CityRecord city = new CityRecord();
        private CountryRecord country = new CountryRecord();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void ButtonCancelAddCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSaveNewCustomer_Click(object sender, EventArgs e)
        {
            if (this.isUpdate)
            {
                UpdateCustomer();
            }
            else
            {
                SaveNewCustomer();
            }
        }

        private void UpdateCustomer()
        {
            if (needsUpdate)
            {
                if (ValidateFields())
                {
                    customer.CustomerName = textCustomerName.Text.ToString();
                    customer.Active = Convert.ToBoolean(checkActiveCustomer.Checked);

                    address.Address1 = textStreetAddress.Text.ToString();
                    address.Address2 = textStreetAddress2.Text.ToString();
                    address.Phone = textPhone.Text.ToString();
                    address.PostalCode = textPostalCode.Text.ToString();
                    // Need to test city ID lookup if customer changes city
                    address.CityID = (Dal.CityList.ToList<CityRecord>().Find(item => item.CityName.ToString().ToLower() == textCityName.Text.ToString().ToLower())).CityID;

                    Dal.UpdateCustomer(customer, address, city, country);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Every customer must have a name, street address, city, country, postal code, and phone number");
                    return;  // exit without changing things for user to fix fields
                }
            }
            else
            {
                this.Close();  // If no text fields changed values, there's nothing to update
            }
            
        }

        private bool ValidateFields()
        {
            // Required fields to add a new user include customer name, the first address field, city name, country name, postal code, and phone number
            if (String.IsNullOrEmpty(textCustomerName.Text.ToString()) ||
                 String.IsNullOrEmpty(textStreetAddress.Text.ToString()) ||
                 String.IsNullOrEmpty(textCityName.Text.ToString()) ||
                 String.IsNullOrEmpty(textCountryName.Text.ToString()) ||
                 String.IsNullOrEmpty(textPostalCode.Text.ToString()) ||
                 String.IsNullOrEmpty(textPhone.Text.ToString())
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SaveNewCustomer()
        {
            CustomerObject newCustomer = new CustomerObject();

            if (!ValidateFields())
            {
                MessageBox.Show("Please provide a customer name, street address, city, country, postal code, and phone number");
            }
            else
            {
                int countryid = -1;
                int cityid = -1;
                int addressid = -1;

                // Validate country information, or add if needed
                try
                {
                    // A Lambda to look up the countryid from the countryname - saves the programmer from having to write a for / foreach loop to find the correct record and get the country ID that matches the name
                    countryid = Dal.CountryList.ToList<CountryRecord>().Find(item => item.CountryName.ToLower() == textCountryName.Text.ToLower()).CountryID;
                }
                catch  // An exception is thrown if the lambda doesn't find a matching row
                {
                    // Just in case the user mistyped the country record, prompt the user to confirm the spelling - OK will add the new country to the database
                    DialogResult result = MessageBox.Show(String.Format($"There is no country with the name {textCountryName.Text.ToString()}.  OK to add?"), "Database record missing", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        countryid = Dal.AddCountry(textCountryName.Text.ToString());
                    }
                    else
                    {
                        return;  // Just go back to the add customer form for the user to fix it or reclick save to accept.  No need for further processing
                    }

                }

                // Validate city information, or add if needed
                try
                {
                    // A Lambda to look up the city ID, based on the name given, saving yet another for / foreach loop to find the id that goes with the name.
                    cityid = Dal.CityList.ToList<CityRecord>().Find(item => item.CountryID == countryid && item.CityName.ToLower() == textCityName.Text.ToLower()).CityID;
                }
                catch
                {
                    // Just in case the city was mistyped, give the user the chance to cancel and edit
                    DialogResult result = MessageBox.Show(String.Format($"There is no city with the name {textCityName.Text.ToString()}.  OK to add?"), "Database record missing", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        cityid = Dal.AddCity(textCityName.Text.ToString(), countryid);
                    }
                    else
                    {
                        return;  // Just go back to the add customer form for the user to fix it or reclick save to accept.  No need for further processing
                    }
                }

                // Lookup address information, add if the address wasn't found
                try
                {
                    // A Lambda to look up the address ID, based on the data given, saving yet another for / foreach loop to find the id that goes with the address.
                    addressid = Dal.AddressList.ToList<AddressRecord>().Find(item => item.CityID == cityid && item.Address1.ToLower() == textStreetAddress.Text.ToLower()).AddressID;
                }
                catch
                {
                    addressid = Dal.AddAddress(textStreetAddress.Text.ToString(), textStreetAddress2.Text.ToString(), cityid, textPostalCode.Text.ToString(), textPhone.Text.ToString());
                }

                // 
                int customerid = Dal.AddCustomer(textCustomerName.Text.ToString(), addressid, true);
                if (countryid > -1 && cityid > -1 && addressid > -1 && customerid > -1)
                {
                    MessageBox.Show($"Customer {textCustomerName.Text.ToString()} added with customer ID {customerid}");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occurred adding a new customer record.  Please contact support");
                }
            }
        }

        public void PopulateCustomer(int customerid)
        {
            // Retrieve the customer record, address record, city record, and country record using Lambdas to avoid filling the screen with foreach / for loops
            customer = Dal.CustomerList.ToList<CustomerRecord>().Find(item => item.CustomerID == customerid);
            address = Dal.AddressList.ToList<AddressRecord>().Find(item => item.AddressID == customer.AddressID);
            city = Dal.CityList.ToList<CityRecord>().Find(item => item.CityID == address.CityID);
            country = Dal.CountryList.ToList<CountryRecord>().Find(item => item.CountryID == city.CountryID);

            // Parse the data out and populate the fields
            textCustomerID.Text = customer.CustomerID.ToString();
            textCustomerName.Text = customer.CustomerName.ToString();
            textStreetAddress.Text = address.Address1.ToString();
            textStreetAddress2.Text = address.Address2.ToString();
            textCityName.Text = city.CityName.ToString();
            textCountryName.Text = country.CountryName.ToString();
            textPostalCode.Text = address.PostalCode.ToString();
            textPhone.Text = address.Phone.ToString();
        }

        private void FieldChanged(object sender, EventArgs e)
        {
            // An event handler for text fields on the add customer form - any text changed values should trigger this and set the flag to true
            needsUpdate = true;
        }
    }
}
