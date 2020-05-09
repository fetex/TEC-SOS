using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppTrabajosTecnicos.Models
{
	internal class CategoriaModel : NotificationObject
	{
		#region Atributos
		[JsonIgnore]
		public long ID { get; set; }
		[JsonProperty("idCategoria")]
		private long idCategoria { get; set; }
		[JsonProperty("nombreCategoria")]
		private string categoria;
		[JsonIgnore]
		private List<TrabajoModel> trabajo;
		#endregion Atributos

		#region Constructores
		#endregion Constructores

		#region Getter/Setter
		
		public List<TrabajoModel> Trabajo
		{
			get { return trabajo; }
			set
			{
				trabajo = value;
				OnPropertyChanged();
			}
		}
		#endregion Getter/Setter
	}
}