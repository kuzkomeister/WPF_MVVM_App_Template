using System;
using System.Windows;
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
