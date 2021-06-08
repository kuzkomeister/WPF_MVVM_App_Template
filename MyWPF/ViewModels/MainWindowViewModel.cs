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

namespace MyWPF
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		

        #region Секция свойств
		// Список книг
        public ObservableCollection<BookViewModel> BooksList { set; get; }
		public ObservableCollection<ClientViewModel> ClientsList { set; get; }

		// Текущая выбранная книга
		private BookViewModel _selectedBookViewModel;
		public BookViewModel SelectedBookViewModel 
		{
			get => _selectedBookViewModel;
			set
			{
				if (value != null)
				{
					if (_selectedBookViewModel != null)
					{
						if (!CloneSelectedBookViewModel.IsEnable)
						{
							_selectedBookViewModel.IsSelected = false;
							_selectedBookViewModel = value;
							_selectedBookViewModel.IsSelected = true;
							CloneSelectedBookViewModel = (BookViewModel)_selectedBookViewModel.Clone();
						}
					}
					else
					{
						_selectedBookViewModel = value;
						_selectedBookViewModel.IsSelected = true;
						CloneSelectedBookViewModel = (BookViewModel)_selectedBookViewModel.Clone();
					}
					OnPropertyChanged("SelectedBookViewModel");
				}
			}
		}

		// Клон текущей выбранной книги (для внесения изменений)
		private BookViewModel _cloneSelectedBookViewModel;
		public BookViewModel CloneSelectedBookViewModel
        {
			get => _cloneSelectedBookViewModel;
            set
            {
				_cloneSelectedBookViewModel = value;
				OnPropertyChanged("CloneSelectedBookViewModel");
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
				SelectedBookViewModel = BooksList.FirstOrDefault(s => s.Title.ToLower().StartsWith(SearchTitle.ToLower()));
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
				SelectedBookViewModel.SelectedClientVM = ClientsList.FirstOrDefault(client => (client.Fam + " " + client.Name).ToLower().StartsWith(SearchFamName.ToLower()));
			}
        }
        #endregion

        #region Секция команд и их вызываемых методов
		// Создание новой пустой книги
        private ICommand _createEmptyBook;
		public ICommand CreateEmptyBook => _createEmptyBook ?? (_createEmptyBook = new RelayCommand(AddEmptyBook));

		private void AddEmptyBook(object parameter)
		{
			BooksList.Add(new BookViewModel(new Book("", 1)));
		}

		// Сохранить изменения книги
		private ICommand _saveBookChanges;
		public ICommand SaveBookChanges => _saveBookChanges ?? (_saveBookChanges = new RelayCommand(SaveChanges));

		private void SaveChanges(object parameter)
        {
			SelectedBookViewModel.ChangeData(CloneSelectedBookViewModel);
			CloneSelectedBookViewModel.IsEnable = false;
        }

		// Отменить изменения
		private ICommand _cancelBookChanges;
		public ICommand CancelBookChanges => _cancelBookChanges ?? (_cancelBookChanges = new RelayCommand(CancelChanges));

		private void CancelChanges(object parameter)
        {
			CloneSelectedBookViewModel.ChangeData(SelectedBookViewModel);
			CloneSelectedBookViewModel.IsEnable = false;
        }
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
