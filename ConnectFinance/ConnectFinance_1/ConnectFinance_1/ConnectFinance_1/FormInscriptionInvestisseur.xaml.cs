using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using ConnectFinance_1.Models;
using System.Security.Cryptography;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConnectFinance_1
{
	public partial class FormInscriptionInvestisseur : ContentPage
	{
        public User user;

		public FormInscriptionInvestisseur ()
		{
            InitializeComponent();

            user = new User();
		}

		private void Validation_OnClicked(object sender, EventArgs e)
		{
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            Uri url = new Uri("http://webdev77.fr/connect-finance/service.php?action=create_user");
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

            user.nom = nom.Text;
            user.prenom = prenom.Text;
            user.birthday = birthday.Date.ToString("YYYY-mm-dd");
            user.sexe = "3";
            user.latitude = "0";
            user.longitude = "0";
            user.password = strHex;
            user.mail = mail.Text;
            user.account_type = "0";
            user.token_type = "6";
            user.token = "";
            user.related_files_dir_uid = "test123";

            if(mail.Text != conf_mail.Text)
            {
                throw new Exception("Mail et confirmation de mail different");
            }

            if (password.Text != conf_password.Text)
            {
                throw new Exception("Mdp et confirmation de mdp different");
            }

            parameters.Add("nom", user.nom);
            parameters.Add("prenom", user.prenom);
            parameters.Add("birthday", user.birthday);
            parameters.Add("sexe", user.sexe);
            parameters.Add("tel", "0000000000");
            parameters.Add("latitude", user.latitude);
            parameters.Add("longitude", user.longitude);
            parameters.Add("password", user.password);
            parameters.Add("mail", user.mail);
            parameters.Add("account_type", user.account_type);
            parameters.Add("token_type", user.token_type);
            parameters.Add("token", user.token);
            parameters.Add("related_files_dir_uid", user.related_files_dir_uid);

		    client.UploadValuesCompleted += client_UploadValuesCompleted;
		    client.UploadValuesAsync(url, parameters);

		    Button validationButton = (Button)sender;
		    validationButton.IsEnabled = false;
		    validationButton.Text = "Patientez...";
		}

        private async void client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            //TODO: Redirection vers la page suivante avec un message comme quoi le compte est bien créé + sauvegarde du compte dans une sorte de session C#
            var modalPage = new ModalAccountHasBeenCreated();
            await Navigation.PushModalAsync(modalPage);
            await Navigation.PopModalAsync();
        }
    }
}
