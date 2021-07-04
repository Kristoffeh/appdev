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
        #region - Variables -
        string Preset_iPhoneX = "iPhoneX";
        string Preset_Samsung9 = "Samsung9";
        string Preset_Samsung10 = "Samsung10";
        string Preset_iPhone11 = "iPhone11";
        string Preset_HuaweiP30 = "HuaweiP30";
        string Preset_GalaxyTab3 = "GalaxyTab3";
        string Preset_Laptop = "Laptop";
        string Preset_Desktop = "Desktop";

        int[] size_iPhoneX = new int[] { 375, 862 };
        int[] size_Samsung9 = new int[] { 360, 715 };
        int[] size_Samsung10 = new int[] { 360, 715 };
        int[] size_iPhone11 = new int[] { 375, 715 };
        int[] size_HuaweiP30 = new int[] { 375, 715 };
        int[] size_GalaxyTab3 = new int[] { 1280, 800 };
        int[] size_Laptop = new int[] { 1366, 768 };
        int[] size_Desktop = new int[] { 1920, 1080 };
        #endregion

        // int activeDisplay = 0;


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

            // MessageBox.Show("Selected Preset = " + Properties.Settings.Default.selectedPreset ,"DEBUG_MODE ACTIVE");
            // MessageBox.Show("Selected Size = " + Properties.Settings.Default.selectedSizeWidth + "x" + Properties.Settings.Default.selectedSizeHeight , "DEBUG_MODE ACTIVE");
            // Load last used preset
            // width x height
            Width = Properties.Settings.Default.selectedSizeWidth;
            Height = Properties.Settings.Default.selectedSizeHeight;

            var prst = Properties.Settings.Default.selectedPreset;
            var rz = Properties.Settings.Default.toggleResizing;

            if (prst == Preset_iPhoneX) { iphonex.IsChecked = true; }
            if (prst == Preset_Samsung9) { samsungs9.IsChecked = true; }
            if (prst == Preset_Samsung10) { samsungs10.IsChecked = true; }
            if (prst == Preset_iPhone11) { iPhone11.IsChecked = true; }
            if (prst == Preset_HuaweiP30) { huaweip30.IsChecked = true; }
            if (prst == Preset_GalaxyTab3) { galaxyTab3.IsChecked = true; }
            if (prst == Preset_Laptop) { Laptop.IsChecked = true; }
            if (prst == Preset_Desktop) { Desktop.IsChecked = true; }

            if (rz == false)
            {
                ResizeMode = ResizeMode.NoResize;
            }
            else
            {
                ResizeMode = ResizeMode.CanResize;
            }
        }

        public void uncheckDisplays()
        {
            iphonex.IsChecked = false;
            samsungs9.IsChecked = false;
            samsungs10.IsChecked = false;
            iPhone11.IsChecked = false;
            huaweip30.IsChecked = false;
            galaxyTab3.IsChecked = false;
            Laptop.IsChecked = false;
            Desktop.IsChecked = false;
        }

        #region ' Display Sizes '
        private void iphonex_Click(object sender, RoutedEventArgs e)
        {
            uncheckDisplays();

            Width = size_iPhoneX[0];
            Height = size_iPhoneX[1];

            // set as checked
            iphonex.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_iPhoneX;
            Properties.Settings.Default.selectedSizeWidth = size_iPhoneX[0];
            Properties.Settings.Default.selectedSizeHeight= size_iPhoneX[1];
            Properties.Settings.Default.Save();

        }

        private void samsungs9_Click(object sender, RoutedEventArgs e)
        {
            uncheckDisplays();

            Width = size_Samsung9[0];
            Height = size_Samsung9[1];

            // set as checked
            samsungs9.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_Samsung9;
            Properties.Settings.Default.selectedSizeWidth = size_Samsung9[0];
            Properties.Settings.Default.selectedSizeHeight = size_Samsung9[1];
            Properties.Settings.Default.Save();
        }

        private void samsungs10_Click(object sender, RoutedEventArgs e)
        {
            Width = size_Samsung10[0];
            Height = size_Samsung10[1];

            // set as checked
            samsungs10.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_Samsung10;
            Properties.Settings.Default.selectedSizeWidth = size_Samsung10[0];
            Properties.Settings.Default.selectedSizeHeight = size_Samsung10[1];
            Properties.Settings.Default.Save();
        }

        private void iphone11_Click(object sender, RoutedEventArgs e)
        {
            uncheckDisplays();

            Width = size_iPhone11[0];
            Height = size_iPhone11[1];

            // set as checked
            iPhone11.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_iPhone11;
            Properties.Settings.Default.selectedSizeWidth = size_iPhone11[0];
            Properties.Settings.Default.selectedSizeHeight = size_iPhone11[1];
            Properties.Settings.Default.Save();
        }

        private void huaweip30_Click(object sender, RoutedEventArgs e)
        {
            uncheckDisplays();

            Width = size_HuaweiP30[0];
            Height = size_HuaweiP30[1];

            // set as checked
            huaweip30.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_HuaweiP30;
            Properties.Settings.Default.selectedSizeWidth = size_HuaweiP30[0];
            Properties.Settings.Default.selectedSizeHeight = size_HuaweiP30[1];
            Properties.Settings.Default.Save();
        }

        private void galaxyTab3_Click(object sender, RoutedEventArgs e)
        {
            uncheckDisplays();

            Width = size_GalaxyTab3[0];
            Height = size_GalaxyTab3[1];

            // set as checked
            galaxyTab3.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_GalaxyTab3;
            Properties.Settings.Default.selectedSizeWidth = size_GalaxyTab3[0];
            Properties.Settings.Default.selectedSizeHeight = size_GalaxyTab3[1];
            Properties.Settings.Default.Save();
        }

        private void laptop_Click(object sender, RoutedEventArgs e)
        {
            uncheckDisplays();

            Width = size_Laptop[0];
            Height = size_Laptop[1];

            // set as checked
            Laptop.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_Laptop;
            Properties.Settings.Default.selectedSizeWidth = size_Laptop[0];
            Properties.Settings.Default.selectedSizeHeight = size_Laptop[1];
            Properties.Settings.Default.Save();
        }

        private void desktop_Click(object sender, RoutedEventArgs e)
        {
            uncheckDisplays();

            Width = size_Desktop[0];
            Height = size_Desktop[1];

            // set as checked
            Desktop.IsChecked = true;

            // Save as last used preset
            Properties.Settings.Default.selectedPreset = Preset_Desktop;
            Properties.Settings.Default.selectedSizeWidth = size_Desktop[0];
            Properties.Settings.Default.selectedSizeHeight = size_Desktop[1];
            Properties.Settings.Default.Save();
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
