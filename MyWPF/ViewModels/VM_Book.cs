using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MyWPF.Commands;
using MyWPF.Converters;
using MyWPF.Models;

namespace MyWPF.ViewModels 
{
	public class VM_Book : INotifyPropertyChanged
	{
        public Book Book { set; get; }




        #region Секция свойств
        #region Информация о книге
        public string VTitle
		{
			get => Book.Title;
			set
			{
				Book.Title = value;
				OnPropertyChanged();
			}
		}

		public string VAuthor
		{
			get => Book.Author;
			set
			{
				Book.Author = value;
				OnPropertyChanged();
			}
		}

		public string VPublisherName
		{
			get => Book.Publish.Name;
			set
			{
				Book.Publish.Name = value;
				OnPropertyChanged();
			}
		}

		public string VPublisherAddress
		{
			get => Book.Publish.Address;
			set
			{
				Book.Publish.Address = value;
				OnPropertyChanged();
			}
		}

		public bool VStatus
        {
			get => Book.Status;
        }

		public int VCount
        {
			get => Book.Count;
            set
            {
				Book.Count = value;
				OnPropertyChanged();
            }
        }
        #endregion
        #region Для вывода в дерево
        
		private bool _isSelected = false;
		public bool VIsSelected
        {
			get => _isSelected;
            set
            {
				_isSelected = value;
				OnPropertyChanged();
            }
        }

		private bool _isExpanded = false;
		public bool VIsExpanded
		{
			get => _isExpanded;
			set
			{
				_isExpanded = value;
				OnPropertyChanged();
			}
		}
		#endregion
		#endregion


		#region Секция конструктора
		public VM_Book(Book book, bool isSelected=false, bool isExpanded=false)
		{
			this.Book = book;
			VIsSelected = isSelected;
			VIsExpanded = isExpanded;
		}
		#endregion

		// Возвращает список владельцев если они есть
		public ObservableCollection<VM_Client> VPeople
        {
			get 
			{
				if (Book.People.Count > 0) 
				{
					var res = new ObservableCollection<VM_Client>(Book.People.Select(c => new VM_Client(c.Client, c.Status)));
					return res;
				}
				else
				{
					return new ObservableCollection<VM_Client>() { new VM_Client(new Client("Предыдущих владельцев нет", "","",0), false) };
				}
			}
            
        }





        public VM_Book Clone()
        {
			return new VM_Book(new Book(Book.Title, Book.Author, new Publisher(Book.Publish.Name, Book.Publish.Address), Book.Count), false);
        }

		public void ChangeData(VM_Book newBook)
        {
			VTitle = newBook.VTitle;
			VAuthor = newBook.VAuthor;
			VPublisherName = newBook.VPublisherName;
			VPublisherAddress = newBook.VPublisherAddress;
			VCount = newBook.VCount;
        }

		public void Declare()
        {
			OnPropertyChanged(nameof(VPeople));
			OnPropertyChanged(nameof(VStatus));
        }

		/// <summary>
		/// Объявление свойства из INotifyPropertyChanged
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
