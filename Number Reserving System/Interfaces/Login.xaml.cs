using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
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

        //-- This part removes the default rounded corners of windows 11 ---------------

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
            Message messageWin = new Message();

            messageWin.OpacityHandler(this);
            messageWin.TrueBttnTxt.Text = "OK";

            if ((String.IsNullOrWhiteSpace(UsernameTB.Text)) && (String.IsNullOrWhiteSpace(PassTB.Password)))
            {
                messageWin.MsgTB.Text = "Username and Password is empty!";
                messageWin.ShowDialog();
            }
            else if (String.IsNullOrWhiteSpace(UsernameTB.Text))
            {
                messageWin.MsgTB.Text = "Username is empty!";
                messageWin.ShowDialog();
            }
            else if(String.IsNullOrWhiteSpace(PassTB.Password))
            {
                messageWin.MsgTB.Text = "Password is empty!";
                messageWin.ShowDialog();
            }
            else
            {
                Register registerWin = new Register();
                registerWin.Show();

                this.Close();
            }
        }

        private void UsernameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^a-zA-Z0-9@_]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void PassTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^a-zA-Z0-9@#*_]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void UsernameTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void PassTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
