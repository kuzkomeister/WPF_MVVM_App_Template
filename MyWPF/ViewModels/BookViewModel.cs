using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
            set
            {
				Book.Status = value;
				OnPropertyChanged("Status");
            }
        }

		private string _newClient = "";
		public string NewClientName
        {
			get => _newClient;
			set
            {
				_newClient = value;
				OnPropertyChanged("NewClientName");
            }
        }

		private int _newClientID = 0;
		public int NewClientID
        {
			get => _newClientID;
            set
            {
				_newClientID = value;
				OnPropertyChanged("NewClientID");
            }
        }

		private bool _enableBook = false;
		public bool EnableBook
        {
			get => _enableBook;
            set
            {
				_enableBook = value;
				OnPropertyChanged("EnableBook");
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

        #region Секция команд и их вызываемых методов

		// Смена статуса книги, т.е. ее либо взяли, либо вернули.
		// Выполняется в случае если введены: фамилия и ID
        private ICommand _changeStatusCommand;
		public ICommand ChangeStatusCommand => _changeStatusCommand ?? (_changeStatusCommand = new RelayCommand(ChangeStatus));

		private void ChangeStatus(object parameter)
		{
			if (Status)
			{
				if (NewClientName.Trim() != "" && NewClientID != 0)
				{
					Status = !Status;
					Book.People.Add(new Client(NewClientName, NewClientID));
					OnPropertyChanged("People");
				}
			}
            else
            {
				Status = !Status;
				OnPropertyChanged("People");
            }
			NewClientName = "";
			NewClientID = 0;
		}


		// Включение/выключение режима изменения информации о книге
		// Просто открывает доступ к TextBox, к которым привязаны данные о книге
		private ICommand _changeEnableCommand;
		public ICommand ChangeEnableCommand => _changeEnableCommand ?? (_changeEnableCommand = new RelayCommand(ChangeEnable));

		private void ChangeEnable(object parameter)
		{
			EnableBook = !EnableBook;
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
					var res = new ObservableCollection<ClientViewModel>(Book.People.Select(c => new ClientViewModel(c, false)));
					if (!Book.Status)
						res[res.Count-1].Status = true;
					return res;
				}
				else
				{
					return new ObservableCollection<ClientViewModel>() { new ClientViewModel(new Client("Предыдущих владельцев нет"), false) };
				}
			}
            
        }




		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
