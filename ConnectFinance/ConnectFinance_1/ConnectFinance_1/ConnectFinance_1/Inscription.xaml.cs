using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class Inscription : ContentPage
	{
		public Inscription ()
		{
			InitializeComponent ();
		}
		private void BtnEntrepreneur_OnClicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new FormInscriEntrepreneur();
		}

		private void BtnInvestisseur_OnClicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new FormInscriptionInvestisseur();
		}
	}
}
