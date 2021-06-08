using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyWPF.Models
{
    class Client
    {
        #region Секция полей
        public string Name { set; get; }    // Имя
        public string Fam { set; get; }     // Фамилия
        public int ID { set; get; }         // ID

        public ObservableCollection<(Book Book, bool Status)> Books { set; get; }   // Список книг
        #endregion

        #region Секция конструкторов
        public Client(string name, string  fam)
        {
            Name = name;
            Fam = fam;
            ID = -1;
            Books = new ObservableCollection<(Book, bool)>();
        }

        public Client(string name, string fam, List<(Book, bool)> books) : this(name, fam)
        {
            Books = new ObservableCollection<(Book, bool)>(books);
        }

        public Client(string name, string fam, int id, List<(Book, bool)> books) : this(name, fam, books)
        {
            ID = id;
        }

        public Client(string name, string fam, int id) : this(name, fam, id, new List<(Book, bool)>()) { }
        #endregion
    }
}
