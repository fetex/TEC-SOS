﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppTrabajosTecnicos.Servicios.Propagacion
{
	class NotificationObject : INotifyPropertyChanged
	{
		public NotificationObject()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string nombre = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
		}
	}
}
