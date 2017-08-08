using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Forms;
using XLabs.Platform.Device;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Geolocation;
using XLabs.Forms.Services;

namespace LabsSample.Droid
{
	[Activity(Label = "LabsSample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
	{
		/// <summary>
		/// Indicated if the application has been initialized
		/// </summary>
		private static bool _initialized;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			if (!_initialized)
			{
				this.SetIoc();
			}

			Xamarin.Forms.Forms.Init(this, bundle);
			App.Init();

			LoadApplication(new App());
		}

		/// <summary>
		/// Sets the IoC.
		/// </summary>
		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppDroid();
			app.Init(this);

			resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IDependencyContainer>(resolverContainer)
				.Register<INetwork>(t => t.Resolve<IDevice>().Network)
				.Register<IGeolocator, Geolocator>()
				.Register<INavigationService, NavigationService>()
				.Register<IXFormsApp>(app);

			Resolver.SetResolver(resolverContainer.GetResolver());

			_initialized = true;
		}
	}
}

