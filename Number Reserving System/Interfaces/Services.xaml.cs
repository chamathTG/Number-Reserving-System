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
    public partial class Services : Window
    {
        public Services()
        {
            InitializeComponent();
        }

        private void BackBttn_Click(object sender, RoutedEventArgs e)
        {
            Register registerWinShow = new Register();
            registerWinShow.Show();

            this.Close();
        }

        private void OtherServiceBttn_Click(object sender, RoutedEventArgs e)
        {
            OtherServices otherServicesWinShow = new OtherServices();
            otherServicesWinShow.Show();

            this.Close();
        }
    }
}
