using System;
using System.Collections.Generic;
using System.Text;

namespace MyWPF.Models
{
    class Client
    {
        #region Секция полей
        public string Name { set; get; }    // Фамилия

        private int _id;                    // Идентификатор
        public int ID
        {
            set => _id = value;
            get => _id;
        }

        #endregion

        #region Секция конструкторов
        public Client(string name)
        {
            Name = name;
            ID = -1;
        }

        public Client(string name, int id) : this(name)
        {
            ID = id;
        }
        
        #endregion
    }
}
