using appdev.Classes;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CardAdd.xaml
    /// </summary>
    public partial class CardAdd : Window
    {
        Logger log = new Logger();

        public CardAdd()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show();
        }

        private void btnCVCNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtCardNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regex regex = new Regex("[^0-9]+");
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            // this.txtCardNumber.Text = string.Format("************{0}", this.txtCardNumber.Text.Trim().Substring(12, 4));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // User is ready to process card authentication to stripe.
        private void btnSaveCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool success = false;

                // Clear old warning messages
                errorLogs.Text = "";

                #region - Stripe Authentication key -
                StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";
                #endregion

                // Conversions
                int month = Convert.ToInt32(btnExpMonth.Text);
                int year = Convert.ToInt32(btnExpYear.Text);
                string currentYear = DateTime.Now.Year.ToString();

                if (btnCardNumber.Text.Length == 0)
                {
                    UpdateLog("Please enter a card number!");
                }
                else if (month > 12)
                {
                    UpdateLog("Expiry month cannot be more than 12!");
                }
                else if (btnExpYear.Text.Length != 4)
                {
                    UpdateLog("Expiry year must contain 4 numbers!");
                }
                else if (btnExpYear.Text.Length > 2050)
                {
                    UpdateLog("Expiry year cannot be greater than year 2050!");
                }
                else if (btnCVC.Text.Length != 3)
                {
                    UpdateLog("CVC needs to be a length of 3!");
                }
                else
                {
                    // Create card
                    var options = new PaymentMethodCreateOptions
                    {
                        Type = "card",
                        Card = new PaymentMethodCardOptions
                        {
                            Number = btnCardNumber.Text,
                            ExpMonth = Convert.ToInt32(btnExpMonth.Text),
                            ExpYear = Convert.ToInt32(btnExpYear.Text),
                            Cvc = btnCVC.Text,
                        },
                    };
                    var service = new PaymentMethodService();
                    var cardCreated = service.Create(options);

                    // Attach card to User ID
                    var attachoptions = new PaymentMethodAttachOptions
                    {
                        Customer = Properties.Settings.Default.stripeUserID,
                    };
                    var attachservice = new PaymentMethodService();

                    attachservice.Attach(cardCreated.Id, attachoptions);
                    // success = true;
                    // UpdateLog("Card successfully saved with ID " + cardCreated.Id);
                    UpdateLog("Card successfully saved, you can close this window.");
                    this.Close();
                    CustomerPaymentOptions ca = new CustomerPaymentOptions();
                    ca.Show();
                }

                if (success == true)
                {
                    MessageBox.Show("Successfully added payment method.", "Success", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
            }
        }
        public void UpdateLog(string message)
        {
            errorLogs.Text += message + Environment.NewLine;
        }
    }
}
