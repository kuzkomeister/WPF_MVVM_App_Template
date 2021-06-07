﻿using System;
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
			new Book("Рецепты печенек", null, new Publisher("Мир", "г. Москва"), 
					new List<Client>()
					{ 
						new Client("Иванов", 1), 
						new Client("Петров", 2) 
					}, false),
			new Book("CLR via C#", "Джеффри Рихтер", new Publisher("", "г. Москва"), 
					new List<Client>()
					{ 
						new Client("Иванов", 1), 
						new Client("Петров", 2), 
						new Client("Сидоров", 3) 
					}, false),
			new Book("Война и мир", "Л. Н. Толстой", new Publisher("Читай город", "г. Краснодар"), true),
			new Book("Война и война", "Н. Л. Худой", new Publisher("Неизведанное"), true)
			};

			MainWindowViewModel mVM = new MainWindowViewModel(books);
			DataContext = mVM;

			InitializeComponent();
		}

		
    }
}
