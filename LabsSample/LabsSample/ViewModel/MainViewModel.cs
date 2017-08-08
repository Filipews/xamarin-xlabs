using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LabsSample.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		private ICommand _ShowProductsCommand;

		public ICommand ShowProductsCommand { get => _ShowProductsCommand; set => SetProperty(ref _ShowProductsCommand, value); }

		public MainViewModel()
		{
			ShowProductsCommand = new Command(ShowProducts);
		}

		private void ShowProducts()
		{
			Navigation.PushAsync<ProductsViewModel>(true);
			//NavigationService.NavigateTo<ProductsViewModel>();
		}
	}
}
