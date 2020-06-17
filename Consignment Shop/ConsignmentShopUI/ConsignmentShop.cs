
using ConsigmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();


        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorBinding = new BindingSource();
        // add referece of consignment shop UI with ConsignmentShopLibrary, Library should not know about UI
        private decimal storeProfit = 0;
        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items.Where(x=>x.Sold == false).ToList();
            itemsListBoxLabel.DataSource = itemsBinding;

            itemsListBoxLabel.DisplayMember = "Display";
            itemsListBoxLabel.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            ShoppingListBox.DataSource = cartBinding;

            ShoppingListBox.DisplayMember = "Display";
            ShoppingListBox.ValueMember = "Display";

            vendorBinding.DataSource = store.Vendors;
            vendorListBox.DataSource = vendorBinding;

            vendorListBox.DisplayMember = "Display";
            vendorListBox.ValueMember = "Display";

        }

        private void SetupData()
        {
            //Vendor demoVendor = new Vendor();
            //demoVendor.FirstName = "Bill";
            //demoVendor.LastName = "Smith";
            //demoVendor.Commission = .5;
            //store.Vendors.Add(demoVendor);

            store.Vendors.Add(new Vendor { FirstName = "Bill", LastName = "Smith" });
            store.Vendors.Add(new Vendor { FirstName = "Sue", LastName = "Johns" });
            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about Whale",
                Price = 4.50M,
                Owner = store.Vendors[0]
            });
            store.Items.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "A book about revolution",
                Price = 3.80M,
                Owner = store.Vendors[1]
            });
            store.Items.Add(new Item
            {
                Title = "Harry Potter Book1",
                Description = "A book about boy",
                Price = 5.20M,
                Owner = store.Vendors[0]
            });
            store.Items.Add(new Item
            {
                Title = "jane Eyre",
                Description = "A book about girl",
                Price = 1.50M,
                Owner = store.Vendors[0]
            });

            store.Name = "Seconds are better.";

        }

        //never delete this code before deleting solution explorer code in solution explorer UI
        private void PurchaseItem_Click(object sender, EventArgs e)
        {
            //Figure out what is selected from items list
            //copy that item to shopping cart
            // do we remove item from items list - no
            Item selectedItem = (Item)itemsListBoxLabel.SelectedItem;
            shoppingCartData.Add(selectedItem);
            cartBinding.ResetBindings(false);


        }

        private void MakePurchase_Click(object sender, EventArgs e)
        {
            //Mark each item as sold
            //clear the cart

            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;

                item.Owner.paymentDue += item.Price * (decimal)item.Owner.Commission;
                storeProfit += (1 - (decimal)item.Owner.Commission) * item.Price;

            }
            shoppingCartData.Clear();
            storeProfitValue.Text = string.Format("${0}",storeProfit);

            cartBinding.ResetBindings(false);
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            itemsBinding.ResetBindings(false);
            vendorBinding.ResetBindings(false);
            
        }
    }
}
