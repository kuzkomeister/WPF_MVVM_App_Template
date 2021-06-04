using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MyWPF.ViewModels;

namespace MyWPF
{
	class MainWindowViewModel
	{
		public ObservableCollection<BookViewModel> BooksList { set; get; }

		public MainWindowViewModel(List<Book> books)
		{
			BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
		}
	}
}
