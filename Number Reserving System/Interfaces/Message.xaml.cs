using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Number_Reserving_System.Interfaces
{
    public partial class Message : Window
    {
        public bool? isBtnClicked = null;
        
        public Message()
        {
            InitializeComponent();
        }

        public void TrueBttn_Click(object sender, RoutedEventArgs e)
        {
            isBtnClicked = true;
            this.Close();
        }

        private void FalseBttn_Click(object sender, RoutedEventArgs e)
        {
            isBtnClicked = false;
            this.Close();
        }

        public void OpacityHandler(Window msgOwner)
        {
            this.Owner = msgOwner;

            this.Loaded += (s, e) =>
            {
                msgOwner.Opacity = 0.5;
            };

            this.Closed += (s, e) =>
            {
                msgOwner.Opacity = 1;
            };
        }

        public void MsgWinModifier()
        {
            this.Width = 450;
            this.Height = 173;
            
            MainGrid.RowDefinitions[2].Height = new GridLength(0);
            MainGrid.RowDefinitions[3].Height = new GridLength(0);

            MsgTxtGrid.ColumnDefinitions[1].Width = new GridLength(0);

            MsgIcon.Visibility = Visibility.Collapsed;
            MsgTB.TextAlignment = TextAlignment.Center;
            MsgTB.FontWeight = FontWeights.Bold;
        }

        public async void AutoClose()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));

            if(this.IsVisible)
            {
                this.Close();
            }
        }
    }
}
