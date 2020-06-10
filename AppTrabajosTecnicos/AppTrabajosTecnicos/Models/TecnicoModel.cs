using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	public class TecnicoModel : BaseModel
	{
		#region Propiedades
		[JsonProperty("tecnico_id")]
		public int tecnico_id { get; set; }
		[JsonProperty("calificacion")]
		private float calificacion;
		[JsonIgnore]
		private string descripcion;
		public UsuarioModel Usuario { get; set; }
		[JsonIgnore]
		private CategoriaModel categoria;
		[JsonIgnore]
		private List<ServicioModel> servicios;
		#endregion

		#region Constructores
		public TecnicoModel(CategoriaModel categoria)
		{
			this.categoria = categoria;
		}
		#endregion

		#region Getter & Setter
		public float Calificacion
		{
			get { return calificacion; }
			set
			{
				calificacion = value;
				OnPropertyChanged();
			}
		}

		public string Descripcion
		{
			get { return descripcion; }
			set
			{
				descripcion = value;
				OnPropertyChanged();
			}
		}

		public CategoriaModel Categoria
		{
			get { return categoria; }
			set
			{
				categoria = value;
				OnPropertyChanged();
			}
		}

		public List<ServicioModel> Servicios
		{
			get { return servicios; }
			set
			{
				servicios = value;
				OnPropertyChanged();
			}
		}
		#endregion
	}
}
