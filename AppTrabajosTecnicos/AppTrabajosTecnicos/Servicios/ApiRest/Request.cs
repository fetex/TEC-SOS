using AppTrabajosTecnicos.Models.ModelsAux;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppTrabajosTecnicos.Servicios.APIRest
{
    public abstract class Request<T>
    {
 
        #region Properties
        protected string Url { get; set; }
        protected string Verbo { get; set; }
        protected string UrlParameters { get; set; }

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

        public async Task ConstruirUrl(ParametersRequest parametros)
        {
            ParametersRequest Parametros = parametros as ParametersRequest;
            string newUrl = Url;

            if (Parametros.Parametros.Count > 0)
            {
                newUrl = (newUrl.Substring(Url.Length - 1) == "/") ? newUrl.Remove(newUrl.Length - 1) : newUrl;
                Parametros.Parametros.ForEach(p => newUrl += "/" + p);
            }

            if (Parametros.QueryParametros.Count > 0)
            {
                var queryParameters = await new FormUrlEncodedContent(Parametros.QueryParametros).ReadAsStringAsync();
                newUrl += queryParameters;
            }

            UrlParameters = newUrl;
        }
        #endregion Metodos
    }
}
