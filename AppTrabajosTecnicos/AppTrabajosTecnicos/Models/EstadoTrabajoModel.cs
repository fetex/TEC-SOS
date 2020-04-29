using AppTrabajosTecnicos.Servicios.Propagacion;

namespace AppTrabajosTecnicos.Models
{
	internal class EstadoTrabajoModel: NotificationObject
	{
		#region Atributos
		public string ID { get; set; }
		public string estado { get; set; } 
		private TrabajoModel trabajo;
		#endregion Atributos

		#region Constructores
		#endregion Constructores

		#region Getter/Setter
		public TrabajoModel Trabajo
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