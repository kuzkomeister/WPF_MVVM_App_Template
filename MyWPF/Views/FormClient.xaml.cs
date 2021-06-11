using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
