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
    /// Interaction logic for ViewUserControl.xaml
    /// </summary>
    public partial class ViewUserControl : UserControl
    {
        public ViewUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = "SELECT * FROM Customers;";
                var customers = new List<Customer>();

                using (var connection = new SQLiteConnection(ThisAddIn.connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                            });
                        }
                    }
                }

                customersListBox.ItemsSource = customers;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
