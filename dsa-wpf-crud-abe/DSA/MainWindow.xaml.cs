using System;
using System.Collections.Generic;
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

namespace DSA
{
    public partial class MainWindow : Window
    {
        public List<string> Products { get; }
        public List<Item> ListOfItems { get; }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            // initialize data\
            Products = new List<string>
        {
            "Laptop",
            "PC",
            "Mobile",
        };

            ListOfItems = new List<Item>
        {
            new Item { Id = 1, Name = "Smartphone", Description = "shfus", Price = 1000},
            new Item { Id = 2, Name = "Laptop", Description = "dadg", Price = 1100 },
            new Item { Id = 3, Name = "Smartwatch", Description = "frytsf", Price = 10000 },
            new Item { Id = 4, Name = "Tablet", Description = "gkfdar", Price = 500 },

        };

            this.DataContext = this;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name.Text != "" && Description.Text != "" && Price.Text != "")
                {
                    ListOfItems.Add(new Item
                    {
                        Id = int.Parse(Id.Text),
                        Name = Name.Text,
                        Description = Description.Text,
                        Price = decimal.Parse(Price.Text)
                    });
                    myDataGrid2.Items.Refresh();
                    //Empty the textboxes after addinng 
                    Id.Text = "";
                    Name.Text = "";
                    Description.Text = "";
                    Price.Text = "";
                }
                else
                {
                    MessageBox.Show("Please fill in all fields correctly.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding Items: " + ex.Message);
            }

        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {          
                Item RemoveItem = myDataGrid2.SelectedItem as Item;
                if (RemoveItem != null)
                {
                    ListOfItems.Remove(RemoveItem);
                    myDataGrid2.Items.Refresh();
                    MessageBox.Show("Item removed successfully.");
                }
                else
                {
                    MessageBox.Show("Please select an Item to remove.");
                }
            
        }
        private void ClearItem_Click(object sender, RoutedEventArgs e)
        {


        }

    }
}