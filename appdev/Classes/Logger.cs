using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace appdev.Classes
{
    public class Logger
    {
        public void DisplayLog(string message, string header, string button_type, string image)
        {
            MessageBoxImage img = MessageBoxImage.None;
            MessageBoxButton btn = MessageBoxButton.OK;

            #region - button type -
            if (button_type == "ok")
            {
                btn = MessageBoxButton.OK;
            }
            else if (button_type == "ok cancel")
            {
                btn = MessageBoxButton.OKCancel;
            }
            else if (button_type == "yes no")
            {
                btn = MessageBoxButton.YesNo;
            }
            else if (button_type == "yes no cancel")
            {
                btn = MessageBoxButton.YesNoCancel;
            }
            #endregion

            #region - log type -
            if (image == "warning")
            {
                img = MessageBoxImage.Warning;
            }
            else if (image == "error")
            {
                img = MessageBoxImage.Error;
            }
            else if (image == "info" || image == "information")
            {
                img = MessageBoxImage.Information;
            }
            else if (image == "question")
            {
                img = MessageBoxImage.Question;
            }
            else if (image == "stop")
            {
                img = MessageBoxImage.Stop;
            }
            else if (image == "hand")
            {
                img = MessageBoxImage.Hand;
            }
            #endregion

            // Display MessageBox
            MessageBox.Show(message, header, btn, img);
        }
    }
}
