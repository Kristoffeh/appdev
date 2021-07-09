using appdev.Classes;
using Stripe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        Logger log = new Logger();

        // Show cards in ListView
        ListView listView = new ListView();
        IDictionary<int, string> listViewOverview = new Dictionary<int, string>();

        public CustomerPaymentOptions()
        {
            InitializeComponent();
        }

        public class Cards
        {
            public string ID { get; set; }
            public string UserID { get; set; }
            public string Type { get; set; }
            public string CardNumber { get; set; }
            public string Exp { get; set; }
            public long ExpMonth { get; set; }
            public long ExpYear { get; set; }
            public string CVC { get; set; }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                #region - Events -
                listView.SelectionChanged += onSelectionChanged;
                listView.PreviewMouseRightButtonDown += listView_PreviewMouseRightButtonDown;
                #endregion

                #region - GridView (required for ListView Columns) -
                // Enable gridview, its required to use columns.
                var gridView = new GridView();
                listView.View = gridView;
                listView.FontSize = 15;
                #endregion

                #region - Add ListView Columns when loading -
                // Define columns
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 40,
                    Header = "User ID",
                    DisplayMemberBinding = new Binding("UserID")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Type",
                    DisplayMemberBinding = new Binding("Type")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Card Number",
                    DisplayMemberBinding = new Binding("CardNumber")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Exp",
                    DisplayMemberBinding = new Binding("Exp")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "CVC",
                    DisplayMemberBinding = new Binding("CVC")
                });
                #endregion

                #region - Stripe Authentication (sensitive) -
                // Stripe Authentication
                StripeConfiguration.ApiKey = "sk_test_sUA4LoMrFUHdtNKDr311Q3hC00g25NqDKt";
                #endregion

                #region - Objects and Variables -
                // Customer object
                var servicea = new CustomerService();
                var r_customer = servicea.Get(Properties.Settings.Default.stripeUserID);

                // Get account balance
                var sd = new BalanceService();
                Balance balance = sd.Get();

                // List payment methods
                var opt = new PaymentMethodListOptions
                {
                    Customer = Properties.Settings.Default.stripeUserID,
                    Type = "card",
                };
                var sr = new PaymentMethodService();
                StripeList<PaymentMethod> paymentMethods = sr.List(opt);
                #endregion

                #region - Account Credit -
                // Remove last 2 digits
                long rm1 = r_customer.Balance / 10;
                long rm2 = rm1 / 10;

                // get last two digits
                long lastTwo = r_customer.Balance % 100;

                string a = rm2.ToString();
                string bstring = a.Replace("-", string.Empty);

                // BALANCE
                lblCreditValue.Content = "$" + String.Format("{0:0.00}", bstring);
                #endregion

                #region ' Default Payment Method '
/*                if (r_customer.InvoiceSettings.DefaultPaymentMethodId == "")
                {
                    lblPaymentMethod.Content = "Default Payment Method: None";
                }
                else
                {
                    lblPaymentMethod.Content = "Default Payment Method: " + r_customer.InvoiceSettings.DefaultPaymentMethodId;
                }*/
                #endregion

                #region - Card doesn't exist / add cards -
                // If no cards are added
                if (paymentMethods.Count() == 0)
                {
                    // Give feedback to user that they don't have any cards set up.
                    lblNoCards.Visibility = Visibility.Visible;
                }
                else
                {
                    // myTi object is used for ToTitleCase which sets string first capital letter.
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

                    int i = -1;

                    foreach (PaymentMethod pm in paymentMethods.Data)
                    {

                        i++;

                        // Add items
                        listView.Items.Add(
                            new Cards
                            {
                                UserID = pm.Id,
                                Type = myTI.ToTitleCase(pm.Card.Brand),
                                CardNumber = "**** **** **** " + pm.Card.Last4,
                                Exp = pm.Card.ExpMonth + "/" + pm.Card.ExpYear,
                                ExpMonth = pm.Card.ExpMonth,
                                ExpYear = pm.Card.ExpYear,
                                CVC = "***",
                            }
                        );

                        /*var b = (Cards)listView.SelectedItems[0];
                        if (b.ID == r_customer.InvoiceSettings.DefaultPaymentMethodId)
                        {
                            
                        }*/












                    }

                    // Display stored items in a StackPanel
                    vertiStacker.Children.Add(listView);

                    string cust_id = r_customer.Id;


                    // MessageBox.Show(paymentMethods., "");
                    // cbListCards.Content = "";
                }
                #endregion
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        // When user wants to delete a card.
        private void btnDeleteCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.Items.Count == 0)
                {
                    log.DisplayLog("You don't have any cards listed, deletion process aborted.", "Not possible", "ok", "error");
                }
                else
                {
                    var service = new PaymentMethodService();
                    service.Detach(Properties.Settings.Default.stripeSelectedCard);

                    // Change state of CardAdded so that user is able to add cards again.
                    Properties.Settings.Default.stripeCardAdded = false;
                    Properties.Settings.Default.Save();

                    this.Close();
                    MessageBox.Show("The selected card has been removed from your account.", "Card Removed");

                }
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        // When an item in listView is clicked.
        private void onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Get ID selected item
                var s = (Cards)listView.SelectedItems[0];

                // Save value to temporary local user settings.
                // This property is used to cache the selected card when it is going to get deleted.
                Properties.Settings.Default.stripeSelectedCard = s.UserID;

                //  Store entire card number with 16 numbers
                Properties.Settings.Default.stripeSelectedCardNumberFull = s.CardNumber;

                // Store Expiration-date, CVC and ID for default payment method.
                Properties.Settings.Default.stripeSelectedExpiryDate = s.Exp;
                Properties.Settings.Default.stripeSelectedExpiryMonth = Convert.ToInt32(s.ExpMonth);
                Properties.Settings.Default.stripeSelectedExpiryYear = Convert.ToInt32(s.ExpYear);
                Properties.Settings.Default.stripeSelectedCVC = s.CVC;

                // Save changes to local user settings.
                Properties.Settings.Default.Save();

                // MessageBox.Show(Properties.Settings.Default.stripeSelectedCard);
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if user already has a card added
                if (listView.Items.Count == 1)
                {
                    MessageBox.Show("You already have 1 card added.", "Warning", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
                else
                {
                    this.Close();
                    CardAdd openCardAdd = new CardAdd();
                    openCardAdd.Show();

                }
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }





        }

        private void listView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
