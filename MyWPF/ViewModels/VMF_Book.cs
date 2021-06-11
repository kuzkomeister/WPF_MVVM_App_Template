using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MyWPF.Commands;

namespace MyWPF.ViewModels
{
    class VMF_Book
    {

		          
		public VM_Book VCloneBook { set; get; }	// Копия для внесения изменений
		public VM_Book OrigBook { set; get; }   // Оригинал для итогового внесения изменений

		public Action CloseAction { set; get; }			// Закрыть окно


		// Сохранить изменения книги
		private ICommand _saveBookChanges;
		public ICommand SaveBookChanges => _saveBookChanges ?? (_saveBookChanges = new RelayCommand(SaveChanges));

		private void SaveChanges(object parameter)
		{
			OrigBook.ChangeData(VCloneBook);
			CloseAction();
		}

		public VMF_Book(VM_Book book)
        {
			OrigBook = book;
			VCloneBook = book.Clone();
        }



	}
}
