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

namespace appdev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double prog_version = 2.1;
        const string author = "krissy";

        const int default_width = 375;
        const int default_height = 812;

        const int width_iphonex = 375;
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
            ScrollViewer s = new ScrollViewer();
            s.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

            System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            var major = fileVersionInfo.FileMajorPart;
            var minor = fileVersionInfo.FileMinorPart;
            var build = fileVersionInfo.FileBuildPart;


            lblVersion.Content = "Developed by " + author + " - " + "v" + major + "." + minor + " B" + build;
        }

        private void webBrowser_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            e.Handled = true;
        }

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
    }
}
