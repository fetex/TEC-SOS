using AppGestionTiendas.Servicios.Navigation;
using AppTrabajosTecnicos.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTrabajosTecnicos
{
	public partial class App : Application
	{
        #region Properties
        static NavigationService navigationService;
        #endregion Properties

        #region Getters & Setters
        public static NavigationService NavigationService
        {
            get
            {
                if (navigationService == null)
                {
                    navigationService = new NavigationService();
                }
                return navigationService;
            }
        }
        #endregion Getters & Setters

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
