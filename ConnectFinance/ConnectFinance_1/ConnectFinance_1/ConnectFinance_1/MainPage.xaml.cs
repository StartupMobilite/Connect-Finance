using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ConnectFinance_1.Models;
using Xamarin.Forms;
using Plugin.Messaging;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace ConnectFinance_1
{
	public partial class MainPage : ContentPage
	{
		public int index = 0;
		public List<Project> projectList = new List<Project>();

		public MainPage ()
		{
			InitializeComponent ();

			WebClient client = new WebClient();
			client.Encoding = Encoding.UTF8;

			Uri url = new Uri("http://webdev77.fr/connect-finance/service.php?action=getProjectList");
			NameValueCollection parameters = new NameValueCollection();

			byte[] responseArray = client.UploadValues(url, parameters);
			string responseText = Encoding.UTF8.GetString(responseArray);

			if (!string.IsNullOrWhiteSpace(responseText))
			{
				var json = JObject.Parse(responseText);

				projectList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Project>>(json["content"].ToString());
			}
			else
			{
				project_description.Text = "Pas de projets enregistrés pour l'instant !";
			}

			getNextProj ();
		}

		private void ProfilBtn_OnClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new Profil());
		}

		private void MapBtn_OnClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new Map());
		}

		private void Contact_OnClicked(object sender, EventArgs e)
		{
			var toto = new Email();
			toto.sendEmail();
		}

		private void Btn_Project_NInterested_Clicked(object sender, EventArgs e)
		{
			
			getNextProj ();

			//TODO: Enregistrer en base que le projet n'intéresse pas cette personne
		}

		private void Btn_Project_Interested_Clicked(object sender, EventArgs e)
		{
			getNextProj ();

			//TODO: Enregistrer en base l'intérêt que porte cette personne à ce projet
		}

		private void getNextProj() {
			if (projectList[index] != null) {
				project_title.Text = projectList [index].name;
				project_description.Text = projectList [index].description;

				index++;
			} else {
				project_description.Text = "Pas de projets enregistrés pour l'instant !";
			}
		}
	}
}