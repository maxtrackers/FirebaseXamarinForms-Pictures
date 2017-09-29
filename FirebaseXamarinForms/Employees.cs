﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace FirebaseXamarinForms
{
    public class Employees
    {
        [PrimaryKey, AutoIncrement]
        public long EmployeeId
        { get; set; }
        [NotNull]
        public string LastName
        { get; set; }
        public string FirstName
        { get; set; }
        public string Title
        { get; set; }

        public int ReportsTo
        { get; set; }
        public DateTime BirthDate
        { get; set; }

        public DateTime HireDate
        { get; set; }
        public string Address
        { get; set; }

        public string City
        { get; set; }

        public string Country
        { get; set; }

        public string PostalCode
        { get; set; }

        public string Phone
        { get; set; }

        public string Fax
        { get; set; }

        public string Email
        { get; set; }
    }
     


}
