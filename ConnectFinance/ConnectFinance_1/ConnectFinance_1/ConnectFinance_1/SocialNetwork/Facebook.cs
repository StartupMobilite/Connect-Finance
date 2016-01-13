using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Xamarin.Auth;
using Newtonsoft.Json;
using System.Threading;
using Android.OS;
using Android.Widget;
using System.Threading.Tasks;
using ConnectFinance_1.Droid;
using Android.Content;

namespace ConnectFinance_1.SocialNetwork
{
	public class Facebook
	{
		public void LoginToFacebook()
		{
			var auth = new OAuth2Authenticator(
				clientId: "128962504148722",
				scope: "",
				authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

		}
	}
}
