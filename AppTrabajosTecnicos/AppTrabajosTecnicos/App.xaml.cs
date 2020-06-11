using AppGestionTiendas.Servicios.Navigation;
using AppTrabajosTecnicos.Views;
using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTrabajosTecnicos
{
	public partial class App : Application
	{
        internal static NavigationService NavigationService;

        public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new CategoriaView());
		}

		protected override void OnStart()
		{
			CrossFirebasePushNotification.Current.Subscribe("general");
			CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
			{
				System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
			};
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
