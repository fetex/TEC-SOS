﻿using AppTrabajosTecnicos.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrabajosTecnicos.Models
{
	class ClienteModel : NotificationObject
	{
		#region Propiedades
		[JsonIgnore]
		public int ID { get; set; }
		[JsonProperty("cliente_id")]
		public int cliente_id { get; set; }
		[JsonIgnore]
		private List<DireccionModel> direcciones;
		[JsonIgnore]
		public UsuarioModel usuario;
		[JsonIgnore]
		private List<ServicioModel> servicios;
		#endregion

		#region Constructores
		public ClienteModel(UsuarioModel usuario) 
		{
			this.usuario = usuario;
		}
		#endregion

		#region Getter & Setter
		public List<DireccionModel> Direcciones
		{
			get { return direcciones; }
			set
			{
				direcciones = value;
				OnPropertyChanged();
			}
		}

		public UsuarioModel Usuario
		{
			get { return usuario; }
			set
			{
				usuario = value;
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