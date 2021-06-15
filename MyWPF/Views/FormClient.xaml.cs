using System;
using System.Windows;
using MyWPF.ViewModels;

namespace MyWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для FormClient.xaml
    /// </summary>
    public partial class FormClient : Window
    {
        public FormClient(VM_Client client)
        {
            VMF_Client VM = new VMF_Client(client);
            DataContext = VM;
            if (VM.CloseAction == null)
                VM.CloseAction = new Action(this.Close);

            InitializeComponent();
        }
    }
}
