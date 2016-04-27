using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConnectFinance_1.Models;
using Newtonsoft.Json.Linq;
using PCLStorage;

using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class Landing : ContentPage
	{
		public Landing ()
		{
			

			InitializeComponent ();

			//Verifie si l'utilisateur est déjà connecté
			VerifRememberMe();

			btnConnexion.BackgroundColor = Color.Gray;
            btnInscription.BackgroundColor = Color.Gray;
		}

        void OnButtonConnexionClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Connexion());
        }

        void OnButtonInscriptionClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Inscription());
        }

		public async void VerifRememberMe()
		{
			string token;

			//Recupère le fichier log
			try
			{
				IFolder rootFolder = FileSystem.Current.LocalStorage;
				IFolder myFolder = await rootFolder.CreateFolderAsync("Log", CreationCollisionOption.OpenIfExists);
				
				IFile myFile = myFolder.GetFileAsync("Log.json").Result;
				token = myFile.ReadAllTextAsync().Result;
			}
			catch (Exception)
			{
				token = "";
			}

			//Parse les données du fichier log
			try
			{
				var json = JObject.Parse(token);

				User userObj = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json["content"].ToString());

				App.Current.MainPage = new NavigationPage(new MasterDetailPage());
			}
			catch (Exception)
			{
				App.Current.MainPage = new NavigationPage(new Connexion());
			}
		}
    }
}
