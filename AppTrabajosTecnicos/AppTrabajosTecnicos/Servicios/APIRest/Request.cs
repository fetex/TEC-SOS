using AppTrabajosTecnicos.Models.ModelsAux;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabajosTecnicos.Servicios.APIRest
{
    public abstract class Request<T>
    {
 
        #region Properties
        protected string Url { get; set; }
        protected string Verbo { get; set; }

        #endregion Properties

        #region Metodos 
        public abstract Task<APIResponse> SendRequest(T objecto);
        #endregion Metodos
    }
}
