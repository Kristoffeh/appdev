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

namespace appdev
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Window
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load user settings
            url_preview.Text = Properties.Settings.Default.setURL;
        }

        private void btnSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            // Discard user settings and close
            this.Close();
        }

        private void btnSettingsApply_Click(object sender, RoutedEventArgs e)
        {
            // Apply user settings
            Properties.Settings.Default.setURL = url_preview.Text;

            // Save settings
            Properties.Settings.Default.Save();

            // Disable apply button for feedback
            btnSettingsApply.IsEnabled = false;
        }
    }
}
