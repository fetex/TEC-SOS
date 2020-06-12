using AppGestionTiendas.Configuracion;
using AppGestionTiendas.ViewModels;
using AppTrabajosTecnicos.Models;
using AppTrabajosTecnicos.Models.ModelsAux;
using AppTrabajosTecnicos.Servicios.APIRest;
using AppTrabajosTecnicos.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTrabajosTecnicos.ViewModels
{
    public class CrearCuentaViewMode : ViewModelBase
    {
        private UsuarioModel usuario;

        public MessageViewPop PopUp { get; set; }

        public ElegirRequest<UsuarioModel> CrearUsuario { get; set; }

        public ICommand CrearCommand { get; set; }

        public UsuarioModel Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                OnPropertyChanged();
            }
        }
        public CrearCuentaViewMode()
        {
            Usuario = new UsuarioModel();

            string urlCuenta = Endpoints.URL_SERVIDOR + Endpoints.CREAR_USUARIO;

            CrearUsuario = new ElegirRequest<UsuarioModel>();
            CrearUsuario.ElegirEstrategia("POST", urlCuenta);

            CrearCommand = new Command(async () => await NuevaCuenta(), () => true);
        }

        public async Task NuevaCuenta()
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel()
                {
                    usuario_id = Usuario.usuario_id,
                    Username = Usuario.Username,
                    Email = Usuario.Email,
                    Password = Usuario.Password
                };
                ParametersRequest parametros = new ParametersRequest();
                parametros.Parametros.Add(usuario.Email.ToString());
                parametros.Parametros.Add(usuario.Password.ToString());
                parametros.Parametros.Add(usuario.Username.ToString());
                APIResponse response = await CrearUsuario.EjecutarEstrategia(usuario, parametros);
                if (response.IsSuccess)
                {
                    await NavigationService.PopPage();
                }
                else
                {
                    ((MessageViewModel)PopUp.BindingContext).Message = "Error Crear la Cuenta";
                    await PopupNavigation.Instance.PushAsync(PopUp);
                }



            }
            catch (Exception e)
            {

            }
        }
    }
}
