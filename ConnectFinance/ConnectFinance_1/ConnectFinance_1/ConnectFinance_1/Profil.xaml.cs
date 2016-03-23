using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class Profil : ContentPage
	{
		public Profil ()
		{
			InitializeComponent ();
		}

		private async void BtnDeconnexion_OnClicked(object sender, EventArgs e)
		{
			try
			{
				IFolder rootfFolder = FileSystem.Current.LocalStorage;
				IFolder myFolder = await rootfFolder.CreateFolderAsync("Log", CreationCollisionOption.OpenIfExists);
				IFile myFile = await myFolder.GetFileAsync("Log.json");
				await myFile.DeleteAsync();

				await Navigation.PushModalAsync(new Connexion());
			}
			catch (Exception)
			{
				await DisplayAlert("Attention !", "Une erreur est survenue, vous n'avez pas été déconnecté", "Ok");
			}
			

		}

		private void BtnChangeInfo_OnClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnUploadCV_OnClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnUploadLM_OnClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
