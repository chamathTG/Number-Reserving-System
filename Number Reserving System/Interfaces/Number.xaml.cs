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
    /// Interaction logic for Number.xaml
    /// </summary>
    public partial class Number : Window
    {
        public Number()
        {
            InitializeComponent();
        }

        private void CancelBttn_Click(object sender, RoutedEventArgs e)
        {
            Message messageWinShow = new Message();
            messageWinShow.Show();
        }
    }
}
