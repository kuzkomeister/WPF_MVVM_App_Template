using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MyWPF.Commands;

namespace MyWPF.ViewModels
{
    class fBookViewModel
    {

		          
		public BookViewModel CloneBookVM { set; get; }	// Копия для внесения изменений
		public BookViewModel OrigBookVM { set; get; }   // Оригинал для итогового внесения изменений

		public Action CloseAction { set; get; }			// Закрыть окно


		// Сохранить изменения книги
		private ICommand _saveBookChanges;
		public ICommand SaveBookChanges => _saveBookChanges ?? (_saveBookChanges = new RelayCommand(SaveChanges));

		private void SaveChanges(object parameter)
		{
			OrigBookVM.ChangeData(CloneBookVM);
			CloseAction();
		}

		public fBookViewModel(BookViewModel book)
        {
			OrigBookVM = book;
			CloneBookVM = book.Clone();
        }



	}
}
