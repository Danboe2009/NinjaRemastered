using System;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

 
public class mono_gmail : MonoBehaviour
{
	void Start () 
	{
		Debug.Log ("Started Email");
		MailMessage mail = new MailMessage ();
             
		mail.From = new MailAddress ("Missingcontroller@gmail.com");
		mail.To.Add ("danboe2009@gmail.com");
		mail.Subject = "Test Mail";
		mail.Body = "This is for testing SMTP mail from GMAIL";
             
		SmtpClient smtpServer = new SmtpClient ("smtp.gmail.com");
		smtpServer.Port = 465;
		//smtpServer.Credentials = new System.Net.NetworkCredential ("missingcontroller@gmail.com", "Danad209");
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
                 delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true;
		};
		smtpServer.Send (mail);
		Debug.Log ("Sent");
	}
}
 