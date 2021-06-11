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

        public string FirstName { set; get; }    // Имя
        public string LastName { set; get; }     // Фамилия
        public string Patronymic { set; get; }    // Отчество
        public int ID { set; get; }         // ID

        public ObservableCollection<(Book Book, bool Status)> Books { set; get; }   // Список книг
        #endregion

        #region Секция конструкторов
        public Client(string firstName, string  lastName, string patronymic)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            ID = CurFreeID++;
            Books = new ObservableCollection<(Book, bool)>();
        }

        public Client(string firstName, string lastName, string patronymic, int id) : this(firstName, lastName, patronymic) 
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            ID = id;
            Books = new ObservableCollection<(Book, bool)>();
        }
        #endregion
    }
}
