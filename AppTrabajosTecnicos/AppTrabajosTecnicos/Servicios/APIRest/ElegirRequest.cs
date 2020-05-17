using AppTrabajosTecnicos.Configuracion;
using AppTrabajosTecnicos.Models.ModelsAux;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Servicios.APIRest
{
    public class ElegirRequest<T>
    {
        #region Properties
        public Request<T> EstrategiaEnvio { get; set; }
        public ConfiguracionRest ConfiguracionRest { get; set; }      
        #endregion Properties

        #region Initialize
        public ElegirRequest() 
        {
            ConfiguracionRest = new ConfiguracionRest();
        }
        #endregion Initialize

        #region Metodos 
        public void ElegirEstrategia(string verbo, string url)
        {
            var diccionario = ConfiguracionRest.VerbosConfiguracion;
            string nombreClase;
            if (diccionario.TryGetValue(verbo, out nombreClase))
            {
                Type tipoClase = Type.GetType(nombreClase);
                EstrategiaEnvio = (Request<T>)Activator.CreateInstance(tipoClase);
            }
        }

        public APIResponse EjecutarEstrategia(T objecto)
        {
            var response = EstrategiaEnvio.SendRequest(objecto);
            return response;
        }
        #endregion Metodos
    }
}
