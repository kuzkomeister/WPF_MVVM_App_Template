using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MyWPF.Models;

namespace MyWPF.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        


        public ClientViewModel(Client client, bool isSelected)
        {
            Client = client;    
            IsSelected = isSelected;     // 
        }

        #region Секция свойств
        public Client Client { set; get; }  // Клиент

        public int ID
        {
            get => Client.ID;
        }
        public string Name
        {
            get => Client.Name;
            set
            {
                Client.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Fam
        {
            get => Client.Fam;
            set
            {
                Client.Fam = value;
                OnPropertyChanged("Fam");
            }
        }
        public string Otch
        {
            get => Client.Otch;
            set
            {
                Client.Otch = value;
                OnPropertyChanged("Otch");
            }
        }
        // 
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

        private bool _isExpanded = false;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        public ObservableCollection<BookViewModel> Books
        {
            get => new ObservableCollection<BookViewModel>(Client.Books.Select(b => new BookViewModel(b.Book, b.Status)));
        }

        #endregion

        public ClientViewModel Clone()
        {
            return new ClientViewModel(new Client(Client.Name, Client.Fam, Client.Otch, Client.ID), false);
        }

        public void ChangeData(ClientViewModel newClient)
        {
            this.Name = newClient.Name;
            this.Fam = newClient.Fam;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
