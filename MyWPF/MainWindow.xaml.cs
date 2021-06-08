using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyWPF.Converters;
using MyWPF.Models;
using MyWPF.ViewModels;

namespace MyWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	class FontWeightEqualConverter : ObjectsEqualConverter<System.Windows.FontWeight> { }
	public partial class MainWindow : Window
	{


		public MainWindow()
		{
			List<Book> books = new List<Book>()
			{
			new Book("Рецепты печенек", null, new Publisher("Мир", "г. Москва"), 1),
			new Book("CLR via C#", "Джеффри Рихтер", new Publisher("", "г. Москва"), 0),
			new Book("Война и мир", "Л. Н. Толстой", new Publisher("Читай город", "г. Краснодар"), 1),
			new Book("Война и война", "Н. Л. Худой", 1)
			};

			List<Client> clients = new List<Client>()
			{
				new Client("Иван", "Иванов", 1),
				new Client("Петр", "Петров", 2),
				new Client("Олег", "Олегов", 3),
				new Client("Василий", "Васильев", 4),
				new Client("Кирилл", "Кириллов", 5),
				new Client("Влад", "Владов", 6),
				new Client("Артем", "Артемов", 7),
				new Client("Никита", "Никитов", 8),
				new Client("Егор", "Егоров", 9),
				new Client("Артем", "Егоров", 10)
			};

			books[0].People.Add((clients[0], false));
			books[0].People.Add((clients[1], true));

			books[1].People.Add((clients[0], false));
			books[1].People.Add((clients[1], false));
			books[1].People.Add((clients[2], true));

			//===
			clients[0].Books.Add((books[0], false));
			clients[0].Books.Add((books[1], false));

			clients[1].Books.Add((books[0], true));
			clients[1].Books.Add((books[1], false));

			clients[2].Books.Add((books[1], true));

			MainWindowViewModel mVM = new MainWindowViewModel(books, clients);
			DataContext = mVM;

			InitializeComponent();
		}

    }
}
