using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Number_Reserving_System.Interfaces
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.SourceInitialized += OnSourceInitialized;
        }

        //--- This part removes the default rounded corners of windows 11 ---------------

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;

            int cornerPreference = 1;
            DwmSetWindowAttribute(hwnd, 33, ref cornerPreference, sizeof(int));
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int dwAttribute,
            ref int pvAttribute,
            int cbAttribute);

        //--------------------------------------------------------------------------------

        private void CloseBttn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeBttn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LoginBttn_Click(object sender, RoutedEventArgs e)
        {
            if((UsernameTB.Text == "") && (PassTB.Password == ""))
            {
                Register registerWinShow = new Register();
                registerWinShow.Show();

                this.Close();

            }
        }
    }
}
