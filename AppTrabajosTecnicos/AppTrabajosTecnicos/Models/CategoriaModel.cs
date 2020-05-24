using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class CategoriaModel : NotificationObject
	{
		#region Propiedades
		[JsonIgnore]
		public int ID { get; set; }
		[JsonProperty("categoria_id")]
		public int categoria_id { get; set; }
		[JsonProperty("categoria")]
		private string categoria;
		[JsonIgnore]
		private List<TecnicoModel> tecnicos;
		#endregion

		#region Constructor
		public CategoriaModel() { }
		#endregion

		#region Getter & Setter
		public String Categoria
		{
			get { return categoria; }
			set
			{
				categoria = value;
				OnPropertyChanged();
			}
		}

		public List<TecnicoModel> Tecnicos
		{
			get { return tecnicos; }
			set
			{
				tecnicos = value;
				OnPropertyChanged();
			}
		}
		#endregion
	}
}
