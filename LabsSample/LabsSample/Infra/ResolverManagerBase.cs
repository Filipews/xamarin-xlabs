using LabsSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace LabsSample.Infra
{
	public class ResolverManagerBase
	{
		public static void Init()
		{
			if (Resolver.IsSet)
				return;

			var container = new SimpleContainer();

			RegisterBusiness(container);
			RegisterViewModels(container);

			Resolver.SetResolver(container.GetResolver());
		}

		protected static void RegisterBusiness(SimpleContainer container)
		{
			//MbaDatabase db = new MbaDatabase();
			//AppPropertiesService AppProperties = new AppPropertiesService();
			//IDataService Data = new DataService(db, AppProperties);

			//container.Register(new ApplicationResources());
			//container.Register(AppProperties);
			//container.Register<INavigationService>(new NavigationService());
			//container.Register<IAlertService>(new AlertService());
			//container.Register<IDatabase>(db);
			//container.Register<IDataService>(Data);
			//container.Register<IAuthenticationService>(new AuthenticationService(AppProperties, Data));
			//container.Register<IPermissionManager>(new PermissionManager(AppProperties));
		}

		protected static void RegisterViewModels(SimpleContainer container)
		{
			container.Register(r => new MainViewModel());
			container.Register(r => new ProductsViewModel());
		}
	}
}
