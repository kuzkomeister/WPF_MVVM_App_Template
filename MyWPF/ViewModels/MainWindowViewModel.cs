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

namespace MyWPF
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		

        #region Секция свойств
		// Список книг
        public ObservableCollection<BookViewModel> BooksList { set; get; }

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
						_selectedBookViewModel.IsSelected = false;
						_selectedBookViewModel = value;
						_selectedBookViewModel.IsSelected = true;
					}
					else
					{
						_selectedBookViewModel = value;
						_selectedBookViewModel.IsSelected = true;
					}
					OnPropertyChanged("SelectedBookViewModel");
				}
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

        #endregion

        #region Секция команд и их вызываемых методов
		// Создание новой пустой книги
        private ICommand _createEmptyBook;
		public ICommand CreateEmptyBook => _createEmptyBook ?? (_createEmptyBook = new RelayCommand(AddEmptyBook));

		private void AddEmptyBook(object parameter)
		{
			BooksList.Add(new BookViewModel(new Book("", true)));
		}
        #endregion

        #region Секция конструкторов
        public MainWindowViewModel(List<Book> books)
		{
			BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
		}

		public MainWindowViewModel()
        {
			BooksList = new ObservableCollection<BookViewModel>();
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
