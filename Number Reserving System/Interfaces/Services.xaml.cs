using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
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
    public partial class Services : Window
    {
        public Services()
        {
            InitializeComponent();
        }

        private void BackBttn_Click(object sender, RoutedEventArgs e)
        {
            var messageWin = new Message();

            messageWin.OpacityHandler(this);

            messageWin.MsgTB.Text = "Are you sure to cancel the process?";
            messageWin.TrueBttnTxt.Text = "YES";
            messageWin.FalseBttn.Visibility = Visibility.Visible;
            messageWin.FalseBttnTxt.Text = "NO";

            messageWin.ShowDialog();

            if(messageWin.isBtnClicked == true)
            {
                Register registerWin = new Register();
                registerWin.Show();

                this.Close();
            }
            else if(messageWin.isBtnClicked == false)
            {
                messageWin.Close();
            }
        }

        public void toNumberWin(Window currentWindow)
        {
            Number numberWin = new Number();

            numberWin.NumberHandler();
            numberWin.Show();

            currentWindow.Close();
        }

        private void Serv1Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void Serv2Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void Serv3Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void Serv4Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void Serv5Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void Serv6Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void Serv7Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void Serv8Btn_Click(object sender, RoutedEventArgs e)
        {
            toNumberWin(this);
        }

        private void OtherServiceBttn_Click(object sender, RoutedEventArgs e)
        {
            OtherServices otherServicesWinShow = new OtherServices();
            otherServicesWinShow.Show();

            this.Close();
        }
    }
}
