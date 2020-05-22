using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class DireccionModel : NotificationObject
	{
		#region Propiedades
		[JsonIgnore]
		public int ID { get; set; }
		[JsonProperty("direccion_id")]
		public int direccion_id { get; set; }
		[JsonProperty("direccion")]
		private string direccion;
		[JsonProperty("complemento")]
		private string complemento;
		[JsonProperty("indicacion")]
		private string indicacion;
		[JsonIgnore]
		public ClienteModel Cliente { get; set; }
		#endregion

		#region Constructores
		public DireccionModel() { }
		#endregion

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

		public string Complemento 
		{ 
			get { return complemento; }
			set
			{
				complemento = value;
				OnPropertyChanged();
			}
		}

		public string Indicacion
		{
			get { return indicacion; }
			set
			{
				indicacion = value;
				OnPropertyChanged();
			}
		}
		#endregion
	}
}
