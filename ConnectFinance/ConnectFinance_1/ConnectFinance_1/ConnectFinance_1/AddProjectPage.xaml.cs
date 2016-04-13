using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConnectFinance_1.Models;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace ConnectFinance_1
{
    public partial class AddProjectPage : ContentPage
    {
        private Project project;
        public List<Sector> sectorObjList { get; set; }

        public AddProjectPage()
        {
            project = new Project();
            sectorObjList = new List<Sector>();

            InitializeSectorPicker();
            InitializeComponent();

            //SectorPicker.ItemsSource = sectorObjList;
        }

        private void Validation_OnClicked(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            Uri url = new Uri("http://webdev77.fr/connect-finance/service.php?action=create_project");
            NameValueCollection parameters = new NameValueCollection();

            project.name = nom.Text;
            project.owner = Connexion.user.id;
            project.creation_date = new DateTime().ToString("YYYY-mm-dd");
            project.amount = amount.Text;
            project.description = description.Text;
			project.sector = new Sector();

            parameters.Add("name", project.name);
            parameters.Add("owner_id", project.owner);
            parameters.Add("creation_date", project.creation_date);
            parameters.Add("amount", project.amount);
            parameters.Add("description", project.description);
            parameters.Add("sector_id", project.sector.id);

            client.UploadValuesCompleted += client_UploadValuesCompleted;
            client.UploadValuesAsync(url, parameters);

            Button validationButton = (Button) sender;
            validationButton.IsEnabled = false;
            validationButton.Text = "Patientez...";
        }

        private void client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitializeSectorPicker()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            Uri url = new Uri("http://webdev77.fr/connect-finance/service.php?action=getSectorList");

            byte[] responseArray = client.DownloadData(url);
            string responseText = Encoding.UTF8.GetString(responseArray);

            if (!string.IsNullOrWhiteSpace(responseText))
            {
                var json = JObject.Parse(responseText);

                sectorObjList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sector>>(json["content"].ToString());
            }
        }
    }
}
