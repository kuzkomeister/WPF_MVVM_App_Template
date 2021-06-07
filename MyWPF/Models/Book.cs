using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MyWPF.Models;

namespace MyWPF
{
	class Book
	{
        #region Секция полей
        public string Title { get; set; }		// Название книги
		public string Author { get; set; }		// Автор книги
		public bool Status { get; set; }		// Текущее нахождение книги (true - в библиотеке, false - на руках у клиента)
		public Publisher Publish {set; get;}	// Объект издатель
		public ObservableCollection<Client> People { set; get; }    // Список предыдущих с текущим владельцев
        #endregion

        #region Секция конструкторов
        public Book(string title, bool status)
        {
			Title = title;
			Status = status;

			Author = "";
			Publish = new Publisher("");
			People = new ObservableCollection<Client>();
        }

		public Book(string title, string author, bool status) : this(title, status)
        {
			Author = author;
        }

		public Book(string title, string author, Publisher publish, bool status) : this(title, author, status)
        {
			Publish = publish;
        }

		public Book(string title, string author, Publisher publish, List<Client> people, bool status) : this(title, author, publish, status)
		{
			People = people != null ? new ObservableCollection<Client>(people) : new ObservableCollection<Client>();
		}
        #endregion
    }
}
