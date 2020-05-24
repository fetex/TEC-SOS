using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class EstadoServicioModel : NotificationObject
	{
		#region Propiedades
		[JsonIgnore]
		public int ID { get; set; }
		[JsonProperty("estadoServicio_id")]
		public string estadoServicio_id { get; set; }
		[JsonProperty("estado")]
		public string Estado { get; set; }
		public ServicioModel Servicio { get; set; }
		#endregion

		#region Constructores
		#endregion

		#region Getter & Setter
		#endregion
	}
}
