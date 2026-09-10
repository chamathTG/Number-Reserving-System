using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using Number_Reserving_System.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Number_Reserving_System.Interfaces.AdminUC
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            LoadDataToUserTable();
            LoadPinToPB();

            DataObject.AddPastingHandler(RoleTB, BlockingPaste);
            DataObject.AddPastingHandler(UsernameTB, BlockingPaste);
            DataObject.AddPastingHandler(PassPB, BlockingPaste);
            DataObject.AddPastingHandler(PinPB, BlockingPaste);
        }

        private void ClearFields()
        {
            UsernameTB.Clear();
            PassPB.Clear();
            RoleTB.Clear();
        }

        private void BlockingPaste(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private void RoleTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^AOV]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void RoleTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void UsernameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^a-zA-Z0-9]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void UsernameTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void PassPB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^a-zA-Z0-9@#*&!]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void PassPB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void PinPB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex limit = new Regex("[^0-9]");
            e.Handled = limit.IsMatch(e.Text);
        }

        private void PinPB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //----------- Database Connected Methods -----------

        DataBase db = new DataBase();
        private string OriginalUsername = "dummy";
        private int CurrentPin = 0;

        private void LoadPinToPB()
        {
            using (SqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string Query = "SELECT Pin_Num FROM Pin WHERE Id = 1";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        object pin = command.ExecuteScalar();

                        if (pin != null)
                        {
                            CurrentPin = Convert.ToInt32(pin);
                            PinPB.Password = pin.ToString();
                        }
                    }
                }
                catch(Exception ex)
                {
                    Message messageWin = new Message();
                    messageWin.OpacityHandler(Window.GetWindow(this));
                    messageWin.TrueBttnTxt.Text = "OK";
                    messageWin.MsgTB.Text = ex.Message;
                    messageWin.ShowDialog();
                }
            }
        }

        private void LoadDataToUserTable()
        {
            using (SqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string Query = "SELECT Username, Password, Role FROM Logins";

                    SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    UsersTable.ItemsSource = table.DefaultView;
                }
                catch (Exception ex)
                {
                    Message messageWin = new Message();
                    messageWin.OpacityHandler(Window.GetWindow(this));
                    messageWin.TrueBttnTxt.Text = "OK";
                    messageWin.MsgTB.Text = ex.Message;
                    messageWin.ShowDialog();
                }
            }
        }

        private void UsersTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersTable.SelectedItem is DataRowView row)
            {
                OriginalUsername = row["Username"].ToString();

                UsernameTB.Text = row["Username"].ToString();
                PassPB.Password = row["Password"].ToString();
                RoleTB.Text = row["Role"].ToString();
            }
        }

        private void AddUserBttn_Click(object sender, RoutedEventArgs e)
        {
            Message messageWin = new Message();
            messageWin.OpacityHandler(Window.GetWindow(this));
            messageWin.TrueBttnTxt.Text = "OK";

            if (string.IsNullOrWhiteSpace(UsernameTB.Text) || string.IsNullOrWhiteSpace(PassPB.Password) || string.IsNullOrWhiteSpace(RoleTB.Text))
            {
                messageWin.MsgTB.Text = "Fill all the fields!";
                messageWin.ShowDialog();

                return;
            }

            string Username = UsernameTB.Text;
            string Password = PassPB.Password;
            string Role = RoleTB.Text;

            using (SqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string Query = @"INSERT INTO Logins (Username, Password, Role) VALUES (@Username, @Password, @Role)";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Role", Role);

                        command.ExecuteNonQuery();
                        LoadDataToUserTable();
                        ClearFields();

                        messageWin.MsgTB.Text = "User added successfully.";
                        messageWin.ShowDialog();

                        UsernameTB.Clear();
                        PassPB.Clear();
                        RoleTB.Clear();
                    }
                }
                catch (Exception ex)
                {
                    messageWin.MsgTB.Text = ex.Message;
                    messageWin.ShowDialog();
                }
            }
        }

        private void EditUserBttn_Click(object sender, RoutedEventArgs e)
        {
            Message messageWin = new Message();
            messageWin.OpacityHandler(Window.GetWindow(this));
            messageWin.TrueBttnTxt.Text = "OK";

            if (string.IsNullOrWhiteSpace(UsernameTB.Text) || string.IsNullOrWhiteSpace(PassPB.Password) || string.IsNullOrWhiteSpace(RoleTB.Text))
            {
                messageWin.MsgTB.Text = "Fill all the fields!";
                messageWin.ShowDialog();

                return;
            }

            string Username = UsernameTB.Text;
            string Password = PassPB.Password;
            string Role = RoleTB.Text;

            using (SqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string Query = @"UPDATE Logins SET Username = @Username, Password = @Password, Role = @Role WHERE Username = @OldUsername";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Role", Role);

                        command.Parameters.AddWithValue("@OldUsername", OriginalUsername);

                        command.ExecuteNonQuery();
                        LoadDataToUserTable();
                        ClearFields();

                        messageWin.MsgTB.Text = "User updated successfully.";
                        messageWin.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    messageWin.MsgTB.Text = ex.Message;
                    messageWin.ShowDialog();
                }
            }
        }

        private void DelUserBttn_Click(object sender, RoutedEventArgs e)
        {
            Message messageWin = new Message();
            messageWin.OpacityHandler(Window.GetWindow(this));
            messageWin.TrueBttnTxt.Text = "OK";

            if (string.IsNullOrWhiteSpace(UsernameTB.Text))
            {
                messageWin.MsgTB.Text = "Enter the Username!";
                messageWin.ShowDialog();

                return;
            }

            string Username = UsernameTB.Text;

            using (SqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string Query = @"DELETE FROM Logins WHERE Username = @username";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@username", Username);

                        int AffectedRows = command.ExecuteNonQuery();

                        if (AffectedRows > 0)
                        {
                            messageWin.MsgTB.Text = "User deleted successfully.";
                            messageWin.ShowDialog();
                        }
                        else
                        {
                            messageWin.MsgTB.Text = "Username not found!";
                            messageWin.ShowDialog();
                        }

                        LoadDataToUserTable();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    messageWin.MsgTB.Text = ex.Message;
                    messageWin.ShowDialog();
                }
            }
        }

        private void EditPinBttn_Click(object sender, RoutedEventArgs e)
        {
            Message messageWin = new Message();
            messageWin.OpacityHandler(Window.GetWindow(this));
            messageWin.TrueBttnTxt.Text = "OK";

            if (string.IsNullOrWhiteSpace(PinPB.Password))
            {
                messageWin.MsgTB.Text = "Enter a new Pin!";
                messageWin.ShowDialog();
                LoadPinToPB();

                return;
            }

            int NewPin = int.Parse(PinPB.Password);

            if (NewPin == CurrentPin)
            {
                messageWin.MsgTB.Text = "Can't update to the same Pin!";
                messageWin.ShowDialog();

                return;
            }

            using (SqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string Query = @"UPDATE Pin SET Pin_Num = @Pin WHERE Id = 1";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@Pin", NewPin);

                        command.ExecuteNonQuery();
                        LoadPinToPB();

                        messageWin.MsgTB.Text = "Pin updated successfully.";
                        messageWin.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    messageWin.MsgTB.Text = ex.Message;
                    messageWin.ShowDialog();
                }
            }
        }
    }
}
