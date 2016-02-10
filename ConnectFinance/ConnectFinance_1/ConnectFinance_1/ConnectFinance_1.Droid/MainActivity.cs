using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ConnectFinance_1.SocialNetwork;

namespace ConnectFinance_1.Droid
{
	[Activity (Label = "ConnectFinance_1", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new ConnectFinance_1.App ());

			var FbProvider = new Facebook();
			
			//StartActivity(FbProvider.GetAccount().GetUI(this));
		}
	}
}

