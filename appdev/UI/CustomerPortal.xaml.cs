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
                // Retrieve product
                StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";

                var service = new ProductService();
                var service_output = service.Get("prod_JmwBudJpNuZxXC");


                btnUserID.Content = Properties.Settings.Default.stripeUserID + "";
                
                // txtLogs.Text += "User ID: " + Properties.Settings.Default.stripeUserID + "\r\n \r\n";
                // txtLogs.Text += service_output;
                // StripeCreateSubscription();
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
    }
}
