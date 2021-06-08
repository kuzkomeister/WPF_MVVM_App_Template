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
	class BookViewModel : INotifyPropertyChanged
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
        #region Для внесения изменений и вывода в дерево
        private bool _isEnable = false;
		public bool IsEnable
        {
			get => _isEnable;
            set
            {
				_isEnable = value;
				OnPropertyChanged("IsEnable");
            }
        }

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
        #endregion

		public ClientViewModel SelectedClientVM { set; get; }
        #endregion

        #region Секция команд и их вызываемых методов

        #region Возврат и выдача книг
        // Комманда выдать книгу клиенту
        private ICommand _giveBookCommand;
		public ICommand GiveBookCommand => _giveBookCommand ?? (_giveBookCommand = new RelayCommand(GiveBook));

		private void GiveBook(object parameter)
		{
			if (SelectedClientVM != null && Status)
            {
				Book.People.Add((SelectedClientVM.Client, true));
				SelectedClientVM.Client.Books.Add((Book, true));
				Count--;
				OnPropertyChanged("Status");
				OnPropertyChanged("People");
			}
		}

		// Команда получить книгу от клиента
		private ICommand _getBookCommand;
		public ICommand GetBookCommand => _getBookCommand ?? (_getBookCommand = new RelayCommand(GetBook));
		private void GetBook(object parameter)
        {
			if (SelectedClientVM != null)
			{
				int index1 = Book.People.IndexOf((SelectedClientVM.Client, true));
				int index2 = SelectedClientVM.Client.Books.IndexOf((Book, true));
				if (index1 != -1 && index2 != -1)
                {
					Book.People[index1] = (SelectedClientVM.Client, false);
					SelectedClientVM.Client.Books[index2] = (Book, false);
					Count++;
					OnPropertyChanged("Status");
					OnPropertyChanged("People");
				}	
			}
		}
        #endregion

        // Включение/выключение режима изменения информации о книге
        // Просто открывает доступ к TextBox, к которым привязаны данные о книге
        private ICommand _editBookCommand;
		public ICommand EditBookCommand => _editBookCommand ?? (_editBookCommand = new RelayCommand(EditBook));

		private void EditBook(object parameter)
		{
			IsEnable = !IsEnable;
		}
		#endregion

		#region Секция конструктора
		public BookViewModel(Book book)
		{
			this.Book = book;
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
					return new ObservableCollection<ClientViewModel>() { new ClientViewModel(new Client("Предыдущих владельцев нет", ""), false) };
				}
			}
            
        }




		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public BookViewModel Clone()
        {
			return new BookViewModel(new Book(Book.Title, Book.Author, new Publisher(Book.Publish.Name, Book.Publish.Address), Book.Count));
        }

		public void ChangeData(BookViewModel newBook)
        {
			Title = newBook.Title;
			Author = newBook.Author;
			PublisherName = newBook.PublisherName;
			PublisherAddress = newBook.PublisherAddress;
        }
    }
}
