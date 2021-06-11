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
	class MainWindowViewModel : INotifyPropertyChanged
	{
		

        #region Секция свойств
		// Список книг
        public ObservableCollection<BookViewModel> BooksList { set; get; }
		public ObservableCollection<ClientViewModel> ClientsList { set; get; }

		// Текущая выбранная книга
		private BookViewModel _selectedBookVM;
		public BookViewModel SelectedBookVM 
		{
			get => _selectedBookVM;
			set
			{
				if (value != null)
				{
					if (_selectedBookVM != null)
					{

						_selectedBookVM.IsExpanded = false;
						_selectedBookVM = value;
						_selectedBookVM.IsExpanded = true;

					}
					else
					{
						_selectedBookVM = value;
						_selectedBookVM.IsExpanded = true;
					}
					OnPropertyChanged("SelectedBookVM");
				}
			}
		}

		private ClientViewModel _selectedClientVM;
		public ClientViewModel SelectedClientVM
        {
			get => _selectedClientVM;
            set
            {
				_selectedClientVM = value;
				OnPropertyChanged("SelectedClientVM");
            }
        }

		// Строка для поиска книги по названию
		private string _searchTitle;
		public string SearchTitle
        {
			get => _searchTitle;
            set
            {
				_searchTitle = value;
				OnPropertyChanged("SearchTitle");
				SelectedBookVM = BooksList.FirstOrDefault(book => (book.Title.ToLower() + " " + book.Author.ToLower()).Contains(SearchTitle.ToLower()));
			}
			
        }

		// Строка для поиска клиента по фамилии
		private string _searchFamName;
		public string SearchFamName
        {
			get => _searchFamName;
            set
            {
				_searchFamName = value;
				OnPropertyChanged("SearchFamName");
				SelectedClientVM = ClientsList.FirstOrDefault(client => (client.Fam + " " + client.Name + " " + client.Otch + " " + client.ID).ToLower().Contains(SearchFamName.ToLower()));
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
			BookViewModel newBook = new BookViewModel(new Book("", 0), false);
            FormBook fBook = new FormBook(newBook);
            fBook.ShowDialog();

            if (newBook.Title.Trim() != "" && newBook.Count != 0)
            {
                BooksList.Add(newBook);
                SelectedBookVM = newBook;
            }
        }

		// Создание формы для изменения данных о книге
		private ICommand _editBookCommand;
		public ICommand EditBookCommand => _editBookCommand ?? (_editBookCommand = new RelayCommand(EditBook));

		private void EditBook(object parameter)
        {
			FormBook fBook = new FormBook(SelectedBookVM);
			fBook.ShowDialog();
        }


		// Создание нового клиента
		private ICommand _createNewClientCommand;
		public ICommand CreateNewClientCommand => _createNewClientCommand ?? (_createNewClientCommand = new RelayCommand(CreateNewClient));

		private void CreateNewClient(object parameter)
        {
			ClientViewModel newClient = new ClientViewModel(new Client("", "", ""), false);
			FormClient fClient = new FormClient(newClient);
			fClient.ShowDialog();

			if (newClient.Name.Trim() != "" && newClient.Fam.Trim() != "" && newClient.Otch.Trim() != "")
			{
				ClientsList.Add(newClient);
				SelectedClientVM = newClient;
			}
        }

		// Создание формы для изменения данных о клиенте
		private ICommand _editClientCommand;
		public ICommand EditClientCommand => _editClientCommand ?? (_editClientCommand = new RelayCommand(EditClient));

		private void EditClient(object parameter)
        {
			FormClient fClient = new FormClient(SelectedClientVM);
			fClient.ShowDialog();
		}


		private ICommand _getClientInfoCommand;
		public ICommand GetClientInfoCommand => _getClientInfoCommand ?? (_getClientInfoCommand = new RelayCommand(GetClientInfo));

		private void GetClientInfo(object parameter)
        {
			FormClientInfo fClientInfo = new FormClientInfo(SelectedClientVM);
			fClientInfo.Show();
        }
		#endregion

		#region Возврат и выдача книг
		// Комманда выдать книгу клиенту
		private ICommand _giveBookCommand;
		public ICommand GiveBookCommand => _giveBookCommand ?? (_giveBookCommand = new RelayCommand(GiveBook));

		private void GiveBook(object parameter)
		{
			if (SelectedBookVM.Status)
			{
				SelectedBookVM.Book.People.Add((SelectedClientVM.Client, true));
				SelectedClientVM.Client.Books.Add((SelectedBookVM.Book, true));
				SelectedBookVM.Count--;
				SelectedBookVM.Declare();
			}
		}

		// Команда получить книгу от клиента
		private ICommand _getBookCommand;
		public ICommand GetBookCommand => _getBookCommand ?? (_getBookCommand = new RelayCommand(GetBook));
		private void GetBook(object parameter)
		{
			int index1 = SelectedBookVM.Book.People.IndexOf((SelectedClientVM.Client, true));
			int index2 = SelectedClientVM.Client.Books.IndexOf((SelectedBookVM.Book, true));
			if (index1 != -1 && index2 != -1)
			{
				SelectedBookVM.Book.People[index1] = (SelectedClientVM.Client, false);
				SelectedClientVM.Client.Books[index2] = (SelectedBookVM.Book, false);
				SelectedBookVM.Count++;
				SelectedBookVM.Declare();
			}
		}
		#endregion
		#endregion

		#region Секция конструкторов
		public MainWindowViewModel(List<Book> books, List<Client> clients)
		{
			BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
			ClientsList = new ObservableCollection<ClientViewModel>(clients.Select(c => new ClientViewModel(c, false)));
		}

		public MainWindowViewModel()
        {
			BooksList = new ObservableCollection<BookViewModel>();
			ClientsList = new ObservableCollection<ClientViewModel>();
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
