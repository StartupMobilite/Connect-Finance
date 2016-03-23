using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConnectFinance_1.SocialNetwork;
using Xamarin.Forms;
using System.Net;
using System.Security.Cryptography;
using ConnectFinance_1.Models;
using Newtonsoft.Json.Linq;
using PCLStorage;

namespace ConnectFinance_1
{
	public partial class Connexion : ContentPage
	{
	    private User user;
		private string responseValue;

		public Connexion()
		{
			InitializeComponent();

            user = new User();
		}

		private void ValiderBtn_OnClicked(object sender, EventArgs e)
		{
			if((adresse_mail.Text.Length > 0) && (password.Text.Length > 0))
			{
                Button validationButton = (Button)sender;
                validationButton.IsEnabled = false;
                validationButton.Text = "Patientez...";

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;

                Uri url = new Uri("http://webdev77.fr/connect-finance/service.php?action=connexion");
                NameValueCollection parameters = new NameValueCollection();

                String mdp = password.Text;
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] HashValue, MessageBytes = encoding.GetBytes(mdp);
                SHA1Managed SHhash = new SHA1Managed();
                string strHex = "";

                HashValue = SHhash.ComputeHash(MessageBytes);
                foreach (byte b in HashValue)
                {
                    strHex += String.Format("{0:x2}", b);
                }

                user.password = strHex;
                user.mail = adresse_mail.Text;

                parameters.Add("password", user.password);
                parameters.Add("mail", user.mail);

                byte[] responseArray = client.UploadValues(url, parameters);
			    string responseText = Encoding.UTF8.GetString(responseArray);

			    if (!string.IsNullOrWhiteSpace(responseText))
			    {
			        var json = JObject.Parse(responseText);

			        User userObj = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json["content"].ToString());

                    //TODO: Stockage de userObj dans le fichier de "session" sur le device

				    if (monSwitch.IsToggled == true)
				    {
					    responseValue = responseText;
						WriteLogFile();
				    }

                    App.Current.MainPage = new MainMasterDetailPage();
                }
                else
			    {
			        //Error.Text = "Ce compte n'existe pas !";
			        adresse_mail.Text = "";
			        password.Text = "";
                    validationButton.IsEnabled = true;
                    validationButton.Text = "Valider";
                }
            } else {
                DisplayAlert("Attention", "Les champs ne doivent pas être vide", "Ok");
            }
        }

        private void BtnFb_OnClicked(object sender, EventArgs e)
		{
			var FbProvider = new Facebook();

			//FbProvider.GetAccount().GetUI();
		}

		private void BtnLnkd_OnClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnGP_OnClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		public async void WriteLogFile()
		{
			IFolder rootFolder = FileSystem.Current.LocalStorage;
			IFolder myFolder = await rootFolder.CreateFolderAsync("Log", CreationCollisionOption.OpenIfExists);
			IFile myFile = await myFolder.CreateFileAsync("Log.json", CreationCollisionOption.OpenIfExists);
			await myFile.WriteAllTextAsync(responseValue);
		}
	}
}
