using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class UsuarioModel : NotificationObject
	{
		#region Atributos
		[JsonIgnore]
		public long ID { get; set; }
		[JsonProperty("idUsuario")]
		private long idUsuario { get; set; }
		[JsonProperty("emailUsuario")]
		public String Email { get; set; }
		[JsonProperty("nombreUsuario")]
		private String nombre;
		private List<TelefonoModel> telefonos;
		private List<DireccionModel> direcciones;
		private PerfilModel perfil;
		private List<TrabajoModel> trabajos;

		#endregion Atributos


		#region Constructores
		public UsuarioModel(PerfilModel perfil)
		{
			this.perfil = perfil;
		}
		#endregion Constructores

		#region Getter/Setter
		public String Nombre
		{
			get { return nombre; }
			set
			{
				nombre = value;
				OnPropertyChanged();
			}
		}

		public PerfilModel Perfil
		{
			get { return perfil; }
			set
			{
				perfil = value;
				OnPropertyChanged();
			}
		}

		public List<DireccionModel> Direcciones
		{
			get { return direcciones; }
			set
			{
				direcciones = value;
				OnPropertyChanged();
			}
		}

		public List<TelefonoModel> Telefonos
		{
			get { return telefonos; }
			set
			{
				telefonos = value;
				OnPropertyChanged();
			}
		}

		public List<TrabajoModel> Trabajos
		{
			get { return trabajos; }
			set
			{
				trabajos = value;
				OnPropertyChanged();
			}
		}
		#endregion Getter/Setter
	}
}
