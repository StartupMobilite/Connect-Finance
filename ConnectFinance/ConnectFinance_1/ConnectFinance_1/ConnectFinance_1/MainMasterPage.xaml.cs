using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class MainMasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		ListView listView;

		public MainMasterPage()
		{
			InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Recherche de projet",
				//IconSource = "contacts.png",
				TargetType = typeof(MainPage)
			});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "Mon profil",
				TargetType =  typeof(Profil)
			});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "Map",
				TargetType = typeof(Map)
			});

			listView = new ListView
			{
				ItemsSource = masterPageItems,
				ItemTemplate = new DataTemplate(() => {
					var imageCell = new ImageCell();
					imageCell.SetBinding(TextCell.TextProperty, "Title");
					return imageCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			Padding = new Thickness(0, 40, 0, 0);
			Title = "Menu";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					listView
				}
			};
		}
	}
}

