using AppTrabajosTecnicos.Servicios.Propagacion;
using System.Collections.Generic;

namespace AppTrabajosTecnicos.Models
{
	internal class TrabajoModel : NotificationObject
	{
		#region Atributos
		public long ID { get; set; }
		public DireccionModel DireccionTrabajo { get; set; }
		private string nombreTrabajo;
		private string descripcion;
		private EstadoTrabajoModel estado;
		private List<CategoriaModel> categoria;
		private UsuarioModel propietario;
		private UsuarioModel tecnico;

		#endregion Atributos

		#region Constructores
		public TrabajoModel(EstadoTrabajoModel estado, UsuarioModel propietario)
		{
			this.estado = estado;
			this.propietario = propietario;
		}
		#endregion Constructores

		#region Getter/Setter
		public string NombreTrabajo
		{
			get { return nombreTrabajo; }
			set
			{
				nombreTrabajo = value;
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

		public EstadoTrabajoModel Estado
		{
			get { return estado; }
			set
			{
				estado = value;
				OnPropertyChanged();
			}
		}

		public List<CategoriaModel> Categoria
		{
			get { return categoria; }
			set
			{
				categoria = value;
				OnPropertyChanged();
			}
		}

		public UsuarioModel Propietario
		{
			get { return propietario; }
			set
			{
				propietario = value;
				OnPropertyChanged();
			}
		}

		public UsuarioModel Tecnico
		{
			get { return tecnico; }
			set
			{
				tecnico= value;
				OnPropertyChanged();
			}
		}
		#endregion Getter/Setter

	}
}