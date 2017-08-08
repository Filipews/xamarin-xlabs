using LabsSample.ViewModel;
using LabsSample.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace LabsSample.Infra
{
	public static class ViewResolver
	{
		public static void Init()
		{
			var navService = Resolver.Resolve<INavigationService>();
			ViewFactory.EnableCache = false;
			
			ViewFactory.Register<Main, MainViewModel>();
			ViewFactory.Register<Products, ProductsViewModel>();
		}

		public static Page Resolve<TViewModel>(Action<object, object> initialiser = null, params object[] args)
		{
			var ob = ViewFactory.CreatePage(typeof(TViewModel), initialiser, args);
			if (ob is Page) return (Page)ob;
			return null;
		}
	}
}
