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
