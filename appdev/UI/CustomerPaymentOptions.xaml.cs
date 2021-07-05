using Stripe;
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

namespace appdev.UI
{
    /// <summary>
    /// Interaction logic for CustomerPaymentOptions.xaml
    /// </summary>
    public partial class CustomerPaymentOptions : Window
    {
        public CustomerPaymentOptions()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";

            var servicea = new CustomerService();
            var r_customer = servicea.Get(Properties.Settings.Default.stripeUserID);

            // Remove last 2 digits
            long rm1 = r_customer.Balance / 10;
            long rm2 = rm1 / 10;

            // get last two digits
            long lastTwo = r_customer.Balance % 100;

            string a = rm2.ToString();
            string bstring = a.Replace("-", string.Empty);



            lblCreditValue.Content = "$" + String.Format("{0:0.00}", bstring);

            // Cards object (list all cards)
            var service = new CardService();
            var options = new CardListOptions
            {
                Limit = 3,
            };
            var cards = service.List(Properties.Settings.Default.stripeUserID, options);

            // Customer object
            var serviceb = new CustomerService();
            var c = serviceb.Get(Properties.Settings.Default.stripeUserID);



            // MessageBox.Show("" + cards ,"");

            if (cards.Count() == 0)
            {
                lblNoCards.Visibility = Visibility.Visible;
            }
            else
            {
                cbListCards.Content = "";
            }
        }
    }
}
