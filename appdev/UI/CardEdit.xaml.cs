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
    /// Interaction logic for CardEdit.xaml
    /// </summary>
    public partial class CardEdit : Window
    {
        public CardEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCardNumber.Text = Properties.Settings.Default.stripeSelectedCard;
            txtExpMonth.Text = Properties.Settings.Default.stripeSelectedExpiryMonth.ToString();
            txtExpYear.Text = Properties.Settings.Default.stripeSelectedExpiryYear.ToString();
            txtCVC.Text = Properties.Settings.Default.stripeSelectedCVC;
            txtCardNumber.Text = Properties.Settings.Default.stripeSelectedCardNumberFull;

            // MessageBox.Show(Properties.Settings.Default.stripeDefaultPaymentMethod);
        }

        private void txtCVCNumberValidation(object sender, TextCompositionEventArgs e)
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


                var servicea = new CustomerService();
                var r_customer = servicea.Get(Properties.Settings.Default.stripeUserID);

                // Default Payment Method checkbox
                // Save changes to checkbox
                if (ckDefaultPaymentMethod.IsChecked == true)
                {
                    var optionss = new CustomerUpdateOptions
                    {
                        InvoiceSettings = new CustomerInvoiceSettingsOptions
                        {
                            DefaultPaymentMethod = Properties.Settings.Default.stripeSelectedCard
                        }
                    };
                    var services = new CustomerService();
                    services.Update(Properties.Settings.Default.stripeUserID, optionss);
                }
                else
                {
                    var optionss = new CustomerUpdateOptions
                    {
                        InvoiceSettings = new CustomerInvoiceSettingsOptions
                        {
                            DefaultPaymentMethod = ""
                        }
                    };
                    var services = new CustomerService();
                    services.Update(Properties.Settings.Default.stripeUserID, optionss);
                }





                // Conversions
                int month = Convert.ToInt32(txtExpMonth.Text);
                int year = Convert.ToInt32(txtExpYear.Text);
                string currentYear = DateTime.Now.Year.ToString();

                if (txtCardNumber.Text.Length == 0)
                {
                    UpdateLog("Please enter a card number!");
                }
                else if (month > 12)
                {
                    UpdateLog("Expiry month cannot be more than 12!");
                }
                else if (txtExpYear.Text.Length != 4)
                {
                    UpdateLog("Expiry year must contain 4 numbers!");
                }
                else if (txtExpYear.Text.Length > 2050)
                {
                    UpdateLog("Expiry year cannot be greater than year 2050!");
                }
                else if (txtCVC.Text.Length != 3)
                {
                    UpdateLog("CVC needs to be a length of 3!");
                }
                else
                {
                    // Update card details
                    var options = new PaymentMethodUpdateOptions
                    {
                        Card = new PaymentMethodCardOptions
                        {
                            ExpMonth = Convert.ToInt32(txtExpMonth.Text),
                            ExpYear = Convert.ToInt32(txtExpYear.Text),
                        },
                    };
                    var service = new PaymentMethodService();
                    var cardCreated = service.Update(Properties.Settings.Default.stripeSelectedCard, options);

                    // MessageBox.Show(Properties.Settings.Default.stripeSelectedCard);

                    // Attach card to User ID
/*                    var attachoptions = new PaymentMethodAttachOptions
                    {
                        Customer = Properties.Settings.Default.stripeUserID,
                    };
                    var attachservice = new PaymentMethodService();
                    attachservice.Attach(cardCreated.Id, attachoptions);*/

                    // success = true;
                    UpdateLog("Card successfully updated with ID " + cardCreated.Id);
                }

                if (success == true)
                {
                    MessageBox.Show("Successfully added payment method.", "Success", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateLog(string message)
        {
            errorLogs.Text += message + Environment.NewLine;
        }
    }
}
