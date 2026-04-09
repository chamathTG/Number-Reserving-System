using System;
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
    public partial class Number : Window
    {
        static int theNumber = 0;

        Register registerWin = new Register();

        public Number()
        {
            InitializeComponent();
        }

        public void NumberHandler()
        {
            theNumber++;

            if(theNumber <= 9999)
            {
                NumberTxt.Text = theNumber.ToString("D4");
            }
            else
            {
                theNumber = 1;
                NumberTxt.Text = theNumber.ToString("D4");
            }
        }

        private void PrintBttn_Click(object sender, RoutedEventArgs e)
        {
            var messageWin = new Message();

            messageWin.OpacityHandler(this);
            messageWin.AutoClose();
            messageWin.MsgWinModifier();
            messageWin.MsgTB.Text = "- Please take your printed number -\n\nHAVE A NICE DAY!";
            messageWin.ShowDialog();
            registerWin.Show();
            this.Close();
        }

        private void SmsBttn_Click(object sender, RoutedEventArgs e)
        {
            var messageWin = new Message();

            messageWin.OpacityHandler(this);
            messageWin.AutoClose();
            messageWin.MsgWinModifier();
            messageWin.MsgTB.Text = "- Number is sent as a SMS -\n\nHAVE A NICE DAY!";
            messageWin.ShowDialog();
            registerWin.Show();
            this.Close();
        }

        private void CancelBttn_Click(object sender, RoutedEventArgs e)
        {
            var messageWin = new Message();

            messageWin.OpacityHandler(this);
            messageWin.Height = 173;
            messageWin.MsgTB.Text = "Are you sure to Delete the Number?";
            messageWin.TrueBttnTxt.Text = "YES";
            messageWin.FalseBttn.Visibility = Visibility.Visible;
            messageWin.FalseBttnTxt.Text = "NO";
            messageWin.ShowDialog();

            if (messageWin.isBtnClicked == true)
            {
                registerWin.Show();
                messageWin.Close();
                this.Close();
            }
            else if (messageWin.isBtnClicked == false)
            {
                messageWin.Close();
            }
        }
    }
}
