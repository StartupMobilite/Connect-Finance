using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ConnectFinance_1.Models;
using Xamarin.Forms;
using Plugin.Messaging;

namespace ConnectFinance_1
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
			
		}

		private void ProfilBtn_OnClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new Profil());
		}

		private void MapBtn_OnClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new Map());
		}

		private void Contact_OnClicked(object sender, EventArgs e)
		{
			var toto = new Email();
			toto.sendEmail();
		}
	}
}