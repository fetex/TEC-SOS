using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionTiendas.Configuracion
{
    public class Endpoints
    {
        public static readonly string URL_SERVIDOR = "http://18.189.21.56";
        public static readonly string CONSULTAR_ALL_CATEGORIAS = "/listarCategorias";
        public static readonly string CONSULTAR_CATEGORIA = "/categoria";
        public static readonly string CREAR_CATEGORIA = "/crearCategoria";
        public static readonly string EDITAR_CATEGORIA = "/actualizarCategoria";
        public static readonly string ELIMINAR_CATEGORIA = "/eliminarCategoria";
    }
}