using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MyWPF.Commands;
using MyWPF.Converters;
using MyWPF.Models;

namespace MyWPF.ViewModels 
{
	public class BookViewModel : INotifyPropertyChanged
	{
        public Book Book { set; get; }




        #region Секция свойств
        #region Информация о книге
        public string Title
		{
			get => Book.Title;
			set
			{
				Book.Title = value;
				OnPropertyChanged("Title");
			}
		}

		public string Author
		{
			get => Book.Author;
			set
			{
				Book.Author = value;
				OnPropertyChanged("Author");
			}
		}

		public string PublisherName
		{
			get => Book.Publish.Name;
			set
			{
				Book.Publish.Name = value;
				OnPropertyChanged("PublisherName");
			}
		}

		public string PublisherAddress
		{
			get => Book.Publish.Address;
			set
			{
				Book.Publish.Address = value;
				OnPropertyChanged("PublisherAddress");
			}
		}

		public bool Status
        {
			get => Book.Status;
        }

		public int Count
        {
			get => Book.Count;
            set
            {
				Book.Count = value;
				OnPropertyChanged("Count");
            }
        }
        #endregion
        #region Для вывода в дерево
        
		private bool _isSelected = false;
		public bool IsSelected
        {
			get => _isSelected;
            set
            {
				_isSelected = value;
				OnPropertyChanged("IsSelected");
            }
        }

		private bool _isExpanded = false;
		public bool IsExpanded
		{
			get => _isExpanded;
			set
			{
				_isExpanded = value;
				OnPropertyChanged("IsExpanded");
			}
		}
		#endregion
		#endregion


		#region Секция конструктора
		public BookViewModel(Book book, bool isSelected=false, bool isExpanded=false)
		{
			this.Book = book;
			IsSelected = isSelected;
			IsExpanded = isExpanded;
		}
		#endregion

		// Возвращает список владельцев если они есть
		public ObservableCollection<ClientViewModel> People
        {
			get 
			{
				if (Book.People.Count > 0) 
				{
					var res = new ObservableCollection<ClientViewModel>(Book.People.Select(c => new ClientViewModel(c.Client, c.Status)));
					return res;
				}
				else
				{
					return new ObservableCollection<ClientViewModel>() { new ClientViewModel(new Client("Предыдущих владельцев нет", "",""), false) };
				}
			}
            
        }




		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public BookViewModel Clone()
        {
			return new BookViewModel(new Book(Book.Title, Book.Author, new Publisher(Book.Publish.Name, Book.Publish.Address), Book.Count), false);
        }

		public void ChangeData(BookViewModel newBook)
        {
			Title = newBook.Title;
			Author = newBook.Author;
			PublisherName = newBook.PublisherName;
			PublisherAddress = newBook.PublisherAddress;
			Count = newBook.Count;
        }

		public void Declare()
        {
			OnPropertyChanged("People");
			OnPropertyChanged("Status");
        }
    }
}
