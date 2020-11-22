﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDenis3_C969_Project
{
    class CustomerObject
    {
        // There may be room for improvements here by making the address information a list of addresses since people may have home and work addresses
        public CustomerRecord CustomerInfo { get; set; }
        public AddressRecord CustomerAddress { get; set; }
        public CityRecord CustomerCity { get; set; }
        public CountryRecord CustomerCountry { get; set; }
    }

    // This class should match the customer table
    // fields createDate and createdBy will be populated on new record creation but are not displayed on the screen
    // field lastUpdate is auto generated by MySQL, lastUpdatedBy will be set by the record update process, neither will be displayed on the screen
    [Serializable]
    public class CustomerRecord
    {
        //Note - the integer ID fields are autoincremented by the database.  We can store the value, but cannot set it when adding or updating records.
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int AddressID { get; set; }
        public bool Active { get; set; }

        public CustomerRecord() { }
        public CustomerRecord (int id, string name, int addressid, bool active = true)
        {
            // Note:  By default, a new customer should have the active bit set, hence the default value for the active parameter
            CustomerID = id;
            CustomerName = name;
            AddressID = addressid;
            Active = active;
        }
    }

    [Serializable]
    public class AddressRecord
    {
        //Note - the integer ID fields are autoincremented by the database.  We can store the value, but cannot set it when adding or updating records.
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityID { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }


        public AddressRecord (int id, string streetaddress, int cityID, string zip, string phone, string address2 = "")
        {
            // Note:  Not all addresses will need a second address line, hence making this field optional and setting the default to an empty string
            AddressID = id;
            Address1 = streetaddress;
            Address2 = address2;
            CityID = cityID;
            PostalCode = zip;
            Phone = phone;
        }

        public AddressRecord() { }
    }

    [Serializable]
    public class CityRecord
    {
        //Note - the integer ID fields are autoincremented by the database.  We can store the value, but cannot set it when adding or updating records.
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }

        public CityRecord(int id, string cityName, int countryID)
        {
            CityID = id;
            CityName = cityName;
            CountryID = countryID;
        }
        public CityRecord() { }
    }

    [Serializable]
    public class CountryRecord
    {
        //Note - the integer ID fields are autoincremented by the database.  We can store the value, but cannot set it when adding or updating records.
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public CountryRecord(int id, string name)
        {
            CountryID = id;
            CountryName = name;
        }

        public CountryRecord(){}
    }

}