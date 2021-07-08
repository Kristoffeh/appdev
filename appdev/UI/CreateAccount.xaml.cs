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
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void accCancelCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";

                var options = new CustomerCreateOptions
                {
                    Name = txtFullName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Balance = 0,
                    Description = "test customer through application",
                    PreferredLocales = new List<string>
                {
                    "en",
                }
                };
                var service = new CustomerService();
                var customer = service.Create(options);

                // Success, give feedback to user
                MessageBox.Show("Creation details: " + customer, "Account Creation");

                // Success -> Add user ID in local settings file.
                Properties.Settings.Default.stripeUserID = customer.Id;
                Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(Properties.Settings.Default.stripeUserID,"DEBUG_MODE");
        }
    }
}
