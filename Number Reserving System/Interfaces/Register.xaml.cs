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
    public partial class Register : Window
    {
        Message messageWin = new Message();

        public Register()
        {
            InitializeComponent();
        }

        private void LogoutBttn_Click(object sender, RoutedEventArgs e)
        {
            Pin pinWin = new Pin();

            pinWin.PinWinOpacityHandler(this);
            pinWin.ShowDialog();
        }

        private void ContinueBttn_Click(object sender, RoutedEventArgs e)
        {
            messageWin.OpacityHandler(this);
            messageWin.TrueBttnTxt.Text = "OK";

            if ((String.IsNullOrWhiteSpace(NameTB.Text)) && (String.IsNullOrWhiteSpace(NumTB.Text)) && (String.IsNullOrWhiteSpace(IdNumTB.Text)))
            {
                messageWin.MsgTB.Text = "Please fill your details!";
                messageWin.ShowDialog();
            }
            else if((String.IsNullOrWhiteSpace(NameTB.Text)) || (String.IsNullOrWhiteSpace(NumTB.Text)) || (String.IsNullOrWhiteSpace(IdNumTB.Text)))
            {
                messageWin.MsgTB.Text = "Please complete your details!";
                messageWin.ShowDialog();
            }
            else
            {
                Services servicesWin = new Services();
                servicesWin.Show();

                this.Close();
            }
        }

        private void NameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^a-zA-Z ]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void NumTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^0-9+]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void IdNumTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^0-9vV]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void NumTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void IdNumTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
