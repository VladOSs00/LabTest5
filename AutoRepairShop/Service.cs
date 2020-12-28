using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRepairShop
{
    public class Service
    {
        public string count { get; set; }
        public string price { get; set; }
        public string name { get; set; }

        public Service(string _name, string _count, string _price)
        {
            count = _count;
            price = _price;
            name = _name;
        }
    }
}
