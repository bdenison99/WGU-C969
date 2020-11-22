using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BDenis3_C969_Project
{
    class Dal  //Data access layer
    {
        // properties to keep track of who is logged in for DB updates
        private static string currentusername = "";
        private static int currentuserid = -1;

        public static string CurrentUsername { get { return currentusername; } set { currentusername = value; } }
        public static int CurrentUserID { get { return currentuserid; } set { currentuserid = value; } }

        // The connection string and connection objects as public properties
        public static string connString = @"server=wgudb.ucertify.com;user id=U06ogx;password=53688825337;persistsecurityinfo=True;database=U06ogx";
        public static MySqlConnection conn = new MySqlConnection(connString);

        // These binding lists are used to hold database rows in the application
        private static BindingList<CustomerRecord> customerList = new BindingList<CustomerRecord>();
        private static BindingList<AddressRecord> addressList = new BindingList<AddressRecord>();
        private static BindingList<CityRecord> cityList = new BindingList<CityRecord>();
        private static BindingList<CountryRecord> countryList = new BindingList<CountryRecord>();

        public static BindingList<CustomerRecord> CustomerList { get { return customerList; } }
        public static BindingList<AddressRecord> AddressList { get { return addressList; } }
        public static BindingList<CityRecord> CityList { get { return cityList; } }
        public static BindingList<CountryRecord> CountryList { get { return countryList; } }

        // Appointment list and property to access it
        private static BindingList<AppointmentRecord> apptlist = new BindingList<AppointmentRecord>();
        public static BindingList<AppointmentRecord> Appointments { get { return apptlist; } }

        private static BindingList<UserRecord> userlist = new BindingList<UserRecord>();
        public static BindingList<UserRecord> Users {  get { return userlist; } }

        // A method to run any query against the database - not secure since no parameter or SQL validation is done
        public static DataTable RunSQLCommand(string sqlCmd)
        {
            DataTable results = new DataTable();

            try
            {
                conn.Open();
                MySqlCommand mySqlCmd = new MySqlCommand(sqlCmd, conn);
                MySqlDataAdapter msda = new MySqlDataAdapter(mySqlCmd);
                msda.Fill(results);
            }
            catch
            {
                // Need to check on possible exceptions to catch here and how to handle them
            }
            finally
            {
                conn.Close();
            }

            return results;
        }

        // A general funtion to load data at runtime
        public static void RetrieveData()
        {
            LoadCountryList();
            LoadCityList();
            LoadAddressList();
            LoadCustomerList();
            LoadAppointments();
            LoadUsers();
        }

        // A function to process the country table into a serializable CountryRecord list
        private static void LoadCountryList()
        {
            try
            {
                DataTable dt = RunSQLCommand("Select countryId, country from country");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CountryRecord newCountry = new CountryRecord
                        {
                            CountryID = Convert.ToInt32(row["countryId"].ToString()),
                            CountryName = row["country"].ToString()
                        };
                        countryList.Add(newCountry);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        // A function to process the city table into a serializable CityRecord list
        private static void LoadCityList()
        {
            try
            {
                DataTable dt = RunSQLCommand("Select cityId, city, countryId from city");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CityRecord newCity = new CityRecord
                        {
                            CityID = Convert.ToInt32(row["cityId"].ToString()),
                            CityName = row["city"].ToString(),
                            CountryID = Convert.ToInt32(row["countryId"].ToString())
                        };
                        cityList.Add(newCity);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        // A function to process the address table into a serializable AddressRecord list
        private static void LoadAddressList()
        {
            try
            {
                DataTable dt = RunSQLCommand("Select addressId, address, address2, cityId, postalCode, phone from address");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        AddressRecord newAddress = new AddressRecord
                        {
                            AddressID = Convert.ToInt32(row["addressId"].ToString()),
                            Address1 = row["address"].ToString(),
                            Address2 = row["address2"].ToString(),
                            CityID = Convert.ToInt32(row["cityId"].ToString()),
                            PostalCode = row["postalCode"].ToString(),
                            Phone = row["phone"].ToString()
                        };
                        addressList.Add(newAddress);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        // A function to process the customer table into a serializable CustomerRecord list
        private static void LoadCustomerList()
        {
            try
            {
                DataTable dt = RunSQLCommand("Select customerId, customerName, addressId, active from customer");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CustomerRecord newCustomer = new CustomerRecord
                        {
                            CustomerID = Convert.ToInt32(row["customerId"].ToString()),
                            CustomerName = row["customerName"].ToString(),
                            AddressID = Convert.ToInt32(row["addressId"].ToString()),
                            Active = Convert.ToBoolean(row["active"].ToString())
                        };
                        customerList.Add(newCustomer);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        // A function to process the appointment table into a serializable AppointmentRecord list
        private static void LoadAppointments()
        {
            try
            {
                DataTable dt = RunSQLCommand($"Select appointmentID, customerId, userId, title, description, location, contact, type, url, start, end from appointment");
                foreach (DataRow row in dt.Rows)
                {
                    AppointmentRecord newAppt = new AppointmentRecord // Holds the appointment specifics
                    {
                        AppointmentID = Convert.ToInt32(row["appointmentId"].ToString()),
                        AppointmentCustomerID = Convert.ToInt32(row["customerId"].ToString()),
                        AppointmentTitle = row["title"].ToString(),
                        AppointmentDescription = row["description"].ToString(),
                        AppointmentLocation = row["location"].ToString(),
                        AppointmentContact = row["contact"].ToString(),
                        AppointmentType = row["type"].ToString(),
                        AppointmentUrl = row["url"].ToString(),
                        AppointmentStartTime = DateTime.Parse(row["start"].ToString()).ToLocalTime(),  // This should take UTC time from the DB and convert it to local time
                        AppointmentEndTime = DateTime.Parse(row["end"].ToString()).ToLocalTime() // Same here - UTC to local time
                    };

                    Dal.Appointments.Add(newAppt);
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        // A function to load users from the database
        private static void LoadUsers()
        {
            try
            {
                DataTable dt = RunSQLCommand($"Select userId, userName from user;");
                foreach (DataRow row in dt.Rows)
                {
                    UserRecord newUser = new UserRecord // Holds the appointment specifics
                    {
                        UserRecordID = Convert.ToInt32(row["userId"].ToString()),
                        UserRecordName = row["userName"].ToString()
                    };

                    Dal.Users.Add(newUser);
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        // A function which 
        public static void AddAppointment(int customerid, int userid, string title, string desc, string type, DateTime start, DateTime end)
        {
            //'2019-01-01 00:00:00'
            string startString = $"{start.Year}-{start.Month}-{start.Day} {start.Hour}:{start.Minute}:{start.Second}" ;
            string endString = $"{end.Year}-{end.Month}-{end.Day} {end.Hour}:{end.Minute}:{end.Second}";

            int appointmentid = -1;
            string sqlAdd = $"INSERT INTO appointment (";
            sqlAdd += $"customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) ";
            sqlAdd += $"VALUES ({customerid}, {userid}, '{title}', '{desc}', 'not needed', 'not needed', '{type}', 'not needed', ";
            sqlAdd += $"'{startString}', '{endString}', UTC_TImestamp(), '{currentusername}', '{currentusername}');";

            Dal.RunSQLCommand(sqlAdd);

            try
            {
                string sqlGet = $"SELECT * FROM appointment WHERE title = '{title}' and description = '{desc}' and start = '{startString}' and customerId = {customerid};";
                DataTable dt = Dal.RunSQLCommand(sqlGet);

                if (dt.Rows.Count == 1)
                {
                    appointmentid = Convert.ToInt32(dt.Rows[0]["appointmentId"].ToString());
                }
            }
            catch
            {

            }
            finally
            {

            }

            if (appointmentid != -1)
            {
                AppointmentRecord newAppointment = new AppointmentRecord
                {
                    AppointmentID = appointmentid,
                    AppointmentCustomerID = customerid,
                    AppointmentUserID = userid,
                    AppointmentTitle = title,
                    AppointmentDescription = desc,
                    AppointmentLocation = "not needed",
                    AppointmentContact = "not needed",
                    AppointmentType = type,
                    AppointmentUrl = "not needed",
                    AppointmentStartTime = Convert.ToDateTime(start),
                    AppointmentEndTime = Convert.ToDateTime(end)
                };

                Appointments.Add(newAppointment);
            }
        }

        // A function that accepts a new country name and returns the integer ID in the country table for the new row
        public static int AddCountry(string Country)
        {
            string newCountry = Country;
            int countryid = -1;

            // Run the SQL command to add a new country
            string sqlAdd = $"INSERT INTO country (country, createDate, createdBy, lastUpdateBy) ";
            sqlAdd += $"VALUES ('{newCountry}', UTC_Timestamp(), '{currentusername}', '{currentusername}' );";
            Dal.RunSQLCommand(sqlAdd);

            // Now that we have the country added, get the country ID for that row
            string sqlGet = $"SELECT countryId from country where country = '{newCountry}'";
            try
            {
                DataTable newRow = Dal.RunSQLCommand(sqlGet);
                countryid = Convert.ToInt32(newRow.Rows[0]["countryId"].ToString());
            }
            catch
            {
                // if the datatable contains no rows an exception can be thrown when trying to assign country id
                // this just resets the country id to indicate a problem
                countryid = -1;
            }

            // If we have a valid country ID, add it to the DAL country list
            if (countryid != -1)
            {
                CountryRecord newCountryRecord = new CountryRecord
                {
                    CountryName = newCountry,
                    CountryID = countryid
                };
                CountryList.Add(newCountryRecord);
            }

            return countryid;
        }

        // A function that accepts a new city name and country ID, then returns the integer ID in the country table for the new row
        public static int AddCity(string City, int country)
        {
            string newCity = City;
            int countryid = country;
            int cityid = -1;

            // Run the SQL command to add a new country
            string sqlAdd = $"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) ";
            sqlAdd += $"VALUES ('{newCity}', {countryid}, UTC_Timestamp(), '{currentusername}', '{currentusername}' );";
            Dal.RunSQLCommand(sqlAdd);

            // Now that we have the country added, get the country ID for that row
            string sqlGet = $"SELECT cityId from city where city = '{newCity}'";

            DataTable newRow = Dal.RunSQLCommand(sqlGet);
            cityid = Convert.ToInt32(newRow.Rows[0]["cityId"].ToString());

            // If we have a valid country ID, add it to the DAL country list
            if (cityid != -1)
            {
                CityRecord newCityRecord = new CityRecord
                {
                    CityName = newCity,
                    CityID = cityid,
                    CountryID = countryid
                };
                CityList.Add(newCityRecord);
            }

            return countryid;
        }

        // A more complex function that accepts an address with up two 2 street address fields, and fields for a city ID, zip code, and phone number
        public static int AddAddress(string streetaddress, string streetaddress2, int cityid, string postalcode, string phone)
        {
            int addressid = -1;

            // Run the SQL command to add a new country
            string sqlAdd = $"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) ";
            sqlAdd += $"VALUES ('{streetaddress}', '{streetaddress2}', {cityid}, '{postalcode}', '{phone}', UTC_Timestamp(), '{currentusername}', '{currentusername}' );";
            Dal.RunSQLCommand(sqlAdd);

            // Now that we have the country added, get the country ID for that row
            string sqlGet = $"SELECT * from address where address = '{streetaddress}' and address2 = '{streetaddress2}' and cityid='{cityid}'";

            DataTable newRow = Dal.RunSQLCommand(sqlGet);
            addressid = Convert.ToInt32(newRow.Rows[0]["AddressId"].ToString());

            // If we have a valid country ID, add it to the DAL country list
            if (addressid != -1)
            {
                AddressRecord newAddressRecord = new AddressRecord
                {
                    AddressID = addressid,
                    Address1 = streetaddress,
                    Address2 = streetaddress2,
                    CityID = cityid,
                    PostalCode = postalcode,
                    Phone = phone
                };
                AddressList.Add(newAddressRecord);
            }

            return addressid;
        }

        // this function adds a new customer to the database
        public static int AddCustomer(string name, int addressid, bool active)
        {
            int customerid = -1;
            string sqlAdd = $"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy)";
            sqlAdd += $"VALUES ('{name}', '{addressid}', 1 , UTC_Timestamp(), '{CurrentUsername}', '{CurrentUsername}' );";
            Dal.RunSQLCommand(sqlAdd);

            string sqlGet = $"SELECT * FROM customer where customerName = '{name}' and addressId = {addressid} and createdBy = '{CurrentUsername}';";
            DataTable newRow = Dal.RunSQLCommand(sqlGet);
            customerid = Convert.ToInt32(newRow.Rows[0]["customerid"].ToString());

            CustomerRecord newCustomer = new CustomerRecord
            {
                CustomerID = customerid,
                CustomerName = name,
                AddressID = addressid,
                Active = true
            };

            Dal.CustomerList.Add(newCustomer);

            return customerid;
        }

        // A function updates a customer record instead of creating a new one
        public static void UpdateCustomer(CustomerRecord customer, AddressRecord address, CityRecord city, CountryRecord country)
        {
            // These are the records updated to match the country and city IDs using the names shown in the parameter records
            CountryRecord newCountry = CompareCountry(country);  // adds the country if it doesn't exist
            CityRecord newCity = CompareCity(city, newCountry.CountryID); // adds the city if it doesn't exist
            AddressRecord newAddress = CompareAddress(address, newCity.CityID);  // does NOT add a new address since each addressID should be unique to each client, even if the clients live together it's just duplicate data

            // Theory of operations
            // Order of updates - Country, City, Address, Customer
            // A country can be added (via compareCountry function) but shouldn't need to be updated.  A country name change is rare enough that a SQL DB update command can be used outside of the application
            // The city gets updated next, and only the city name and associated country ID can be changed
            // The address gets updated next - only the street address (address1 and address2), CityID, PostalCode, and Phone can be updated
            // The customer updates last - only the customer Name and active flag can be changed

            string sqlUpdateCity = $"UPDATE city ";
            sqlUpdateCity += $"SET city = '{newCity.CityName}', ";
            sqlUpdateCity += $"countryId = {newCity.CountryID} ";
            sqlUpdateCity += $"WHERE = cityId = {newCity.CityID};";
            Dal.RunSQLCommand(sqlUpdateCity);

            string sqlUpdateAddress = $"UPDATE address ";
            sqlUpdateAddress += $"SET address = '{newAddress.Address1}', ";
            sqlUpdateAddress += $"address2 = '{newAddress.Address2}', ";
            sqlUpdateAddress += $"cityId = {newAddress.CityID}, ";
            sqlUpdateAddress += $"postalCode = '{newAddress.PostalCode}', ";
            sqlUpdateAddress += $"phone = '{newAddress.Phone}' ";
            sqlUpdateAddress += $"WHERE addressId = {newAddress.AddressID}; ";
            Dal.RunSQLCommand(sqlUpdateAddress);

            string sqlUpdateCustomer = $"UPDATE customer ";
            sqlUpdateCustomer += $"SET customerName = '{customer.CustomerName}', ";
            sqlUpdateCustomer += $"active = {Convert.ToInt32(customer.Active)} ";
            sqlUpdateCustomer += $"WHERE customerId = {customer.CustomerID};";
            Dal.RunSQLCommand(sqlUpdateCustomer);

        }

        private static CountryRecord CompareCountry(CountryRecord cr)
        {
            // This function takes in a CountryRecord, and compares it to the database copy of the data.
            // If the country name in the CountryRecord does not match the database, then the following happens
            // Find out if there is a country name in the database for the name provided in the CountryRecord parameter
            // Update the CountryRecord parameter to have the correct country ID and name and return that to the calling function

            // Get the row in the country table which matches the country NAME in the internal CountryRecord variable
            string checkCountrySQL = $"SELECT * from country WHERE country = '{cr.CountryName}';";
            DataTable dtCountryDB = Dal.RunSQLCommand(checkCountrySQL);

            // A row count of 0 means that the country name isn't in the database already - needs to be added
            if (dtCountryDB.Rows.Count == 0)
            {
                string addCountrySQL = $"INSERT into country (country, createDate, createdBy, lastUpdateBy) ";
                addCountrySQL += $"VALUES ('{cr.CountryName}', UTC_Timestamp(), '{CurrentUsername}', '{CurrentUsername}');";
                Dal.RunSQLCommand(addCountrySQL);  // Query again now that we have added the new country record
                dtCountryDB = Dal.RunSQLCommand(checkCountrySQL); // get the countryID results
                cr.CountryID = Convert.ToInt32(dtCountryDB.Rows[0]["countryId"].ToString()); // store the correct country id
            }
            else
            {
                // A non-zero row returned means a country was found with a matching name, now compare to the current country ID
                if (cr.CountryID != Convert.ToInt32(dtCountryDB.Rows[0]["countryId"].ToString()))
                {
                    // if the current country ID doesn't match the one retrieved from the database for the current name, then update the ID
                    cr.CountryID = Convert.ToInt32(dtCountryDB.Rows[0]["countryId"].ToString());
                }
            }

            return cr;
        }

        private static CityRecord CompareCity(CityRecord cr, int countryid)
        {
            // This function takes in a CityRecord, and compares it to the database copy of the data.
            // If the country name in the CityRecord does not match the database, then the following happens
            // Find out if there is a country name in the database for the name provided in the CityRecord parameter
            // Update the CityRecord parameter to have the correct country ID and name and return that to the calling function

            // Get the row in the country table which matches the country NAME in the internal CityRecord variable
            string checkCitySQL = $"SELECT * from city WHERE city = '{cr.CityName}';";
            DataTable dtCityDB = Dal.RunSQLCommand(checkCitySQL);

            // A row count of 0 means that the city name isn't in the database already - needs to be added
            if (dtCityDB.Rows.Count == 0)
            {
                string addCitySQL = $"INSERT into city (city, countryId, createDate, createdBy, lastUpdateBy) ";
                addCitySQL += $"VALUES ('{cr.CityName}', {countryid}, UTC_Timestamp(), '{CurrentUsername}', '{CurrentUsername}');";
                Dal.RunSQLCommand(addCitySQL);  // Query again now that we have added the new city record
                dtCityDB = Dal.RunSQLCommand(checkCitySQL); // get the cityID results - should never fail
                cr.CityID = Convert.ToInt32(dtCityDB.Rows[0]["cityId"].ToString()); // store the correct city id
                cr.CountryID = countryid; // This should come from the country record which is the first to be updated
            }
            else
            {
                // This should trigger only when a city name already exists for the updated customer city
                if (cr.CityID != Convert.ToInt32(dtCityDB.Rows[0]["cityId"].ToString()))
                {
                    // This makes sure that we have the correct city ID for the city name
                    cr.CountryID = Convert.ToInt32(dtCityDB.Rows[0]["cityId"].ToString());
                }
            }

            return cr;
        }

        private static AddressRecord CompareAddress(AddressRecord ar, int cityid)
        {
            // This function takes in a AddressRecord, and compares it to the database copy of the data.
            // If the address in the AddressRecord does not match the database, then the following happens
            // update the city id using the one just passed in
            // Update the CityRecord parameter to have the correct country ID and name and return that to the calling function

            // Get the row in the country table which matches the country NAME in the internal CityRecord variable
            string checkAddressSQL = $"SELECT * from address WHERE addressId = '{ar.AddressID}';";
            DataTable dtAddressDB = Dal.RunSQLCommand(checkAddressSQL);

            // There should never be a case where a customer update process doesn't have a matching address id, so just move on to validating the city ID
            if (Convert.ToInt32(dtAddressDB.Rows[0]["cityId"]) != Convert.ToInt32(ar.CityID))
            {
                ar.CityID = Convert.ToInt32(dtAddressDB.Rows[0]["cityId"]);
            }
            return ar;
        }

        public static bool DeleteCustomer(int customerID)
        {
            // The database schema does not allow a delete of a customer or address record 
            // without also deleting the city and country records.
            // It's a stupid design constraint because it is highly likely that
            // there will be more than one customer in any given city and country.
            // As a result, we will simply mark customer rows as inactive in the database and local copies of the data
            // when they are deleted.  The appointment calendar functions will only look at active customers, so appointments
            // which belong to an inactive customer will not appear
            bool deleted = false;

            foreach (CustomerRecord cr in CustomerList)
            {
                if (cr.CustomerID == customerID)
                {
                    cr.Active = false;
                    // Updatae the customer record from the database to be inactive
                    Dal.RunSQLCommand($"UPDATE customer SET active = 0 WHERE customerId = {customerID};");
                    deleted = true;

                }
            }
            return deleted;
        }
    }
}
