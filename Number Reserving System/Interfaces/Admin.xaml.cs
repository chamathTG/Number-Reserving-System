using Number_Reserving_System.Interfaces.AdminUC;
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
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();

            MainContent.Content = new Users();
        }

        private void UsersBttn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Users();
        }

        private void NumbersBttn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Numbers();
        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Information();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Message messageWin = new Message();

            messageWin.OpacityHandler(this);

            messageWin.MsgTB.Text = "Are you sure to logout?";
            messageWin.TrueBttnTxt.Text = "YES";
            messageWin.FalseBttn.Visibility = Visibility.Visible;
            messageWin.FalseBttnTxt.Text = "NO";

            messageWin.ShowDialog();

            if (messageWin.isBtnClicked == true)
            {
                Login loginWin = new Login();
                loginWin.Show();

                this.Close();
            }
            else if (messageWin.isBtnClicked == false)
            {
                messageWin.Close();
            }
        }
    }
}
