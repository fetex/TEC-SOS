using AppTrabajosTecnicos.Servicios.Propagacion;

namespace AppTrabajosTecnicos.Models
{
	internal class DireccionModel: NotificationObject
	{
		#region Atributos
		public long ID { get; set; }
		public UsuarioModel Usuario { get; set; }
		private string direccion;
		private string complemento;
		private string comentario;
		private bool favorito;
		#endregion Atributos

		#region Constructores
		#endregion Constructores

		#region Getter/Setter
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

		public string Comentario
		{
			get { return comentario; }
			set
			{
				comentario = value;
				OnPropertyChanged();
			}
		}

		public bool Favorito
		{
			get { return favorito; }
			set
			{
				favorito = value;
				OnPropertyChanged();
			}
		}
		#endregion Getter/Setter
	}
}