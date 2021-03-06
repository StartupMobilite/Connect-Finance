﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ConnectFinance_1
{
    class MainMasterDetailPage : MasterDetailPage
    {
	    MainMasterPage masterPage;
	    public MainMasterDetailPage()
	    {
			masterPage = new MainMasterPage();
			Master = masterPage;
			Detail = new NavigationPage(new MainPage());
		    Detail.Icon = "MenuIcon";

			masterPage.ListView.ItemSelected += OnItemSelected;
		}
	    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
		    var item = e.SelectedItem as MasterPageItem;
		    if (item != null)
		    {
			    Detail = new NavigationPage((Page) Activator.CreateInstance(item.TargetType));
			    masterPage.ListView.SelectedItem = null;
			    IsPresented = false;
		    }
	    }
    }
}
