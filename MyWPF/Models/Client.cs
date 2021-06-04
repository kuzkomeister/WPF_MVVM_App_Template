using System;
using System.Collections.Generic;
using System.Text;

namespace MyWPF.Models
{
    class Client
    {
        public string Name { set; get; }

        public Client(string name)
        {
            this.Name = name;
        }
    }
}
