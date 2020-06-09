using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Configuracion
{
    public class ConfiguracionRest
    {
        #region Properties
        private readonly string NameSpaceRest;
        #endregion Properties
        public Dictionary<string, string> VerbosConfiguracion { get; set; }
        #region Initialize 
        public ConfiguracionRest()
        {
            NameSpaceRest = "AppTrabajosTecnicos.Servicios.APIRest.";
            InicializarVerbosConfiguracion();
        }
        #endregion Initialize

        #region Metodos 
        private void InicializarVerbosConfiguracion()
        {
            VerbosConfiguracion = new Dictionary<string, string>();
            VerbosConfiguracion.Add("GET", string.Concat(NameSpaceRest, "RequestParametros`1"));
            VerbosConfiguracion.Add("DELETE", string.Concat(NameSpaceRest, "RequestParametros`1"));
            VerbosConfiguracion.Add("POST", string.Concat(NameSpaceRest, "RequestBody`1"));
            VerbosConfiguracion.Add("PUT", string.Concat(NameSpaceRest, "RequestBody`1"));
        }
        #endregion Metodos
    }
}
