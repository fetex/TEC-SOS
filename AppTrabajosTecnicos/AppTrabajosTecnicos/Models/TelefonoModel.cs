using AppTrabajosTecnicos.Servicios.Propagacion;

namespace AppTrabajosTecnicos.Models
{
	internal class TelefonoModel : NotificationObject
	{
		#region Atributos
		public long ID { get; set; }
		public UsuarioModel Usuario { get; set; }
		private string tipo;
		private string numero;
		#endregion Atributos

		#region Constructores
		#endregion Constructores
		
		#region Getter/Setter
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
		#endregion Getter/Setter
	}
}