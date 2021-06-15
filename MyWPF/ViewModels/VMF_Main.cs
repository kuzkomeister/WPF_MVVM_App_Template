using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MyWPF.Commands;
using MyWPF.Models;
using MyWPF.ViewModels;
using MyWPF.Views;

namespace MyWPF
{
    class VMF_Main : VM_BASIC
    {


        #region Секция свойств
        // Список книг
        public ObservableCollection<VM_Book> VBooksList { set; get; }
        public ObservableCollection<VM_Client> VClientsList { set; get; }

        // Текущая выбранная книга
        private VM_Book _selectedBook;
        public VM_Book VSelectedBook
        {
            get => _selectedBook;
            set
            {
                if (value != null)
                {
                    if (_selectedBook != null)
                    {

                        _selectedBook.VIsExpanded = false;
                        _selectedBook = value;
                        _selectedBook.VIsExpanded = true;

                    }
                    else
                    {
                        _selectedBook = value;
                        _selectedBook.VIsExpanded = true;
                    }
                    OnPropertyChanged();
                }
            }
        }

        private VM_Client _selectedClient;
        public VM_Client VSelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }

        // Строка для поиска книги по названию
        private string _searchTitleAuthor;
        public string VSearchTitleAuthor
        {
            get => _searchTitleAuthor;
            set
            {
                _searchTitleAuthor = value;
                OnPropertyChanged();
                VSelectedBook = VBooksList.FirstOrDefault(book => (book.VTitle.ToLower() + " " + book.VAuthor.ToLower()).Contains(VSearchTitleAuthor.ToLower()));
            }

        }

        // Строка для поиска клиента по фамилии
        private string _searchFullNameID;
        public string VSearchFullNameID
        {
            get => _searchFullNameID;
            set
            {
                _searchFullNameID = value;
                OnPropertyChanged();
                VSelectedClient = VClientsList.FirstOrDefault(client => (client.VLastName + " " + client.VFirstName + " " + client.VPatronymic + " " + client.VID).ToLower().Contains(VSearchFullNameID.ToLower()));
            }
        }

        #endregion

        #region Секция команд и их вызываемых методов
        #region Создание и изменение книги или клиента
        // Создание новой пустой книги
        public ICommand CmdCreateNewBook => new RelayCommand(_DoCreateNewBook, _AlwaysTrue);

        private void _DoCreateNewBook()
        {
            VM_Book newBook = new VM_Book(new Book("", 0), false);
            FormBook fBook = new FormBook(newBook);
            fBook.ShowDialog();

            if (newBook.VTitle.Trim() != "" && newBook.VCount != 0)
            {
                VBooksList.Add(newBook);
                VSelectedBook = newBook;
            }
        }

        // Создание формы для изменения данных о книге
        public ICommand CmdEditBook => new RelayCommand(_DoEditBook, _AlwaysTrue);

        private void _DoEditBook()
        {
            FormBook fBook = new FormBook(VSelectedBook);
            fBook.ShowDialog();
        }


        // Создание нового клиента
        public ICommand CmdCreateNewClient => new RelayCommand(_DoCreateNewClient, _AlwaysTrue);

        private void _DoCreateNewClient()
        {
            VM_Client newClient = new VM_Client(new Client("", "", ""), false);
            FormClient fClient = new FormClient(newClient);
            fClient.ShowDialog();
            if (newClient.VFirstName.Trim() != "" && newClient.VLastName.Trim() != "" && newClient.VPatronymic.Trim() != "")
            {
                VClientsList.Add(newClient);
                VSelectedClient = newClient;
            }
        }

        // Создание формы для изменения данных о клиенте
        public ICommand CmdEditClient => new RelayCommand(_DoEditClient, _AlwaysTrue);

        private void _DoEditClient()
        {
            FormClient fClient = new FormClient(VSelectedClient);
            fClient.ShowDialog();
        }


        public ICommand CmdGetClientInfo => new RelayCommand(_DoGetClientInfo, _AlwaysTrue);

        private void _DoGetClientInfo()
        {
            FormClientInfo fClientInfo = new FormClientInfo(VSelectedClient);
            fClientInfo.Show();
        }
        #endregion

        #region Возврат и выдача книг
        // Комманда выдать книгу клиенту
        public ICommand CmdGiveBook => new RelayCommand(_DoGiveBook, _AlwaysTrue);

        private void _DoGiveBook()
        {
            if (VSelectedBook.VStatus)
            {
                VSelectedBook.Book.People.Add((VSelectedClient.Client, true));
                VSelectedClient.Client.Books.Add((VSelectedBook.Book, true));
                VSelectedBook.VCount--;
                VSelectedBook.Declare();
            }
        }

        // Команда получить книгу от клиента
        public ICommand CmdGetBook => new RelayCommand(_DoGetBook, _AlwaysTrue);
        private void _DoGetBook()
        {
            int index1 = VSelectedBook.Book.People.IndexOf((VSelectedClient.Client, true));
            int index2 = VSelectedClient.Client.Books.IndexOf((VSelectedBook.Book, true));
            if (index1 != -1 && index2 != -1)
            {
                VSelectedBook.Book.People[index1] = (VSelectedClient.Client, false);
                VSelectedClient.Client.Books[index2] = (VSelectedBook.Book, false);
                VSelectedBook.VCount++;
                VSelectedBook.Declare();
            }
        }
        #endregion
        #endregion

        #region Секция конструкторов
        public VMF_Main(List<Book> books, List<Client> clients)
        {
            VBooksList = new ObservableCollection<VM_Book>(books.Select(b => new VM_Book(b)));
            VClientsList = new ObservableCollection<VM_Client>(clients.Select(c => new VM_Client(c, false)));
            VSearchTitleAuthor = "";
            VSearchFullNameID = "";
        }

        public VMF_Main()
        {
            VBooksList = new ObservableCollection<VM_Book>();
            VClientsList = new ObservableCollection<VM_Client>();
            VSearchTitleAuthor = "";
            VSearchFullNameID = "";
        }

        #endregion



        /*
		 * 
		 *  
		 protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		 * 
		 * 
		 */





    }
}
