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
    /// Логика взаимодействия для fBook.xaml
    /// </summary>
    public partial class FormBook : Window
    {
        public FormBook(VM_Book book)
        {
            VMF_Book VM = new VMF_Book(book);
            DataContext = VM;
            if (VM.CloseAction == null)
                VM.CloseAction = new Action(this.Close);
            InitializeComponent();
        }
    }
}
