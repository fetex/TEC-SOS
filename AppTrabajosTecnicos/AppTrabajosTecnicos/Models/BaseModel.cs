using System;
using System.Collections.Generic;
using System.Text;
using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;

namespace AppTrabajosTecnicos.Models
{
    public class BaseModel : NotificationObject
    {
        #region Properties
        [JsonIgnore]
        public long ID { get; set; }
        #endregion Properties
    }
}
