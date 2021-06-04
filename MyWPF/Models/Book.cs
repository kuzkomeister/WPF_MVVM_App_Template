using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MyWPF.Models;

namespace MyWPF
{
	class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public bool Status { get; set; }
		public Publisher Publish {set; get;}
		public ObservableCollection<Client> People { set; get; }

		public Book(string title, string author, Publisher publisher, List<string> people, bool status)
		{
			this.Status = status;
			this.Title = title;
			this.Author = author;
			this.Publish = publisher;
			this.People = people != null ? new ObservableCollection<Client>(people.Select(p => new Client(p))) : new ObservableCollection<Client>();
		}
	}
}
