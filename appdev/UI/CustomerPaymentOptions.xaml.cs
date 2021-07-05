using Stripe;
using System;
using System.Collections.Generic;
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
        public CustomerPaymentOptions()
        {
            InitializeComponent();
        }

        public class Cards
        {
            public string Type { get; set; }
            public string CardNumber { get; set; }
            public string Exp { get; set; }
            public string CVC { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Show cards in ListView
                ListView li = new ListView();

                // Enable gridview, its required to use columns.
                var gridView = new GridView();
                li.View = gridView;
                li.FontSize = 15;


                

                


                // Define columns
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Type",
                    DisplayMemberBinding = new Binding("Type")
                }); ; ;
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
                    Customer = Properties.Settings.Default.stripeUserID,
                    Type = "card",
                };
                var sr = new PaymentMethodService();
                StripeList<PaymentMethod> paymentMethods = sr.List(opt);

                if (cards.Count() == 0)
                {
                    lblNoCards.Visibility = Visibility.Visible;
                }
                else
                {

                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

                    foreach (PaymentMethod pm in paymentMethods.Data)
                    {
                        int i = 1;
                        i++;

                        // Add items
                        li.Items.Add(
                            new Cards
                            {
                                Type = myTI.ToTitleCase(pm.Card.Brand),
                                CardNumber = "**** **** **** " + pm.Card.Last4,
                                Exp = pm.Card.ExpMonth + "/" + pm.Card.ExpYear,
                                CVC = "***"
                            }
                        );
                    }

                    // Display stored items in a StackPanel
                    vertiStacker.Children.Add(li);

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
