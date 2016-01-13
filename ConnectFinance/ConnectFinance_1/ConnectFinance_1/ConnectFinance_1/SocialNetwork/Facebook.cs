namespace ConnectFinance_1.SocialNetwork
{
    class Facebook
    {
#if __Android__
		void LoginToFacebook(bool allowCancel)
	    {
		    var Authentification = new OAuth2Authenticator(
				clientId:"Url", 
				scope: "",
				authorizeUrl:new Uri(""), 
				redirectUrl:new Uri(""));

		    Authentification.AllowCancel = allowCancel;

			Authentification.Completed += (s, ee) => {
				if (!ee.IsAuthenticated)
				{
					var builder = new AlertDialog.Builder(this);
					builder.SetMessage("Not Authenticated");
					builder.SetPositiveButton("Ok", (o, e) => { });
					builder.Create().Show();
					return;
				}

				// Now that we're logged in, make a OAuth2 request to get the user's info.
				var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, ee.Account);
				request.GetResponseAsync().ContinueWith(t => {
					var builder = new AlertDialog.Builder(this);
					if (t.IsFaulted)
					{
						builder.SetTitle("Error");
						builder.SetMessage(t.Exception.Flatten().InnerException.ToString());
					}
					else if (t.IsCanceled)
						builder.SetTitle("Task Canceled");
					else {
						var obj = JsonValue.Parse(t.Result.GetResponseText());

						builder.SetTitle("Logged in");
						builder.SetMessage("Name: " + obj["name"]);
					}

					builder.SetPositiveButton("Ok", (o, e) => { });
					builder.Create().Show();
				}, UIScheduler);
			};

			var intent = auth.GetUI(this);
			StartActivity(intent);
		}

		private static readonly TaskScheduler UIScheduler = TaskScheduler.FromCurrentSynchronizationContext();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			var facebook = FindViewById<Button>(Resource.Id.FacebookButton);
			facebook.Click += delegate { LoginToFacebook(true); };

			var facebookNoCancel = FindViewById<Button>(Resource.Id.FacebookButtonNoCancel);
			facebookNoCancel.Click += delegate { LoginToFacebook(false); };
		}
		#endif

	}
}
