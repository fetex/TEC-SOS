using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class EstadoServicioModel : BaseModel
	{
		#region Propiedades
		[JsonProperty("estadoServicio_id")]
		public string estadoServicio_id { get; set; }
		[JsonProperty("estado")]
		private string estado;
		public ServicioModel Servicio { get; set; }
		#endregion

		#region Constructores
		public EstadoServicioModel() {}
		#endregion Constructores

		#region Getter & Setter
		public string Estado
		{
			get { return estado; }
			set
			{
				estado = value;
				OnPropertyChanged();
			}
		}
		#endregion Getter & Setter
	}
}
