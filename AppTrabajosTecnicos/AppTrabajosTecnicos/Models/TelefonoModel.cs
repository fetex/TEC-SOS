using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class TelefonoModel : BaseModel
	{
		#region Propiedades
		[JsonProperty("telefono_id")]
		public int telefono_id { get; set; }
		[JsonProperty("tipo")]
		private string tipo;
		[JsonProperty("numero")]
		private string numero;
		public UsuarioModel Usuario { get; set; }
		#endregion

		#region Constructores
		public TelefonoModel() { }
		#endregion 

		#region Getter & Setter
		public string Tipo
		{ 
			get { return tipo; }
			set
			{
				tipo = value;
				OnPropertyChanged();
			}
		}

		public string Numero
		{
			get { return numero; }
			set
			{
				numero = value;
				OnPropertyChanged();
			}
		}
		#endregion
	}
}
