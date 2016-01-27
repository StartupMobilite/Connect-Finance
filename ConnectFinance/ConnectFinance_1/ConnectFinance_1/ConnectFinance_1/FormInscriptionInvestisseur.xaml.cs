using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using ConnectFinance_1.Models;
using System.Security.Cryptography;
using System.IO;

using Xamarin.Forms;

namespace ConnectFinance_1
{
	public partial class FormInscriptionInvestisseur : ContentPage
	{
        public User user;

		public FormInscriptionInvestisseur ()
		{
			InitializeComponent ();

            user = new User();
		}

		private void Validation_OnClicked(object sender, EventArgs e)
		{
            string url = "http://webdev77.fr/connect-finance/create-user.cgi";

            user.nom = nom.Text;
            user.prenom = prenom.Text;
            user.birthday = birthday.Text;
            user.sexe = "0";
            user.latitude = "0";
            user.longitude = "0";
            user.password = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(password.Text)).ToString();
            user.mail = mail.Text;
            user.account_type = "0";
            user.token_type = "0";
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

            StringBuilder postData = new StringBuilder();
            var properties = typeof(User).GetProperties();
            int prop_count = properties.Length;
            int i = 0;

            foreach (var prop in properties)
            {
                if(prop_count > i)
                {
                    postData.Append(HttpUtility.UrlEncode(String.Format(prop.Name.ToString() + "={0}", prop.Attributes.ToString())) + "&");
                } else
                {
                    postData.Append(HttpUtility.UrlEncode(String.Format(prop.Name.ToString() + "={0}", prop.Attributes.ToString())));
                }

                i++;
            }

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] postBytes = ascii.GetBytes(postData.ToString());

            var request = HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;

            Stream postStream = request.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Flush();
            postStream.Close();
        }
	}
}
