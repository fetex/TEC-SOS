using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models 
{
	class UsuarioModel : BaseModel 
	{
		#region Propiedades
		[JsonProperty("usuario_id")]
		public int usuario_id { get; set; }
		[JsonProperty("username")]
		private string username;
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
		public string Username
		{
			get { return username; }
			set
			{
				username = value;
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
