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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Exam2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load data with data box
            RestaurantData db = new RestaurantData("OODExam_ObyIslam");

            using (db)
            {
                var query5 = from b in db.Bookings
                            select b.BookingDate;

                var query2 = from c in db.Customers
                             select c.Name + " " + c.ContactNumber;

                var query3 = from b in db.Bookings
                             select b.NumberOfParticpants;


                if (query_datebox.SelectedDate.Value != null && query5.Contains(query_datebox.SelectedDate.Value))
                {
                    lbx_Customers.ItemsSource = query2.ToString() + query3.ToString();
                }
                else
                {
                    lbx_Customers.ItemsSource = "please select a date";
                }

            }

            var query = from b in db.Bookings
                            select b.BookingDate;
            lbx_Customers.ItemsSource = query.ToString();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RestaurantData db = new RestaurantData("OODExam_ObyIslam");

            var query = from c in db.Customers
                        select c.Name;

            var query2 = from c in db.Customers
                         select c.ContactNumber;

            var query3 = from c in db.Customers
                         select c.CustomerId;

            //opens new window 
            if (query.Contains(tbx_CustomerName.Text) && query2.Contains(tbx_ContactNumber.Text) && query3.Contains(int.Parse(tbx_NoOfCustomers.Text)))
            {
                openCustomerSearchWindow();
                this.Close();
            }


        }

        private void openCustomerSearchWindow()
        {
            var newWindow = new CustomerSearchResults();
            newWindow.Show();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            RestaurantData db = new RestaurantData("OODExam_ObyIslam");
            if (lbx_Customers.SelectedItem!= null)
            {
                lbx_Customers.Items.Remove(lbx_Customers.SelectedItem);
                //db.Bookings.Remove(lbx_Customers.SelectedItem)
                lbx_Customers.ItemsSource = null;
                lbx_Customers.ItemsSource = db.Customers;
            }
            
        }
    }
}
