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
                    client.Timeout = TimeSpan.FromSeconds(50);
                    HttpRequestMessage requestMessage = new HttpRequestMessage(verboHttp, UrlParameters);
                    requestMessage = ServicioHeaders.AgregarCabeceras(requestMessage);
                    HttpResponseMessage HttpResponse = client.SendAsync(requestMessage).Result;
                    respuesta.Code = Convert.ToInt32(HttpResponse.StatusCode);
                    respuesta.IsSuccess = HttpResponse.IsSuccessStatusCode;
                    respuesta.Response = await HttpResponse.Content.ReadAsStringAsync();
                }

            }
            catch(Exception)
            {
                respuesta.Response = "Error al momento de llamar al servidor";
            }

            return respuesta;
        }
        #endregion Metodos
    }
}
