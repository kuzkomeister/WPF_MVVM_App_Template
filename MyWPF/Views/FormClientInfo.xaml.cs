using System.Windows;
using MyWPF.ViewModels;

namespace MyWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для FormClientInfo.xaml
    /// </summary>
    public partial class FormClientInfo : Window
    {
        public FormClientInfo(VM_Client client)
        {
            DataContext = client;
            InitializeComponent();
        }
    }
}
