using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AppTrabajosTecnicos.Models
{
	class CategoriaModel : BaseModel
	{
		#region Properties
		[JsonProperty("categoria_id")]
		public int categoria_id { get; set; }
		[JsonProperty("categoria")]
		private string categoria;
		[JsonIgnore]
		private List<TecnicoModel> tecnicos;
		#endregion Properties

		#region Constructor
		public CategoriaModel() { }
		#endregion Constructor

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
