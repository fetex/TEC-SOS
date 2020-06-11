using AppGestionTiendas.Configuracion;
using AppGestionTiendas.ViewModels;
using AppGestionTiendas.Views;
using AppTrabajosTecnicos.Models;
using AppTrabajosTecnicos.Models.ModelsAux;
using AppTrabajosTecnicos.Servicios.APIRest;
using AppTrabajosTecnicos.Validations.Base;
using AppTrabajosTecnicos.Validations.Rules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTrabajosTecnicos.ViewModels
{
    public class CategoriaViewModel : ViewModelBase
    {
        #region Properties
        #region Atrributes
        public ValidatableObject<string> BusquedaCategoria { get; set; }  //Campo de Busqueda
        public ValidatableObject<string> NombreCategoria { get; set; }

        private CategoriaModel categoria;

        //public MessageViewPop PopUp { get; set; }

        private bool isGuardarEnable;

        private bool isEliminarEnable;

        private bool isGuardarEditar;

        private bool isBuscarEnable;

        private ObservableCollection<CategoriaModel> categorias;
        #endregion Atrributes
       

        #region Request
        public ElegirRequest<BaseModel> GetCategorias { get; set; }
        public ElegirRequest<BaseModel> GetCategoria { get; set; }
        public ElegirRequest<CategoriaModel> CreateCategoria { get; set; }
        public ElegirRequest<CategoriaModel> EditarCategoria { get; set; }
        public ElegirRequest<BaseModel> EliminarCategoria { get; set; }
        #endregion Request

        #region Commands
        public ICommand ListaCategoriasCommand { get; set; }
        public ICommand SelectCategoriaCommand { get; set; }
        public ICommand CrearCategoriaCommand { get; set; }
        public ICommand EliminarCategoriaCommand { get; set; }
        public ICommand NuevaCategoriaCommand { get; set; }
        public ICommand ValidateBusquedaCommand { get; set; }
        public ICommand ValidateNombreCategoriaCommand { get; set; }

        #endregion Commands

        #endregion Properties

        #region Getters & Setters

        public CategoriaModel Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                OnPropertyChanged();
            }
        }
        public bool IsGuardarEnable
        {
            get { return isGuardarEnable; }
            set
            {
                isGuardarEnable = value;
                OnPropertyChanged();
            }
        }
        public bool IsEliminarEnable
        {
            get { return isEliminarEnable; }
            set
            {
                isEliminarEnable = value;
                OnPropertyChanged();
            }
        }
        public bool IsGuardarEditar
        {
            get { return isGuardarEditar; }
            set
            {
                isGuardarEditar = value;
                OnPropertyChanged();
            }
        }
        public bool IsBuscarEnable
        {
            get { return isBuscarEnable; }
            set
            {
                isBuscarEnable = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CategoriaModel> Categorias
        {
            get { return categorias; }
            set
            {
                categorias = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
        #region Initialize
        public CategoriaViewModel()
        {
            //PopUp = new MessageViewPop();
            Categoria = new CategoriaModel();
            IsGuardarEnable = false;
            IsEliminarEnable = false;
            IsGuardarEditar = false;
            IsBuscarEnable = false;
            Categorias = new ObservableCollection<CategoriaModel>();
            InitializeRequest();
            InitializeCommands();
            InitializeFields();
        }

        public void InitializeRequest()
        {
            string urlCategorias = Endpoints.URL_SERVIDOR + Endpoints.CONSULTAR_ALL_CATEGORIAS;
            string urlCategoria = Endpoints.URL_SERVIDOR + Endpoints.CONSULTAR_CATEGORIA;
            string urlCrearCategoria = Endpoints.URL_SERVIDOR + Endpoints.CREAR_CATEGORIA;
            string urlEditarCategoria = Endpoints.URL_SERVIDOR + Endpoints.EDITAR_CATEGORIA;
            string urlEliminarCategoria = Endpoints.URL_SERVIDOR + Endpoints.ELIMINAR_CATEGORIA;

            GetCategorias = new ElegirRequest<BaseModel>();
            GetCategorias.ElegirEstrategia("GET", urlCategorias);

            GetCategoria = new ElegirRequest<BaseModel>();
            GetCategoria.ElegirEstrategia("GET", urlCategoria);

            CreateCategoria = new ElegirRequest<CategoriaModel>();
            CreateCategoria.ElegirEstrategia("POST", urlCrearCategoria);

            EditarCategoria = new ElegirRequest<CategoriaModel>();
            EditarCategoria.ElegirEstrategia("PUT", urlEditarCategoria);

            EliminarCategoria = new ElegirRequest<BaseModel>();
            EliminarCategoria.ElegirEstrategia("DELETE", urlEliminarCategoria);
        }

        public void InitializeCommands()

        {
            ListaCategoriasCommand = new Command(async () => await ListaCategorias(), () => true);
            SelectCategoriaCommand = new Command(async () => await SelecccionarCategoria(), () => IsBuscarEnable);
            CrearCategoriaCommand = new Command(async () => await GuardarCategoria(), () => IsGuardarEnable);
            EliminarCategoriaCommand = new Command(async () => await DeleteCategoria(), () => IsEliminarEnable);
            NuevaCategoriaCommand = new Command(() => NuevaCategoria(), () => true);
            ValidateBusquedaCommand = new Command(() => ValidateBusquedaForm(), () => true);
            ValidateNombreCategoriaCommand = new Command(() => ValidateNombreCategoriaForm(), () => true);
        }
        public void InitializeFields()
        {
            BusquedaCategoria = new ValidatableObject<string>();
            NombreCategoria = new ValidatableObject<string>();

            BusquedaCategoria.Validations.Add(new RequiredRule<string> { ValidationMessage = "El Id es Obligatorio" });
            NombreCategoria.Validations.Add(new RequiredRule<string> { ValidationMessage = "El nombre de la categoria es Obligatorio" });
        }
        #endregion Initialize

        public async Task ListaCategorias()
        {
            //var navigationStack = App.Current.MainPage.Navigation.NavigationStack;
            //var x = 1;
            //APIResponse response = await GetCategorias.EjecutarEstrategia(null);
            //if(response.IsSuccess)
            //{
            //    List<CategoriaModel> listaCategorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(response.Response);
            //    Categorias = new ObservableCollection<CategoriaModel>(listaCategorias);
            //}
            //else
            //{
            //    ((MessageViewModel)PopUp.BindingContext).Message = "Error al cargar las categorías";
            //    await PopupNavigation.Instance.PushAsync(PopUp);
            //}
            //await NavigationService.RemovePreviousPage();
            //var navigationStack2 = App.Current.MainPage.Navigation.NavigationStack;
            //var y = 3;
            LoginViewModel LoginViewModel = (LoginViewModel)NavigationService.PreviousViewModel;
            LoginViewModel.ContarLogin += 1;
            await NavigationService.PopPage();
        }

        #region Methods
        public async Task SelecccionarCategoria()
        {
            try
            {
                ParametersRequest parametros = new ParametersRequest();
                parametros.Parametros.Add(BusquedaCategoria.Value);
                APIResponse response = await GetCategoria.EjecutarEstrategia(null, parametros);
                if (response.IsSuccess)
                {
                    Categoria = JsonConvert.DeserializeObject<CategoriaModel>(response.Response);
                    NombreCategoria.Value = Categoria.Categoria;
                    IsEliminarEnable = true;
                    IsGuardarEnable = true;
                    IsGuardarEditar = true;
                    ((Command)CrearCategoriaCommand).ChangeCanExecute();
                    ((Command)EliminarCategoriaCommand).ChangeCanExecute();
                }
                
            }
            catch (Exception e)
            {

            }
        }

        private async Task GuardarCategoria()
        {
            if (Categoria.categoria_id == 0)
            {
                await CrearCategoria();
                IsGuardarEnable = false;
                ((Command)CrearCategoriaCommand).ChangeCanExecute();
            }
            else
            {
                await UpdateCategoria();
                IsEliminarEnable = false;
                ((Command)EliminarCategoriaCommand).ChangeCanExecute();
            }
            IsGuardarEditar = false;
            Categoria = new CategoriaModel();
            NombreCategoria.Value = "";
            BusquedaCategoria.Value = "";
        }
        public async Task CrearCategoria()
        {
            try
            {
                CategoriaModel categoria = new CategoriaModel()
                {
                    Categoria = NombreCategoria.Value
                };
                APIResponse response = await CreateCategoria.EjecutarEstrategia(categoria);

            }
            catch (Exception e)
            {

            }
        }

        public async Task UpdateCategoria()
        {
            try
            {
                CategoriaModel categoria = new CategoriaModel()
                {
                    categoria_id = Categoria.categoria_id,
                    Categoria = NombreCategoria.Value
                };
                ParametersRequest parametros = new ParametersRequest();
                parametros.Parametros.Add(categoria.categoria_id.ToString());
                APIResponse response = await EditarCategoria.EjecutarEstrategia(categoria, parametros);
               
               
            }
            catch (Exception e)
            {

            }
        }

        public async Task DeleteCategoria()
        {
            try
            {
                ParametersRequest parametros = new ParametersRequest();
                parametros.Parametros.Add(Categoria.categoria_id.ToString());
                APIResponse response = await EliminarCategoria.EjecutarEstrategia(null, parametros);
            
            }
            catch (Exception e)
            {

            }
        }
        public void NuevaCategoria()
        {
            Categoria = new CategoriaModel();
            NombreCategoria.Value = "";
            BusquedaCategoria.Value = "";
            IsEliminarEnable = false;
            IsGuardarEditar = true;
            ((Command)EliminarCategoriaCommand).ChangeCanExecute();
        }
        private void ValidateBusquedaForm()
        {
            IsBuscarEnable = BusquedaCategoria.Validate();
            ((Command)SelectCategoriaCommand).ChangeCanExecute();
        }

        private void ValidateNombreCategoriaForm()
        {
            IsGuardarEnable = NombreCategoria.Validate();
            ((Command)CrearCategoriaCommand).ChangeCanExecute();
        }
        #endregion Methods
    }
}