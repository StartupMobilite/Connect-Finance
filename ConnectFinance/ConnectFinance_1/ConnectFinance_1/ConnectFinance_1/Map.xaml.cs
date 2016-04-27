using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace ConnectFinance_1
{
	public partial class Map : ContentPage
	{
		public Map ()
		{


			var map = new Xamarin.Forms.Maps.Map(
				MapSpan.FromCenterAndRadius(
					new Position(48.856614, 2.3522219000000177), Distance.FromMiles(0.3))) {
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			Content = stack;
		}
	}
}