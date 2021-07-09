using appdev.Classes;
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
        Logger log = new Logger();

        public UserSettings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Load user settings
                url_preview.Text = Properties.Settings.Default.setURL;
                toggleResizing.IsChecked = Properties.Settings.Default.toggleResizing;
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void btnSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Discard user settings and close
                this.Close();
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        public void saveAllSettings()
        {
            try
            {
                // Apply user settings
                Properties.Settings.Default.setURL = url_preview.Text;
                Properties.Settings.Default.toggleResizing = toggleResizing.IsChecked.Value;



                // Save settings
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void btnSettingsApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                saveAllSettings();

                // Disable apply button for feedback
                btnSettingsApply.IsEnabled = false;
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void url_preview_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }

        private void toggleResizing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnSettingsApply.IsEnabled = true;
            }
            catch (Exception ex)
            {
                log.DisplayLog(ex.Message, "Exception Thrown", "ok", "error");
                throw;
            }
        }
    }
}
