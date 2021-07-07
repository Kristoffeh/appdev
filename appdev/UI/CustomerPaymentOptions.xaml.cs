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
            public string CVC { get; set; }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                #region - Events -
                listView.SelectionChanged += onSelectionChanged;
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
                var servicea = new CustomerService();
                var r_customer = servicea.Get(Properties.Settings.Default.stripeUserID);

                // Get account balance
                var sd = new BalanceService();
                Balance balance = sd.Get();

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

                #region - Card doesn't exist / add cards -
                // If no cards are added
                if (cards.Count() == 0)
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

  /*                      listViewOverview.Add(0, "" + i);
                        listViewOverview.Add(1, "" + pm.Id);
                        listViewOverview.Add(2, "" + myTI.ToTitleCase(pm.Card.Brand));
                        listViewOverview.Add(3, "**** **** **** " + pm.Card.Last4);
                        listViewOverview.Add(4, pm.Card.ExpMonth + "/" + pm.Card.ExpYear);
                        listViewOverview.Add(5, "***");*/

                        // Add items
                        listView.Items.Add(
                            new Cards
                            {
                                UserID = pm.Id,
                                Type = myTI.ToTitleCase(pm.Card.Brand),
                                CardNumber = "**** **** **** " + pm.Card.Last4,
                                Exp = pm.Card.ExpMonth + "/" + pm.Card.ExpYear,
                                CVC = "***",
                            }
                        );
                    }

                    // Display stored items in a StackPanel
                    vertiStacker.Children.Add(listView);

                    string cust_id = c.Id;


                    // MessageBox.Show(paymentMethods., "");
                    // cbListCards.Content = "";
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message ,"");
                throw;
            }
        }

        // When user wants to delete a card.
        private void btnDeleteCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var service = new CardService();
                service.Delete(
                  Properties.Settings.Default.stripeUserID,
                  Properties.Settings.Default.stripeSelectedCard
                );

                MessageBox.Show("The selected card has been removed from your account.", "Card Removed");


                // listView.Items.RemoveAt(listView.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"");
            }
        }

        // When an item in listView is clicked.
        private void onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Get ID selected item
                Cards card = (Cards)listView.SelectedItems[0];

                // Save value to temporary local user settings.
                Properties.Settings.Default.stripeSelectedCard = card.ID;

                // Save changes to local user settings.
                Properties.Settings.Default.Save();

                // listView.SelectedIndex
                // MessageBox.Show("" + card.Index);
                // listView.Items.RemoveAt(listView.SelectedIndex);

                // this.listView.Items.Remove(listView.SelectedItem);

                // listView.Items.Remove(card.Index);

                







            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");

                throw;
            }
        }
    }
}
