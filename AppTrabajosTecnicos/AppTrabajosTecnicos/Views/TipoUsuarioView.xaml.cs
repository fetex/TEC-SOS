using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace AppTrabajosTecnicos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoUsuarioView : ContentPage
	{
		string rolText;
		string[] descripciones = {"Los usuarios tipo cliente, pueden realizar solicitudes a los tecnicos registrados. Ademas poseen una direccion en donde el tecnico va a realizar el servicio", "Los usuarios tipo tecnico, pueden recibir solicitudes a los clientes registrados. Ademas poseen una una categoria y una puntuacion" };
		string[] rol = {"cliente", "tecnico"};
		public TipoUsuarioView()
		{
			rolText = null;
			InitializeComponent();
			Inicializar();
		}

		private void Inicializar()
		{
			bindiableRadioGroupRol.ItemsSource = rol;
			bindiableRadioGroupRol.CheckedChanged += BindableRadioGroupRol_chekedChange;
		}

		private void BindableRadioGroupRol_chekedChange(object sender, int e)
		{
			var radio = sender as CustomRadioButton;

			if (radio == null || radio.Id == -1)
			{ return; }
			if (radio.Id == 1)
				rolText = descripciones[0];
			else
				rolText = descripciones[1];
				
		}
	}
}