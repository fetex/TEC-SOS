using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models 
{
	class UsuarioModel : NotificationObject
	{
		#region Propiedades
		[JsonIgnore]
		public int ID { get; set; }
		[JsonProperty("usuario_id")]
		public int usuario_id { get; set; }
		[JsonProperty("nombre")]
		private string nombre;
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("password")]
		private string password;
		[JsonIgnore]
		public ClienteModel Cliente { get; set; }
		[JsonIgnore]
		public TecnicoModel Tecnico { get; set; }
		[JsonIgnore]
		private List<TelefonoModel> telefonos;
		#endregion

		#region Constructores
		public UsuarioModel() { }
		#endregion

		#region Getter & Setter
		public string Nombre
		{
			get { return nombre; }
			set
			{
				nombre = value;
				OnPropertyChanged();
			}
		}

		public string Password
		{
			get { return password; }
			set
			{
				password = value;
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
		#endregion

	}
}
