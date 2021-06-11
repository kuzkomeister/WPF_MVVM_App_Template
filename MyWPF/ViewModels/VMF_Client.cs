using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MyWPF.Commands;

namespace MyWPF.ViewModels
{
    class VMF_Client
    {
        public VM_Client VCloneClient { set; get; }  // Копия для внесения изменений
        public VM_Client OrigClient { set; get; }     // Оригинал для итогового внесения изменений

        public Action CloseAction { set; get; }             // Закрыть окно

        // Сохранить изменения книги
        private ICommand _saveClientChanges;
        public ICommand SaveClientChanges => _saveClientChanges ?? (_saveClientChanges = new RelayCommand(SaveChanges));

        private void SaveChanges(object parameter)
        {
            OrigClient.ChangeData(VCloneClient);
            CloseAction();
        }

        public VMF_Client(VM_Client client)
        {
            OrigClient = client;
            VCloneClient = client.Clone();
        }
    }
}
