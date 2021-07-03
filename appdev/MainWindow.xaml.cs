using CefSharp;
using CefSharp.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using nUpdate.Updating;
using System.Globalization;
using System.Threading;

namespace appdev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int default_width = 375;

        const int height_iphonex = 862;

        const int width_samsungs9 = 360;
        const int height_samsungs9 = 790;

        const int width_samsungs10 = 360;
        const int height_samsungs10 = 810;

        const int width_iphone11 = 276;
        const int height_iphone11 = 648;

        const int width_p30 = 360;
        const int height_p30 = 830;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateManager manager = new UpdateManager(new Uri("http://171.22.152.50/Autoupdate/updates.json"), "<RSAKeyValue><Modulus>xrZGU0b25BslORvfovprGPVh0B+UOSO5VZcaZXW3nP1VWivPqdBcJDfDGwi+i1jJRPu/b6TPNpCpkCjbTtQDGkC0l1DxcY3p8LGJEOV4g/Gdn0LSULQdjSfBYOF6mh5mG6v+Arr0s10/JRRujIo/oSgUmK9A82iAh6dtgr0/a94zNjPHPC5jSTPD2YCbZmNaxX5tJgfRoqaAgYCeZyfmDAOXc+cGd09UYwsySi+Ox8wzksWB0BTZHLZTQQ5e0jN+LvVpwkMWYXdKqZ1bfPJv2CPQW9Ek6mX4l+NP3vUCWMUhJNUUTc6BjuAP8Xl4oR4Fo44slRWZtyzjNOvizrBXtHXXTQkIUdPbVjhs6di+vt++128kz6OYjZtuqjwxjLAn62ihm6VKk1BVmaP1oZO8FBkJOoU9qBMz65AT7uz4VOiZ+TPwPgO+YdUfLsPSQJWKz91pIRYHes9xy3fMMgzs/LVgOu+mfcC1cYVGOkG+CSlmCoReKtngL96PbVECF+BDsMt3Ke/mlrct2nkhSL1mHBqBAD3esgbPcXxO/gGFBviO24XADtuftZ88vcNVHR6Vlp+YZ1TOgUiv8t9/5C19866/hqjHiiaKY1ippsQQNsLh77dqtm2R4FuyVCPMkqVhfm9ebIg8zptZSQNh9/X05z35pClf80s4yBpJ53ehgHnFqcJYUeWS8pJQUoao78xCqSHhxbIhfGldgpRfWUGSkPcNY4/gC0dtFU+sZt4sAAC7jQZgCez1UqnpJtWzAxC9EsBUGN3IIiHv6Fm70jAHC+AMAOxgQXlx3qpuC3ftA8FB8RY+7S9LVU07LPiRBypPawgCP926v40C5ZkcziRAZyHeO4HYxIUm0Cm7nW1H/7e4gZHKJRIa0QXOX6JXybpwtZToblhCvwnP1U9rmUD/eurCp5gkEQaHRMUmiVSGPRLExbK03LS2ZBxQW+6MRzP00nHI0bRWAJCEjHgu1v704DLLZJbnz5xJVXHwWr/wY06PoGFRwX3lga82drp21ucgkTZ+USqPJUYwjhcI2zJVgvTy5kkENer0oNhO1nN9trV0O3A2IzoK3IBz//slo+gcc9TIjtD7jaPJvQgqqrzym/Q0WReA3TevRHgUKWU3aoi67dyDjJrX2u4OOuNKu9c2gJ/yWo2/yIXvnb2mt1paodlUqbmBRePKNPBlEUXDJKtZOszZzm7vu1caKzFBftVFfXMba1aGYkgp8iXmqMcK/vPcuOdySXAfZ3CjnPLvCdr+3Crs48VRN+HqqegvMyM5wNdmU7uHsCzYE8tNaUWiGpgW/aV74Abf/wvMEvthXlTb+1w7xU2f73SlZAlOsgpciQSbxqOD33kmGdqWxfDhhQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", new CultureInfo("en"));

            var updaterUI = new UpdaterUI(manager, SynchronizationContext.Current);
            updaterUI.ShowUserInterface();

            webBrowser.Address = Properties.Settings.Default.setURL;
        }




        #region ' Phone Sizes '
        private void iphonex_Click(object sender, RoutedEventArgs e)
        {
            Width = default_width;
            Height = height_iphonex;
        }

        private void samsungs9_Click(object sender, RoutedEventArgs e)
        {
            Width = width_samsungs9;
            Height = height_samsungs9;
        }

        private void samsungs10_Click(object sender, RoutedEventArgs e)
        {
            Width = width_samsungs10;
            Height = height_samsungs10;
        }

        private void iphone11_Click(object sender, RoutedEventArgs e)
        {
            Width = width_iphone11;
            Height = height_iphone11;
        }

        private void huaweip30_Click(object sender, RoutedEventArgs e)
        {
            Width = width_p30;
            Height = height_p30;
        }
        #endregion

        private void refreshpage_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Address = Properties.Settings.Default.setURL;
            webBrowser.Reload();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            var major = fileVersionInfo.FileMajorPart;
            var minor = fileVersionInfo.FileMinorPart;
            var build = fileVersionInfo.FileBuildPart;

            MessageBox.Show("Developed by Kriss - " + "You're running v" + major + "." + minor + " - Build " + build, "About Us");
        }

        private void open_settings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserSettings stt = new UserSettings();
                stt.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "error");
            }
        }
    }
}
