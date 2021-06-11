using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MyWPF.Models;

namespace MyWPF.ViewModels
{
    public class VM_Client : INotifyPropertyChanged
    {
        


        public VM_Client(Client client, bool isSelected)
        {
            Client = client;    
            VIsSelected = isSelected;     // 
        }

        #region Секция свойств
        public Client Client { set; get; }  // Клиент

        public int VID
        {
            get => Client.ID;
        }
        public string VFirstName                   
        {
            get => Client.FirstName;
            set
            {
                Client.FirstName = value;
                OnPropertyChanged("VFirstName");
            }
        }
        public string VLastName                      // Фамилия
        {
            get => Client.LastName;
            set
            {
                Client.LastName = value;
                OnPropertyChanged("VLastName");
            }
        }
        public string VPatronymic                     // Отчество
        {
            get => Client.Patronymic;
            set
            {
                Client.Patronymic = value;
                OnPropertyChanged("VPatronymic");
            }
        }
        // 
        private bool _isSelected = false;
        public bool VIsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged("VIsSelected");
            }
        }

        private bool _isExpanded = false;
        public bool VIsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged("VIsExpanded");
            }
        }

        public ObservableCollection<VM_Book> VBooks
        {
            get => new ObservableCollection<VM_Book>(Client.Books.Select(b => new VM_Book(b.Book, b.Status)));
        }

        #endregion

        public VM_Client Clone()
        {
            return new VM_Client(new Client(Client.FirstName, Client.LastName, Client.Patronymic, Client.ID), false);
        }

        public void ChangeData(VM_Client newClient)
        {
            this.VFirstName = newClient.VFirstName;
            this.VLastName = newClient.VLastName;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
