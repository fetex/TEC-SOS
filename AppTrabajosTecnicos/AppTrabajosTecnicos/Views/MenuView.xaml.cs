using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTrabajosTecnicos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : TabbedPage
	{
		public MenuView()
		{
			InitializeComponent();

			Inicializar();
		}

		private void Inicializar()
		{
			Children.Add(new TecnicosView());
			Children.Add(new ServiciosView());
			Children.Add(new UsuarioView());

		}
	}
}