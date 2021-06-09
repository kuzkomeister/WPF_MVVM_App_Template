using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MyWPF.Commands;

namespace MyWPF.ViewModels
{
    class fClientViewModel
    {
        public ClientViewModel CloneClientVM { set; get; }  // Копия для внесения изменений
        public ClientViewModel OrigClientVM { set; get; }     // Оригинал для итогового внесения изменений

        public Action CloseAction { set; get; }             // Закрыть окно

        // Сохранить изменения книги
        private ICommand _saveClientChanges;
        public ICommand SaveClientChanges => _saveClientChanges ?? (_saveClientChanges = new RelayCommand(SaveChanges));

        private void SaveChanges(object parameter)
        {
            OrigClientVM.ChangeData(CloneClientVM);
            CloseAction();
        }

        public fClientViewModel(ClientViewModel client)
        {
            OrigClientVM = client;
            CloneClientVM = client.Clone();
        }
    }
}
