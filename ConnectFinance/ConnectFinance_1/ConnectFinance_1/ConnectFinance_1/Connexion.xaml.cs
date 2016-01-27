using System;
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
			App.Current.MainPage = new MainMasterDetailPage();
		}
	}
}
