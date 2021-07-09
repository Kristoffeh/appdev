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
using appdev.Classes;

namespace appdev.UI
{
    /// <summary>
    /// Interaction logic for CustomerPortal.xaml
    /// </summary>
    public partial class CustomerPortal : Window
    {
        Logger log = new Logger();

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

                // MessageBox.Show(Properties.Settings.Default.stripeUserID);

                if (Properties.Settings.Default.stripeUserID.Length == 0)
                {
                    btnUserID.Content = "Guest";
                    btnSubscribe.IsEnabled = false;

                    CustomerPaymentOptions.Visibility = Visibility.Hidden;
                    CustomerPaymentOptions.IsEnabled = false;

                    btnName.Visibility = Visibility.Hidden;
                    btnName.IsEnabled = false;
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                    CultureInfo ci = new CultureInfo("en-US");
                    CultureInfo.DefaultThreadCurrentCulture = ci;
                    CultureInfo.DefaultThreadCurrentUICulture = ci;

                    

                    var service = new ProductService();
                    var service_output = service.Get("prod_JmwBudJpNuZxXC");


                    btnUserID.Content = Properties.Settings.Default.stripeUserID;

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
                    decimal units = Convert.ToDecimal(asd.Price.UnitAmountDecimal);
                    decimal funits = units / 100;


                    lblSubscribePrice.Text = "Subscribe for $" + String.Format("{0:0.00}", funits) + " /month";

                    var servicead = new SubscriptionService();
                    

                    if (Properties.Settings.Default.stripeSubscriptionID.Length != 0)
                    {
                        var b = servicead.Get(Properties.Settings.Default.stripeSubscriptionID);

                        

                        // Display you are subscribed if you are subscribed
                        if (b.Status == "active")
                        {
                            lblbNoSub.Visibility = Visibility.Hidden;
                            btnSubscribe.IsEnabled = false;
                            lblSubscribePrice.Text = "You are subscribed for $4.99 /month";
                            TimeSpan ts = b.CurrentPeriodEnd - DateTime.Now;
                            lblSubscribedUntil.Text = string.Format("{0:0}", ts.TotalDays) + " days left";
                            // lblSubscribePrice.Text = "You are subscribed - Subscription ID: " + Properties.Settings.Default.stripeSubscriptionID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void btnSubscribe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.stripeCardAdded == false)
                {
                    log.DisplayLog("You don't have any payment methods linked to your account!", "Error", "ok", "error");

                }
                else
                {
                    StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";

                    var options = new SubscriptionCreateOptions
                    {
                        Customer = Properties.Settings.Default.stripeUserID,
                        Items = new List<SubscriptionItemOptions>
                        {
                            new SubscriptionItemOptions
                            {
                                Price = "price_1J9h9BDjGfNenHs5oqzV2gDP",
                            },
                        },
                    };
                    var service = new SubscriptionService();
                    var s = service.Create(options);


                    TimeSpan ts = s.CurrentPeriodEnd - DateTime.Now;
                    MessageBox.Show("Payment successful, subscription automatically renews in " + string.Format("{0:0}", ts.TotalDays) + " days", "Success");
                    lblSubscribedUntil.Text = string.Format("{0:0}", ts.TotalDays) + " days left";
                    btnSubscribe.IsEnabled = false;
                    lblbNoSub.Visibility = Visibility.Hidden;

                    Properties.Settings.Default.stripeSubscriptionID = s.Id;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void CustomerPaymentOptions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerPaymentOptions cpo = new CustomerPaymentOptions();
                cpo.Show();
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void btnCreateCustomerAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateAccount cr = new CreateAccount();
                this.Close();
                cr.Show();
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void btnClearProperties_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear cache and local properties? This will permanently log you out of your current account!", "Are you sure?", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.OK:
                    Properties.Settings.Default.Reset();
                    btnName.Visibility = Visibility.Hidden;
                    CustomerPaymentOptions.Visibility = Visibility.Hidden;
                    btnUserID.Content = "Guest";
                    btnSubscribe.IsEnabled = false;
                    MessageBox.Show("Your local settings and properties have been cleared. You may register an account now.", "Success", MessageBoxButton.OK);
                    break;
            }
            
        }
    }
}
