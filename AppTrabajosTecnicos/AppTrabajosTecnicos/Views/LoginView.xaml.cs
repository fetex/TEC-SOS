﻿using AppTrabajosTecnicos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTrabajosTecnicos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		LoginViewModel contex = new LoginViewModel();
		public LoginView()
		{
			
			InitializeComponent();
			BindingContext = contex;

		}
	}
}