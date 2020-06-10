using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	public class ServicioModel : BaseModel
	{
		#region Propiedades
		[JsonProperty("servicio_id")]
		public int servicio_id { get; set; }
		[JsonProperty("descripcion")]
		public string Descripcion { get; set; }
		[JsonProperty("fecha")]
		public string Fecha { get; set; }
		[JsonIgnore]
		private EstadoServicioModel estado;
		[JsonIgnore]
		public ClienteModel Cliente { get; set; }
		[JsonIgnore]
		public TecnicoModel Tecnico { get; set; }
		#endregion
		#region Constructores
		public ServicioModel(EstadoServicioModel estado, ClienteModel cliente, TecnicoModel tecnico) 
		{
			this.estado = estado;
			this.Cliente = cliente;
			this.Tecnico = tecnico;
		}
		#endregion

		#region Getter & Setter
		public EstadoServicioModel Estado
		{
			get { return estado; }
			set
			{
				estado = value;
				OnPropertyChanged();
			}
		}
		#endregion
	}
}
