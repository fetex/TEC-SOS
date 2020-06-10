﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionTiendas.Configuracion
{
    public class Endpoints
    {
        public static readonly string URL_SERVIDOR = "http://3.15.213.222:8000";
        public static readonly string CONSULTAR_ALL_CATEGORIAS = "/all";
        public static readonly string CONSULTAR_CATEGORIA = "/get";
        public static readonly string CREAR_CATEGORIA = "/create";
        public static readonly string EDITAR_CATEGORIA = "/update";
        public static readonly string ELIMINAR_CATEGORIA = "/delete";
    }
}