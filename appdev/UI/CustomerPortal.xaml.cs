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
using System.Globalization;
using System.Threading;

namespace appdev.UI
{
    /// <summary>
    /// Interaction logic for CustomerPortal.xaml
    /// </summary>
    public partial class CustomerPortal : Window
    {
        public CustomerPortal()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                CultureInfo ci = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentCulture = ci;
                CultureInfo.DefaultThreadCurrentUICulture = ci;

                // Retrieve product
                StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";

                var service = new ProductService();
                var service_output = service.Get("prod_JmwBudJpNuZxXC");

                
                btnUserID.Content = Properties.Settings.Default.stripeUserID + "";

                // txtLogs.Text += "User ID: " + Properties.Settings.Default.stripeUserID + "\r\n \r\n";
                // txtLogs.Text += service_output;
                // StripeCreateSubscription();


                // Retrieve name from Stripe
                var service_name = new CustomerService();
                var customer_name = service_name.Get(Properties.Settings.Default.stripeUserID);

                // Subscription service
                var servicea = new SubscriptionItemService();
                var asd = servicea.Get("si_JnHj9eFeVEqXGV");

                btnName.Content = customer_name.Name;
                lblSubscribePrice.Text = "Subscribe for $" + String.Format("{0:0.00}", 4.99) + " /month";




            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "");
                throw;
            }
        }

        void StripeCreateSubscription()
        {
            StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";

            var options = new SubscriptionCreateOptions
            {
                // Get Customer ID from application properties
                Customer = Properties.Settings.Default.stripeUserID,
                Items = new List<SubscriptionItemOptions>
                {
                new SubscriptionItemOptions
                {
                    Price = "price_1J9MIvDjGfNenHs5hp9wrYt3",
                },
              },
            };
            var service = new SubscriptionService();
            service.Create(options);
        }

        private void btnSubscribe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";

                var options = new SubscriptionCreateOptions
                {
                    Customer = Properties.Settings.Default.stripeUserID,
                    Items = new List<SubscriptionItemOptions>

                {
                    new SubscriptionItemOptions
                    {
                      Price = "price_1J9MIvDjGfNenHs5hp9wrYt3",
                    },
                },
                };
                var service = new SubscriptionService();
                var s = service.Create(options);

                // Status handling
                /*if (s.Status == "")
                {

                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message,"");
                throw;
            }
        }

        private void CustomerPaymentOptions_Click(object sender, RoutedEventArgs e)
        {
            CustomerPaymentOptions cpo = new CustomerPaymentOptions();
            cpo.Show();
        }
    }
}
