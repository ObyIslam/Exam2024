using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Exam2024
{
    public class Booking
    {
        public int BookingId {  get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfParticpants { get; set; }

        public virtual List<Customer> Customer { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set;}
        public string Name { get; set;}
        public string ContactNumber { get; set;}

    }

    public class RestaurantData: DbContext
    {
        public RestaurantData(string databaseName):base (databaseName) { }
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Booking> Bookings { get; set;}
    }
}
