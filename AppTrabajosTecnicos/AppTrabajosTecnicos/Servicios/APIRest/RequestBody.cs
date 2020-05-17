using AppTrabajosTecnicos.Models.ModelsAux;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Servicios.APIRest
{
    public class RequestBody<T> : Request<T>
    {
        public override APIResponse SendRequest(T objecto)
        {
            throw new NotImplementedException();
        }
    }
}
