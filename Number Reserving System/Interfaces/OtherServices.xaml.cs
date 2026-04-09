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
    public partial class OtherServices : Window
    {
        public OtherServices()
        {
            InitializeComponent();
        }

        private void OsContinueBttn_Click(object sender, RoutedEventArgs e)
        {
            Number numberWinShow = new Number();
            Message messageWin = new Message();
            Services servicesWin = new Services();
            
            if(String.IsNullOrWhiteSpace(DiscripTB.Text))
            {
                messageWin.OpacityHandler(this);
                messageWin.TrueBttnTxt.Text = "OK";
                messageWin.MsgTB.Text = "Description is empty!";
                messageWin.ShowDialog();
            }
            else
            {
                servicesWin.toNumberWin(this);
            }
        }

        private void OsBackBttn_Click(object sender, RoutedEventArgs e)
        {
            Services servicesWinShow = new Services();
            servicesWinShow.Show();

            this.Close();
        }
    }
}
