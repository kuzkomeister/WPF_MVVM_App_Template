using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyWPF.Models
{
    public class Client
    {
        #region Секция полей
        static int CurFreeID = 1;

        public string Name { set; get; }    // Имя
        public string Fam { set; get; }     // Фамилия
        public string Otch { set; get; }    // Отчество
        public int ID { set; get; }         // ID

        public ObservableCollection<(Book Book, bool Status)> Books { set; get; }   // Список книг
        #endregion

        #region Секция конструкторов
        public Client(string name, string  fam, string otch)
        {
            Name = name;
            Fam = fam;
            Otch = otch;
            ID = CurFreeID++;
            Books = new ObservableCollection<(Book, bool)>();
        }

        public Client(string name, string fam, string otch, List<(Book, bool)> books) : this(name, fam, otch)
        {
            Books = new ObservableCollection<(Book, bool)>(books);
        }

        public Client(string name, string fam, string otch, int id, List<(Book, bool)> books) : this(name, fam, otch, books)
        {
            ID = id;
        }

        public Client(string name, string fam, string otch, int id) : this(name, fam, otch, id, new List<(Book, bool)>()) { }
        #endregion
    }
}
