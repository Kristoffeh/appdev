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
            toggleResizing.IsChecked = Properties.Settings.Default.toggleResizing;
        }

        private void btnSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            // Discard user settings and close
            this.Close();
        }

        public void saveAllSettings()
        {
            // Apply user settings
            Properties.Settings.Default.setURL = url_preview.Text;
            Properties.Settings.Default.toggleResizing = toggleResizing.IsChecked.Value;



            // Save settings
            Properties.Settings.Default.Save();
        }

        private void btnSettingsApply_Click(object sender, RoutedEventArgs e)
        {
            saveAllSettings();

            // Disable apply button for feedback
            btnSettingsApply.IsEnabled = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void url_preview_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow user to save changes after making changes.
            btnSettingsApply.IsEnabled = true;

            if (e.Key == Key.Enter)
            {
                // Save changes by pressing ENTER.
                saveAllSettings();
                btnSettingsApply.IsEnabled = false;
            }
        }

        private void toggleResizing_Click(object sender, RoutedEventArgs e)
        {
            btnSettingsApply.IsEnabled = true;
        }
    }
}
