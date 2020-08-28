using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordAddIn_SQLiteDB
{
    /// <summary>
    /// Interaction logic for SaveUserControl.xaml
    /// </summary>
    public partial class SaveUserControl : UserControl
    {
        public SaveUserControl()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = "INSERT INTO Customers (FirstName, LastName) VALUES (@FirstName, @LastName)";
                using (var connection = new SQLiteConnection(ThisAddIn.connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        var firstName = firstNameTextBox.Text;
                        var lastName = lastNameTextBox.Text;

                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        var result = command.ExecuteNonQuery();
                    }
                }

                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
