using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	public class DireccionModel : BaseModel
	{
		#region Propiedades
		[JsonProperty("direccion_id")]
		public int direccion_id { get; set; }
		[JsonProperty("direccion")]
		private string direccion;
		[JsonProperty("barrio")]
		private string barrio;
		[JsonIgnore]
		public ClienteModel Cliente { get; set; }
		#endregion

		#region Constructores
		public DireccionModel() { }
		#endregion Constructores

		#region Getter & Setter
		public string Direccion
		{
			get { return direccion; }
			set
			{
				direccion = value;
				OnPropertyChanged();
			}
		}

		public string Barrio 
		{ 
			get { return barrio; }
			set
			{
				barrio = value;
				OnPropertyChanged();
			}
		}
		#endregion
	}
}
