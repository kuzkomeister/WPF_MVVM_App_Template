using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using MyWPF.Commands;
using MyWPF.ViewModels;
using System.Windows.Controls;
using MyWPF.Models;
using MyWPF.Views;

namespace MyWPF
{
	class VMF_Main : INotifyPropertyChanged
	{
		

        #region Секция свойств
		// Список книг
        public ObservableCollection<VM_Book> VBooksList { set; get; }
		public ObservableCollection<VM_Client> VClientsList { set; get; }

		// Текущая выбранная книга
		private VM_Book _selectedBook;
		public VM_Book VSelectedBook 
		{
			get => _selectedBook;
			set
			{
				if (value != null)
				{
					if (_selectedBook != null)
					{

						_selectedBook.VIsExpanded = false;
						_selectedBook = value;
						_selectedBook.VIsExpanded = true;

					}
					else
					{
						_selectedBook = value;
						_selectedBook.VIsExpanded = true;
					}
					OnPropertyChanged("VSelectedBook");
				}
			}
		}

		private VM_Client _selectedClient;
		public VM_Client VSelectedClient
        {
			get => _selectedClient;
            set
            {
				_selectedClient = value;
				OnPropertyChanged("VSelectedClient");
            }
        }

		// Строка для поиска книги по названию
		private string _searchTitleAuthor;
		public string VSearchTitleAuthor
        {
			get => _searchTitleAuthor;
            set
            {
				_searchTitleAuthor = value;
				OnPropertyChanged("VSearchTitleAuthor");
				VSelectedBook = VBooksList.FirstOrDefault(book => (book.VTitle.ToLower() + " " + book.VAuthor.ToLower()).Contains(VSearchTitleAuthor.ToLower()));
			}
			
        }

		// Строка для поиска клиента по фамилии
		private string _searchFullNameID;
		public string VSearchFullNameID
        {
			get => _searchFullNameID;
            set
            {
				_searchFullNameID = value;
				OnPropertyChanged("VSearchFullNameID");
				VSelectedClient = VClientsList.FirstOrDefault(client => (client.VLastName + " " + client.VFirstName + " " + client.VPatronymic + " " + client.VID).ToLower().Contains(VSearchFullNameID.ToLower()));
			}
        }

        #endregion

        #region Секция команд и их вызываемых методов
        #region Создание и изменение книги или клиента
        // Создание новой пустой книги
        private ICommand _createNewBookCommand;
		public ICommand CreateNewBookCommand => _createNewBookCommand ?? (_createNewBookCommand = new RelayCommand(CreateNewBook));

		private void CreateNewBook(object parameter)
		{
			VM_Book newBook = new VM_Book(new Book("", 0), false);
            FormBook fBook = new FormBook(newBook);
            fBook.ShowDialog();

            if (newBook.VTitle.Trim() != "" && newBook.VCount != 0)
            {
                VBooksList.Add(newBook);
                VSelectedBook = newBook;
            }
        }

		// Создание формы для изменения данных о книге
		private ICommand _editBookCommand;
		public ICommand EditBookCommand => _editBookCommand ?? (_editBookCommand = new RelayCommand(EditBook));

		private void EditBook(object parameter)
        {
			FormBook fBook = new FormBook(VSelectedBook);
			fBook.ShowDialog();
        }


		// Создание нового клиента
		private ICommand _createNewClientCommand;
		public ICommand CreateNewClientCommand => _createNewClientCommand ?? (_createNewClientCommand = new RelayCommand(CreateNewClient));

		private void CreateNewClient(object parameter)
        {
			VM_Client newClient = new VM_Client(new Client("", "", ""), false);
			FormClient fClient = new FormClient(newClient);
			fClient.ShowDialog();

			if (newClient.VFirstName.Trim() != "" && newClient.VLastName.Trim() != "" && newClient.VPatronymic.Trim() != "")
			{
				VClientsList.Add(newClient);
				VSelectedClient = newClient;
			}
        }

		// Создание формы для изменения данных о клиенте
		private ICommand _editClientCommand;
		public ICommand EditClientCommand => _editClientCommand ?? (_editClientCommand = new RelayCommand(EditClient));

		private void EditClient(object parameter)
        {
			FormClient fClient = new FormClient(VSelectedClient);
			fClient.ShowDialog();
		}


		private ICommand _getClientInfoCommand;
		public ICommand GetClientInfoCommand => _getClientInfoCommand ?? (_getClientInfoCommand = new RelayCommand(GetClientInfo));

		private void GetClientInfo(object parameter)
        {
			FormClientInfo fClientInfo = new FormClientInfo(VSelectedClient);
			fClientInfo.Show();
        }
		#endregion

		#region Возврат и выдача книг
		// Комманда выдать книгу клиенту
		private ICommand _giveBookCommand;
		public ICommand GiveBookCommand => _giveBookCommand ?? (_giveBookCommand = new RelayCommand(GiveBook));

		private void GiveBook(object parameter)
		{
			if (VSelectedBook.VStatus)
			{
				VSelectedBook.Book.People.Add((VSelectedClient.Client, true));
				VSelectedClient.Client.Books.Add((VSelectedBook.Book, true));
				VSelectedBook.VCount--;
				VSelectedBook.Declare();
			}
		}

		// Команда получить книгу от клиента
		private ICommand _getBookCommand;
		public ICommand GetBookCommand => _getBookCommand ?? (_getBookCommand = new RelayCommand(GetBook));
		private void GetBook(object parameter)
		{
			int index1 = VSelectedBook.Book.People.IndexOf((VSelectedClient.Client, true));
			int index2 = VSelectedClient.Client.Books.IndexOf((VSelectedBook.Book, true));
			if (index1 != -1 && index2 != -1)
			{
				VSelectedBook.Book.People[index1] = (VSelectedClient.Client, false);
				VSelectedClient.Client.Books[index2] = (VSelectedBook.Book, false);
				VSelectedBook.VCount++;
				VSelectedBook.Declare();
			}
		}
		#endregion
		#endregion

		#region Секция конструкторов
		public VMF_Main(List<Book> books, List<Client> clients)
		{
			VBooksList = new ObservableCollection<VM_Book>(books.Select(b => new VM_Book(b)));
			VClientsList = new ObservableCollection<VM_Client>(clients.Select(c => new VM_Client(c, false)));
			VSearchTitleAuthor = "";
			VSearchFullNameID = "";
		}

		public VMF_Main()
        {
			VBooksList = new ObservableCollection<VM_Book>();
			VClientsList = new ObservableCollection<VM_Client>();
		}

        #endregion



        /*
		 * 
		 *  
		 protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		 * 
		 * 
		 */


        public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
