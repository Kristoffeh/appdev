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
            try
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

                // List payment methods
                var opt = new PaymentMethodListOptions
                {
                    Customer = "cus_Jmv6LCDGan315v",
                    Type = "card",
                };
                var sr = new PaymentMethodService();
                StripeList<PaymentMethod> paymentMethods = sr.List(opt);

                CheckBox cb = new CheckBox();
                cb.Content = "   Visa        **** **** **** 4242        12/24        ***";
                cb.IsChecked = false;
                cb.FontSize = 16;

                vertiStacker.Children.Add(cb);



                // MessageBox.Show("" + cards ,"");

                if (cards.Count() == 0)
                {
                    lblNoCards.Visibility = Visibility.Visible;
                }
                else
                {

                    foreach (PaymentMethod pm in paymentMethods.Data)
                    {
                        int i = 1;
                        i++;

                        /*var window = new Window();
                        var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
                        stackPanel.Children.Add(new Label { Content = "Label" });
                        stackPanel.Children.Add(new Button { Content = "Button" });
                        window.Content = stackPanel;*/



                        






                        Console.WriteLine(pm.Card.Brand);
                        Console.WriteLine(pm.Card.Last4);
                        Console.WriteLine(pm.Card.ExpMonth);
                        Console.WriteLine(pm.Card.ExpYear);
                    }

                    string cust_id = c.Id;


                    // MessageBox.Show(paymentMethods., "");
                    // cbListCards.Content = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message ,"");
                throw;
            }
        }
    }
}
