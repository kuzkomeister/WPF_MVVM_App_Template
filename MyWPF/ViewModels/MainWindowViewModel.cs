using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MyWPF.Commands;
using MyWPF.ViewModels;

namespace MyWPF
{
	class MainWindowViewModel 
	{
		public ObservableCollection<BookViewModel> BooksList { set; get; }

		#region Секция команд и их вызываемых методов
		private ICommand _createEmptyBook;
		public ICommand CreateEmptyBook => _createEmptyBook ?? (_createEmptyBook = new RelayCommand(AddEmptyBook));

		private void AddEmptyBook(object parameter)
		{
			BooksList.Add(new BookViewModel(new Book("", "", new Models.Publisher("",""), null, true)));
		}
        #endregion

        

        public MainWindowViewModel(List<Book> books)
		{
			BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
		}


	}
}
