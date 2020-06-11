using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Validations.Base
{
    public interface IValidationRule<in T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
