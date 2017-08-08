using LabsSample.Infra;
using LabsSample.View;
using LabsSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;

namespace LabsSample
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			ViewResolver.Init();
			ResolverManagerBase.Init();
			MainPage = GetMainPage();
		}

		///
		/// Initializes the application.
		/// </summary>
		public static void Init()
		{
			var app = Resolver.Resolve<IXFormsApp>();
			if (app == null)
			{
				return;
			}

			app.Closing += (o, e) => Debug.WriteLine("Application Closing");
			app.Error += (o, e) => Debug.WriteLine("Application Error");
			app.Initialize += (o, e) => Debug.WriteLine("Application Initialized");
			app.Resumed += (o, e) => Debug.WriteLine("Application Resumed");
			app.Rotation += (o, e) => Debug.WriteLine("Application Rotated");
			app.Startup += (o, e) => Debug.WriteLine("Application Startup");
			app.Suspended += (o, e) => Debug.WriteLine("Application Suspended");
		}

		public Page GetMainPage()
		{
			return new NavigationPage(ViewResolver.Resolve<MainViewModel>());
		}
	}
}
