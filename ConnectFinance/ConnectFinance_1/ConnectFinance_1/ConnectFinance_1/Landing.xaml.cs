﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class Landing : ContentPage
	{
		public Landing ()
		{
			InitializeComponent ();
		}

        void OnButtonConnexionClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Connexion());
        }

        void OnButtonInscriptionClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Inscription());
        }
    }
}
