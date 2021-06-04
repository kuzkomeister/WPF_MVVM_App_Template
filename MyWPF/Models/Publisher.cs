using System;
using System.Collections.Generic;
using System.Text;

namespace MyWPF.Models
{
    class Publisher
    {
        public string Name { set; get; }
        public string Address { set; get; }

        public Publisher(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}
