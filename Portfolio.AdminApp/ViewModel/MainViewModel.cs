using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminApp.ViewModel
{
	public partial class MainViewModel : ObservableObject
	{
		[ObservableProperty]
		public partial string Title { get; set; } = "";

		[RelayCommand]
		private void Save()
		{

		}

	}
}
