﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using MyWPF.Commands;
using MyWPF.Converters;
using MyWPF.Models;

namespace MyWPF.ViewModels 
{
	class BookViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


		public Book Book { set; get; }

		public BookViewModel(Book book)
		{
			this.Book = book;
		}


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
        #endregion

        #region Секция команд и их вызываемых методов
        private ICommand _changeStatusCommand;
		public ICommand ChangeStatusCommand => _changeStatusCommand ?? (_changeStatusCommand = new RelayCommand(ChangeStatus));

		private void ChangeStatus(object parameter)
		{
			if (Status)
			{
				if (NewClientName.Trim() != "")
				{
					Status = !Status;
					Book.People.Add(new Client(NewClientName));
					OnPropertyChanged("People");
				}
			}
            else
            {
				Status = !Status;
            }
			NewClientName = "";
		}

		private ICommand _changeEnableCommand;
		public ICommand ChangeEnableCommand => _changeEnableCommand ?? (_changeEnableCommand = new RelayCommand(ChangeEnable));

		private void ChangeEnable(object parameter)
		{
			EnableBook = !EnableBook;
		}
		#endregion



		public Client ClientWithBook
        {
			get => Book.People.Count > 0 && !Book.Status ? Book.People[People.Count] : null;
        }



		public ObservableCollection<Client> People
        {
			get 
			{
				if (Book.People.Count > 0) 
				{
					return Book.People;
				}
				else
				{
					return new ObservableCollection<Client>() { new Client("Предыдущих владельцев нет") };
				}
			}
            set
            {
				Book.People = value;
				OnPropertyChanged("People");
            }
        }

	}
}
