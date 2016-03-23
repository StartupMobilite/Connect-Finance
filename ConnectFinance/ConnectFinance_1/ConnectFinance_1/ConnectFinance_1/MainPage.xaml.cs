using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class MainPage : CarouselPage
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
	}
}
