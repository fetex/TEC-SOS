using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppTrabajosTecnicos.Servicios.APIRest
{
    public class ServicioHeaders
    {
        #region Atributos 
        public Dictionary<string, string> Headers { get; set; }
        #endregion Atributos



        #region Initialize 
        public ServicioHeaders()
        {
            Headers.Add("conten-type", "application/json");
        }
        #endregion Initialize

        #region Metodos 
        public HttpRequestMessage AgregarCabeceras(HttpRequestMessage requestMessage)
        {
            foreach(var h in Headers)
            {
                requestMessage.Headers.Add(h.Key, h.Value);
            }

            return requestMessage;
        }
        #endregion Metodos
    }
}
