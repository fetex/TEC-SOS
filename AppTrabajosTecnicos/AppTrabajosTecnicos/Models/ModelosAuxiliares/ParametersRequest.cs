using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models.ModelsAux
{
    public class ParametersRequest
    {
        #region Properties
        public List<string> Parametros { get; set; }
        public Dictionary<string, string> QueryParametros { get; set; }
        #endregion Properties

        #region Initialize
        public ParametersRequest() {}
        #endregion Initialize
    }
}
