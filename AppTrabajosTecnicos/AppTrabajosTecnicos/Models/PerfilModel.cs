using AppTrabajosTecnicos.Servicios.Propagacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class PerfilModel : NotificationObject
	{
		#region Atributos
		public long ID { get; set; }
		public UsuarioModel Usuario { get; set; }
		private string nombrePerfil;
		#endregion Atributos

		#region Constructores
		#endregion Constructores

		#region Getter/Setter
		public string NombrePerfil
		{
			get { return nombrePerfil; }
			set
			{
				nombrePerfil = value;
				OnPropertyChanged();
			}
		}
		#endregion Getter/Setter
	}
}
