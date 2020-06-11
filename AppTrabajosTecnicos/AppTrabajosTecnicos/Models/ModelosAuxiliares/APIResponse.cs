﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models.ModelsAux
{
    public class APIResponse
    {
        #region Properties
        public int Code { get; set; }
        public string Response { get; set; }
        public bool IsSuccess { get; set; }
        #endregion Properties

        #region Initialize
        public APIResponse() {}
        #endregion Initialize
    }
}
