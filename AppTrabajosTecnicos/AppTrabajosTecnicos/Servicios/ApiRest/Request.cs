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
        private static ServicioHeaders servicioHeaders;

        #endregion Properties

        #region Getters / Setters
        protected static ServicioHeaders ServicioHeaders
        {
            get
            {
                if (servicioHeaders == null)
                {
                    servicioHeaders = new ServicioHeaders();
                }

                return servicioHeaders;
            }
        }
    
        #endregion Getters / Setters
        #region Metodos 
        public abstract Task<APIResponse> SendRequest(T objecto);
        #endregion Metodos
    }
}
