using AppTrabajosTecnicos.Servicios.APIRest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabajosTecnicos.Models.ModelsAux
{
    /* GET AND DELETE */
    public class RequestParametros<T> : Request<T>
    {
        public RequestParametros(string url, string verbo)
        {
            Url = url;
            Verbo = verbo;
        }

        #region Metodos
        public override APIResponse SendRequest(T objecto)
        {
            throw new NotImplementedException();
        }

        private async Task ConstruirUrl(T parametros)
        {
            ParametersRequest Parametros = parametros as ParametersRequest;

            if (Parametros.Parametros.Count > 0)
            {
                Url = (Url.Substring(Url.Length - 1) == "/") ? Url.Remove(Url.Length - 1) : Url;
                Parametros.Parametros.ForEach(p => Url += "/" + p); 
            }

            if (Parametros.QueryParametros.Count > 0)
            {
                var queryParameters = await new FormUrlEncodedContent(Parametros.QueryParametros).ReadAsStringAsync();
                Url += queryParameters;
            }


        
        }

        #endregion Metodos
    }
}
