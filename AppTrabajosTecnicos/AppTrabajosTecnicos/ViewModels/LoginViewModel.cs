using AppGestionTiendas.Configuracion;
using AppGestionTiendas.Servicios.Navigation;
using AppGestionTiendas.ViewModels;
using AppTrabajosTecnicos.Models;
using AppTrabajosTecnicos.Models.ModelsAux;
using AppTrabajosTecnicos.Servicios.APIRest;
using AppTrabajosTecnicos.Validations.Base;
using AppTrabajosTecnicos.Validations.Rules;
using AppTrabajosTecnicos.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTrabajosTecnicos.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		//Atributos 

		#region Attributes

		public ValidatableObject<string> BusquedaEmail { get; set; }  //Campo de Busqueda
		public ValidatableObject<string> PasswordLogin { get; set; }

		private UsuarioModel usuario;

		public MessageViewPop PopUp { get; set; }
		#endregion Attributes

		#region Requests
		public ElegirRequest<UsuarioModel> IniciarSesion { get; set; }
		#endregion Requests

		#region Commands
		public ICommand IngresarCommand { get; set; }
		public ICommand CrearCuentaCommand { get; set; }
		#endregion Commands

		#region Getters/ Setters
		public UsuarioModel Usuario
		{
			get { return usuario; }
			set
			{
				usuario = value;
				OnPropertyChanged();
			}
		}
		#endregion Getters/ Setters

		#region Initializate

		public LoginViewModel()
		{
			PopUp = new MessageViewPop();
			Usuario = new UsuarioModel();
			InitializeRequest();
			InitializeCommands();
			InitializeFields();
		}

		public void InitializeRequest()
		{

			string urlIniciarSesion = Endpoints.URL_SERVIDOR + Endpoints.VERIFICAR_CUENTA;

			IniciarSesion = new ElegirRequest<UsuarioModel>();
			IniciarSesion.ElegirEstrategia("GET", urlIniciarSesion); ;
		}

		public void InitializeCommands()
		{
			IngresarCommand = new Command(async () => await Ingresar(), () => true);
			CrearCuentaCommand = new Command(async () => await CrearCuenta(), () => true);

		}
		public void InitializeFields()
		{
			BusquedaEmail = new ValidatableObject<string>();
			PasswordLogin = new ValidatableObject<string>();

			BusquedaEmail.Validations.Add(new RequiredRule<string> { ValidationMessage = "Debe ingresar Correo ELectronico" });
			PasswordLogin.Validations.Add(new RequiredRule<string> { ValidationMessage = "El nombre de usuario es obligatorio" });
		}
		#endregion Initializate

		#region Metodos

		public async Task Ingresar()
		{
			try
			{
				UsuarioModel usuario = new UsuarioModel()
				{
					Email = Usuario.Email,
					Password = Usuario.Password
				};

				ParametersRequest parametros = new ParametersRequest();
				parametros.Parametros.Add(usuario.Email.ToString());
				parametros.Parametros.Add(usuario.Password.ToString());
				APIResponse response = await IniciarSesion.EjecutarEstrategia(usuario, parametros);
				if (response.IsSuccess)
				{
					((MessageViewModel)PopUp.BindingContext).Message = "Inicio Sesion exitosamente";
					await PopupNavigation.Instance.PushAsync(PopUp);
				}
				else
				{
					((MessageViewModel)PopUp.BindingContext).Message = "Fallo al iniciar sesion";
					await PopupNavigation.Instance.PushAsync(PopUp);
				}
			}
			catch (Exception e)
			{

			}

		}


		private async Task CrearCuenta()
		{
			await NavigationService.PushPage(new CrearCuentaView());
		}
		#endregion Metodos
	}
}