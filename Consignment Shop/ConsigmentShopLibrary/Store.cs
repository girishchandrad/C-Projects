using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsigmentShopLibrary
{
    class Store
    {
        public string Name { get; set; }
        public List<Vendor> Vendors { get; set; }
        // vendor is of list of type

        public List<Item> Items { get; set; }
    }
}
