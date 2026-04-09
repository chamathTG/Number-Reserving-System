using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Number_Reserving_System.Interfaces
{
    public partial class Pin : Window
    {
        public Pin()
        {
            InitializeComponent();
        }

        public void PinWinOpacityHandler(Window pinWinOwner)
        {
            this.Owner = pinWinOwner;

            this.Loaded += (s, e) =>
            {
                pinWinOwner.Opacity = 0.5;
            };

            this.Closed += (s, e) =>
            {
                pinWinOwner.Opacity = 1;
            };
        }

        private void PinPB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^0-9]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void PinPB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void ExitBttn_Click(object sender, RoutedEventArgs e)
        {
            Login loginWin = new Login();
            loginWin.Show();

            this.Owner?.Close();
            this.Close();
        }

        private void CancelBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
