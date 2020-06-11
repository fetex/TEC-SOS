using AppGestionTiendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTrabajosTecnicos.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        #region Properties
        private string message;

        public ICommand CloseCommand { get; set; }
        #endregion

        #region Getters y Setters
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters y Setters

      

       
    }
}
