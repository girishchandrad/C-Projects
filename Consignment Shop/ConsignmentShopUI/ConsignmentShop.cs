
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
        BindingSource itemsBinding = new BindingSource();
        // add referece of consignment shop UI with ConsignmentShopLibrary, Library should not know about UI
        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items;
            itemsListBoxLabel.DataSource = itemsBinding;

            itemsListBoxLabel.DisplayMember = "Display";
            itemsListBoxLabel.ValueMember = "Display";
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
    }
}
