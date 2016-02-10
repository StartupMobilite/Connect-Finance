using ConnectFinance_1.Models;
using System;
using Xamarin.Auth;

namespace ConnectFinance_1.SocialNetwork
{
	class Facebook
	{
		private const string AppId = "128962504148722";
		private OAuth2Authenticator _auth;
		private Account _account;

		public Facebook()
		{
			_auth.Completed += (sender, eventArgs) => {
				// We presented the UI, so it's up to us to dimiss it on iOS.
				DismissViewController(true, null);

				if (eventArgs.IsAuthenticated)
				{
					// Use eventArgs.Account to do wonderful things
					_account = eventArgs.Account;
				}
			};
		}
		public User RetrieveUserInformation()
		{
			return null;
		}

		private void DismissViewController(bool v, object p)
		{
			throw new NotImplementedException();
		}

		public OAuth2Authenticator  GetAccount()
		{
			_auth = new OAuth2Authenticator(
			clientId: "128962504148722",
			scope: "id,name",
			authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
			redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

			return _auth;
		}
	}
}
