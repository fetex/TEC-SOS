using AppGestionTiendas.Servicios.Navigation;
using AppTrabajosTecnicos.Views;
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
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
