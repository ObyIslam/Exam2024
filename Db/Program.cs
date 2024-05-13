using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam2024;
using System.Data.Entity;

namespace Db
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //create database
            RestaurantData db = new RestaurantData("OODExam_ObyIslam");

            using (db)
            {
                try
                {
                    //create sample data
                    Customer c1 = new Customer() { Name = "Tom Jones", ContactNumber = "086-123 4567" };
                    Customer c2 = new Customer() { Name = "Mary Smith", ContactNumber = "086 546 3214" };
                    Customer c3 = new Customer() { Name = "Jo Doyle", ContactNumber = "087 1221 222" };

                    //add sample data to db
                    db.Customers.Add(c1);
                    db.Customers.Add(c2);
                    db.Customers.Add(c3);

                    //save db
                    db.SaveChanges();

                    Console.WriteLine("db was created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("db was not created" + ex.ToString());
                }
            }
        }
    }
}
