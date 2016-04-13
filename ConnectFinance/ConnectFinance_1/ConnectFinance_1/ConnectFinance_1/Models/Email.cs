using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Messaging;

namespace ConnectFinance_1.Models
{
    public class Email
    {
	    public void sendEmail(/*string destinataire, string objet, string body*/)
	    {
			var emailMessenger = CrossMessaging.Current.EmailMessenger;
		    if (emailMessenger.CanSendEmail)
		    {
			    var email = new EmailMessageBuilder()
				    .To("")
				    .Subject("")
				    .Body("")
				    //.WithAttachment("/storage/emulated/0/Android/data/MyApp/files/Pictures/temp/IMG_20141224_114954.jpg");
				    .Build();
				emailMessenger.SendEmail(email);
			}
		    
		}
    }
}
