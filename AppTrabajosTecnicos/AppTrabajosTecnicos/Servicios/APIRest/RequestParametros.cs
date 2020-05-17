using AppTrabajosTecnicos.Servicios.APIRest;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models.ModelsAux
{
    public class RequestParametros<T> : Request<T>
    {
        public override APIResponse SendRequest(T objecto)
        {
            throw new NotImplementedException();
        }
    }
}
