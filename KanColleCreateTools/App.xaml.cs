using KanColleCreateTools.ViewModels;
using KanColleCreateTools.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KanColleCreateTools
{
	/// <summary>
	/// App.xaml 的互動邏輯
	/// </summary>
	public partial class App : Application
	{
		public static MainWindowViewModel ViewModelRoot { get; private set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ViewModelRoot = new MainWindowViewModel();
			this.MainWindow = new MainWindow { DataContext = ViewModelRoot };
			this.MainWindow.Show();
		}
	}
}
