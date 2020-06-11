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
        public override async Task<APIResponse> SendRequest(T objecto)
        {
            APIResponse respuesta = new APIResponse()
            {
                Code = 400,
                IsSuccess = false,
                Response = ""
            };

            try
            {
                using (var client = new HttpClient())
                {
                    var verboHttp = (Verbo == "GET") ? HttpMethod.Get : HttpMethod.Delete;
                    await this.ConstruirUrl(objecto);
                    HttpRequestMessage requestMessage = new HttpRequestMessage(verboHttp, Url);
                    requestMessage = ServicioHeaders.AgregarCabeceras(requestMessage);
                    HttpResponseMessage HttpResponse = await client.SendAsync(requestMessage);
                    respuesta.Code = Convert.ToInt32(HttpResponse.StatusCode);
                    respuesta.IsSucess = HttpResponse.IsSuccessStatusCode;
                    respuesta.Response = await HttpResponse.Content.ReadAsStringAsync();
                }

            }
            catch(Exception)
            {
                respuesta.Response = "Error al momento de llamar al servidor";
            }

            return respuesta;
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
