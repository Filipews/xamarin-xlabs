using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Serialization;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Geolocation;
using Xamarin.Forms;
using XLabs.Forms.Services;

namespace LabsSample.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate
	{
		// class-level declarations
        UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			SetIoc();

			Forms.Init();

			LoadApplication(new LabsSample.App());

			return base.FinishedLaunching(app, options);
		}

		/// <summary>
		/// Sets the IoC.
		/// </summary>
		private void SetIoc()
		{
			var container = new SimpleContainer();

			var app = new XFormsAppiOS();
			app.Init(this);

			var documents = app.AppDataDirectory;

			container.Register<IDevice>(t => AppleDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IXFormsApp>(app)
				.Register<INetwork>(t => t.Resolve<IDevice>().Network)
				.Register<IGeolocator, Geolocator>()
				.Register<INavigationService, NavigationService>()
				.Register<IDependencyContainer>(t => container);

			Resolver.SetResolver(container.GetResolver());
		}
	}
}
