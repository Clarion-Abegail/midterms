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

namespace Asynchronous_Activity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Item> Items { get; }
        public List<Item> Itemss { get; } = new List<Item>();

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
            //Initialize data

            Items = new List<Item>
            {
                new Item { Id = 1, Name = "Wireless Mouse", Description = "Ergonomic wireless mouse with USB receiver", Price = 599},
                new Item { Id = 2, Name = "Laptop", Description = "Portable computer with a 15.6-inch display, suitable for work, school, and entertainment.", Price = 35000},
                new Item { Id = 3, Name = "Desk Lamp", Description = "LED desk lamp with adjustable brightness", Price = 799},
                new Item { Id = 4, Name = "Tablet", Description = "Lightweight touchscreen device ideal for reading, browsing, note-taking, and multimedia use.", Price = 15000 },
            };

            this.DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text != "" && txtDescription.Text != "" && txtPrice.Text != "")
                {
                    Items.Add(new Item
                    {
                        Id = int.Parse(txtId.Text),
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        Price = decimal.Parse(txtPrice.Text)
                    });

                    myGridData.Items.Refresh();

                    txtId.Text = "";
                    txtName.Text = "";
                    txtDescription.Text = "";
                    txtPrice.Text = "";


                }
            }

            catch
            {
                MessageBox.Show("Please fill in all fields correctly");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (myGridData2.SelectedItem != null)
            {
                MessageBox.Show("Use 'Remove from Cart button' to remove items from the shopping cart.");
                return;
            }

            if (myGridData.SelectedItem is Item selectedItem)
            {
                Items.Remove(selectedItem);
                myGridData.Items.Refresh();
                MessageBox.Show("Item removed successfully");
            }
            else
            {
                MessageBox.Show("Please select an item from Available Items.");
            }
        }

        private void btnAddtoCart_Click(object sender, RoutedEventArgs e)
        {
            if (myGridData.SelectedItem is Item selectedItem)
            {
                Item newItem = new Item
                {
                    Id = selectedItem.Id,
                    Name = selectedItem.Name,
                    Description = selectedItem.Description,
                    Price = selectedItem.Price
                };
                Itemss.Add(newItem);
                myGridData.Items.Refresh();
                myGridData2.Items.Refresh();
                MessageBox.Show("Item added to cart successfully");
            }
            else
            {
                MessageBox.Show("Please select an Item to add to cart");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (myGridData.SelectedItem is Item selectedItem)
            {
                txtId.Clear();
                txtName.Clear();
                txtDescription.Clear();
                txtPrice.Clear();

                myGridData.SelectedItem = null;
                myGridData2.SelectedItem = null;
            }
        }

        private void btnRemovefromCart_Click(object sender, RoutedEventArgs e)
        {
            if (myGridData2.SelectedItem is Item selectedItem)
            {
                Itemss.Remove(selectedItem);
                myGridData2.Items.Refresh();
                MessageBox.Show("Item removed from cart successfully");
            }
            else
            {
                MessageBox.Show("Please select an item to remove");
            }
        }
    }
}
