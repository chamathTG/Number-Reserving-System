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
    /// <summary>
    /// Interaction logic for OtherServices.xaml
    /// </summary>
    public partial class OtherServices : Window
    {
        public OtherServices()
        {
            InitializeComponent();
        }

        private void OsContinueBttn_Click(object sender, RoutedEventArgs e)
        {
            Number numberWinShow = new Number();
            numberWinShow.Show();

            this.Close();
        }

        private void OsBackBttn_Click(object sender, RoutedEventArgs e)
        {
            Services servicesWinShow = new Services();
            servicesWinShow.Show();

            this.Close();
        }
    }
}
