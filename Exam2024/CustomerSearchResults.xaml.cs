using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Exam2024;

namespace Exam2024
{
    /// <summary>
    /// Interaction logic for CustomerSearchResults.xaml
    /// </summary>
    public partial class CustomerSearchResults : Window
    {
        public CustomerSearchResults()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RestaurantData db = new RestaurantData("OODExam_ObyIslam");

            var query = from c in db.Customers
                        select c.Name;

            var query2 = from c in db.Customers
                         select c.ContactNumber;

            var query3 = from c in db.Customers
                         select c.CustomerId;

            

        }

        private void createBooking_btn_Click(object sender, RoutedEventArgs e)
        {
            RestaurantData db = new RestaurantData("OODExam_ObyIslam");

            using (db)
            {
                //get information from texboxes
                Customer newCustomer = new Customer();
                newCustomer.Name = tbx_Name.Text;
                newCustomer.ContactNumber = tbx_contactNumber.Text;

                Booking newBooking = new Booking();
                newBooking.BookingDate = (DateTime)dateChosen.SelectedDate;
                newBooking.NumberOfParticpants = int.Parse(tbx_NoOfCustomers.Text);


                //add them to databse
                db.Customers.Add(newCustomer);  
                db.Bookings.Add(newBooking);
                

                //save
                db.SaveChanges();
            }

            MessageBox.Show("Your booking has been confirmed");

        }
    }
}
