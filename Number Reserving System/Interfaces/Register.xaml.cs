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
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void LogoutBttn_Click(object sender, RoutedEventArgs e)
        {
            Login loginWinShow = new Login();
            loginWinShow.Show();

            this.Close();
        }

        private void ContinueBttn_Click(object sender, RoutedEventArgs e)
        {
            Services servicesWinShow = new Services();
            servicesWinShow.Show();

            this.Close();
        }
    }
}
