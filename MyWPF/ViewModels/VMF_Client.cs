using System;
using System.Windows.Input;
using MyWPF.Commands;

namespace MyWPF.ViewModels
{
    class VMF_Client : VM_BASIC
    {
        public VM_Client VCloneClient { set; get; }  // Копия для внесения изменений
        public VM_Client OrigClient { set; get; }     // Оригинал для итогового внесения изменений

        public Action CloseAction { set; get; }             // Закрыть окно

        // Сохранить изменения книги
        public ICommand CmdSaveClient => new RelayCommand(_DoSaveClient, _AlwaysTrue);

        private void _DoSaveClient()
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
