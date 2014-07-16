using KanColleCreateTools.Models;
using Livet;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace KanColleCreateTools.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		public ResViewModel Fuel { get; private set; }
		public ResViewModel Ammunition { get; private set; }
		public ResViewModel Steel { get; private set; }
		public ResViewModel Bauxite { get; private set; }

		public MainWindowViewModel()
		{
			this.Fuel = new ResViewModel("燃料", 300, 10, 10);
			this.Ammunition = new ResViewModel("彈藥", 300, 10, 10);
			this.Steel = new ResViewModel("鋼材", 300, 10, 10);
			this.Bauxite = new ResViewModel("鋁土", 300, 10, 10);

			Observable.Interval(TimeSpan.FromSeconds(5))
				.Subscribe(_ => Debug.WriteLine(Cursor.Position.ToString()));
		}

		public void Start()
		{
			Process p = Process.GetProcessesByName("KanColleViewer").FirstOrDefault();
			if (p != null)
			{
				WindowHelper.RECT rect = new WindowHelper.RECT();
				WindowHelper.GetWindowRect(p.MainWindowHandle, out rect);
				MouseHelper.SaveMousePosition();
				MouseHelper.DoCreate(rect, this.Fuel.Offset, this.Ammunition.Offset, this.Steel.Offset, this.Bauxite.Offset);
				MouseHelper.RestoreMousePosition();
			}
		}
	}
}
