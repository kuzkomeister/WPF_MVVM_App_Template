using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MyWPF.Models;

namespace MyWPF.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged
    {
        


        public ClientViewModel(Client client, bool status)
        {
            Client = client;    
            Status = status;     // 
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

        // Является ли текущим владельцем книги
        public bool Status { set; get; }

        #endregion





        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
