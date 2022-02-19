using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_nguyen_xuan_hinh_t2012e.Entity;
using Windows.Storage;

namespace UWP_nguyen_xuan_hinh_t2012e.DB
{
    class DatabaseMigration
    {
        private static SQLiteConnection conn = new SQLiteConnection("contact.db");
        public static bool CreateTable()
        {
            var sql = @"CREATE TABLE IF NOT EXISTS contacts " +
            "(PhoneNumber NVARCHAR(50) PRIMARY KEY," +
            "Name NVARCHAR(255) NOT NULL);";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public bool Save(Contact contact)
        {
            var sql = $"INSERT INTO contacts (Name, PhoneNumber) VALUES ('{contact.name}', '{contact.phoneNumber}')";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public List<Contact> ListData()
        {
            var contacts = new List<Contact>();
            var sql = "SELECT * FROM contacts";
            using (var statement = conn.Prepare(sql))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    var name = (string)statement["Name"];
                    var phone = (string)statement["PhoneNumber"];
                    var obj = new Contact() { name = name, phoneNumber = phone };
                    contacts.Add(obj);
                }
            }
            return contacts;
        }

        public List<Contact> search(string keyword)
        {
            var contacts = new List<Contact>();

            using (var statement = conn.Prepare($"select * from contacts where Name like '%{keyword}%'"))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    var name = (string)statement["Name"];
                    var phone = (string)statement["PhoneNumber"];
                    var obj = new Contact() { name = name, phoneNumber = phone };
                    contacts.Add(obj);
                }
            }
            return contacts;
        }
    }
}
