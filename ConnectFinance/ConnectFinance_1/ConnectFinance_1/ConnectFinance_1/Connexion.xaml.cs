﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFinance_1.SocialNetwork;
using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class Connexion : ContentPage
	{
		public Connexion ()
		{
			InitializeComponent ();
		}

		private void ValiderBtn_OnClicked(object sender, EventArgs e)
		{
			if (adresse_mail.Text.Length > 0)
			{
				if (password.Text.Length > 0)
				{
					App.Current.MainPage = new MainMasterDetailPage();
				}
				else
				{
					DisplayAlert("Attention", "Les champs de doivent pas être vide", "Ok");
				}
			}
			else
			{
				DisplayAlert("Attention", "Les champs de doivent pas être vide", "Ok");
			}
			
		}
	}
}
