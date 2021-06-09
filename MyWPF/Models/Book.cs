using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MyWPF.Models;

namespace MyWPF
{
	public class Book
	{
        #region Секция полей
        public string Title { get; set; }		// Название книги
		public string Author { get; set; }		// Автор книги
		public bool Status // Текущее нахождение книги (true - в библиотеке, false - на руках у клиента)
		{
			get => Count > 0;
		}        

		private int _count;                     // Количество книг в библиотеке
		public int Count 
		{
			get => _count;
            set => _count = value >= 0 ? value : _count;
		}			
		public Publisher Publish {set; get;}	// Объект издатель
		public ObservableCollection<(Client Client, bool Status)> People { set; get; }    // Список предыдущих с текущим владельцев
        #endregion

        #region Секция конструкторов
		
        public Book(string title, int count)
        {
			Title = title;
			Count = count;
			Author = "";
			Publish = new Publisher("");
			People = new ObservableCollection<(Client, bool)>();
        }

		public Book(string title, string author, int count) : this(title, count)
        {
			Author = author;
        }

		public Book(string title, string author, Publisher publish, int count) : this(title, author, count)
        {
			Publish = publish;
        }

		public Book(string title, string author, Publisher publish, List<(Client, bool)> people, int count) : this(title, author, publish, count)
		{
			People = people != null ? new ObservableCollection<(Client, bool)>(people) : new ObservableCollection<(Client, bool)>();
		}
		
		#endregion
	}
}
