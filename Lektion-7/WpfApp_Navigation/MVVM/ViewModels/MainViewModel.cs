using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_Navigation.MVVM.Cores;

namespace WpfApp_Navigation.MVVM.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			ProductViewModel = new ProductViewModel();
			CustomerViewModel= new CustomerViewModel();
			ProductCommand = new RelayCommand(x => { CurrentView = ProductViewModel; });
			CustomerCommand = new RelayCommand(x => { CurrentView = CustomerViewModel; });

			CurrentView = ProductViewModel;
		}


		private object _currentView;
		public object CurrentView
		{
			get { return _currentView; }
			set
			{
				_currentView = value;
				OnPropertyChanged();
			}
		}

		public ProductViewModel ProductViewModel { get; set; }
		public RelayCommand ProductCommand { get; set; }
		public CustomerViewModel CustomerViewModel {get;set;}
		public RelayCommand CustomerCommand { get; set; }

	}
}
