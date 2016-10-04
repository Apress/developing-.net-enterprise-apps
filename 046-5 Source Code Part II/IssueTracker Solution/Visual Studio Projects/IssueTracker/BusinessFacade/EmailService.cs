using System;
using System.Collections;
using System.Reflection;
using System.Web.Mail;
using System.Runtime.InteropServices;
using BusinessRules;



namespace BusinessFacade
{
	/// <summary>
	/// Summary description for EmailService.
	/// </summary>
	public class EmailService : BusinessService
	{
		private User _UserFrom = new User();
		private User _UserTo = new User();
		private User _UserCc = new User();
		private User _UserBcc = new User();
		private MailMessage _OutgoingMessage = new MailMessage();
		private ArrayList _IncomingMessages = new ArrayList();



		public EmailService()
		{
		}



		public User SendTo
		{
			get
			{
				return _UserTo;
			}
			set
			{
				_UserTo = value;
			}
		}



		public User SendCc
		{
			get
			{
				return _UserCc;
			}
			set
			{
				_UserCc = value;
			}
		}

		
		
		public User SendBcc
		{
			get
			{
				return _UserBcc;
			}
			set
			{
				_UserBcc = value;
			}
		}



		public User SentFrom
		{
			get
			{
				return _UserFrom;
			}
			set
			{
				_UserFrom = value;
			}
		}

		
		
		public MailMessage OutgoingMessage
		{
			get
			{
				return _OutgoingMessage;
			}
			set
			{
				_OutgoingMessage = value;
			}
		}



		public void SendMessage()
		{
			try
			{
				//assign 'to' user
				_OutgoingMessage.To = _UserTo.EmailAddress;

				//assign 'cc' user
				_OutgoingMessage.Cc = _UserCc.EmailAddress;

				//assign 'bcc' user
				_OutgoingMessage.Bcc = _UserBcc.EmailAddress;

				//assign the 'from' user
				_OutgoingMessage.From = _UserFrom.EmailAddress;

				SmtpMail.SmtpServer = "localhost";
				SmtpMail.Send( _OutgoingMessage );
			}
			catch( Exception x )
			{
				LogEvent( x.Message );
			}

			return;
		}



		private void SendAlertToUser()
		{
			User userTo = new User();
			userTo.EmailAddress = "sendto@something.com";

			User userFrom = new User();
			userFrom.EmailAddress =  "sentfrom@something.com";

			User userCc = new User();
			userCc.EmailAddress = "copyto@something.com";

			User userBcc = new User();
			userBcc.EmailAddress =  "blindcopyto@something.com";

			MailMessage message = new MailMessage();
			message.Subject = "IssueTracker Alert";
			message.Body = "A new issue has been assigned to you.";

			EmailService mail = new EmailService();
			mail.SendTo = userTo;
			mail.SendCc = userCc;
			mail.SendBcc = userBcc;
			mail.SentFrom = userFrom;
			mail.OutgoingMessage = message;

			mail.SendMessage();

			return;
		}



		private void SendAlertToUser_2()
		{
			User userTo = new User();
			userTo.EmailAddress = "sendto@something.com";

			User userFrom = new User();
			userFrom.EmailAddress =  "sentfrom@something.com";

			User userCc = new User();
			userCc.EmailAddress = "copyto@something.com";

			User userBcc = new User();
			userBcc.EmailAddress =  "blindcopyto@something.com";

			MailMessage message = new MailMessage();
			message.Subject = "IssueTracker Alert";
			message.Body = "A new issue has been assigned to you.";

			EmailService mail = new EmailService();
			mail.SendTo = userTo;
			mail.SendCc = userCc;
			mail.SendBcc = userBcc;
			mail.SentFrom = userFrom;
			mail.OutgoingMessage = message;

			MailAttachment attachment = new MailAttachment( 
				"c:\\IssueTracker\\sample.txt", System.Web.Mail.MailEncoding.Base64 );

			message.Attachments.Add( attachment );

			mail.SendMessage();

			return;
		}



		public void SendMessage( MailMessageTemplate argTemplate, Issue argIssue )
		{
			int intStart = 0;
			int intEnd = 0;
			string strField = "";
			string strValue = "";
			string strSource = "";

			Type objType;
			FieldInfo field;

			try
			{
				//fill the message template
				strSource = argTemplate.Body;

				while( intStart >= 0 )
				{ 
					//find the start
					intStart = strSource.IndexOf( "<Issue.", intStart ) + 7;

					//find the end
					intEnd = strSource.IndexOf( ">", intStart );

					//get the field name
					strField = strSource.Substring( intStart, intEnd - intStart );

					objType = argIssue.GetType();
					field = objType.GetField( strField );

					strValue = field.GetValue( objType ).ToString();

					strSource = strSource.Replace( "<Issue." + strField + ">", strValue);
				};

				//set the outgoing message
				MailMessage _OutgoingMessage = new MailMessage();
				_OutgoingMessage.To = _UserTo.EmailAddress;
				_OutgoingMessage.Cc = _UserCc.EmailAddress;
				_OutgoingMessage.Bcc = _UserBcc.EmailAddress;
				_OutgoingMessage.From = _UserFrom.EmailAddress;
				_OutgoingMessage.Subject = argTemplate.Subject;
				_OutgoingMessage.Body = strSource;

				//send the messsage
				SmtpMail.SmtpServer = "localhost";
				SmtpMail.Send( _OutgoingMessage );
			}
			catch( Exception x )
			{
				LogEvent( x.Message );
			}

			return;
		}



		public ArrayList GetMail()
		{
			MailMessage message;
			Outlook.MailItem msgInbox;
			ArrayList arrayMessages = null;
			Outlook.ApplicationClass appOutlook = null;

			try
			{
				arrayMessages = new ArrayList();

				//connect to the CDO library
				appOutlook = new Outlook.ApplicationClass();
				Outlook.NameSpace appNamespace = appOutlook.GetNamespace("MAPI");
				appNamespace.Logon( "jkanalakis", "jkanalakis", false, false );

				//navigate to the inbox folder
				Outlook.Explorer exp = appOutlook.Explorers.Item(1);

				for( int intIdx = 1; intIdx <= exp.CurrentFolder.Items.Count; intIdx++ )
				{
					//retrieve the next message from the inbox
					msgInbox = (Outlook.MailItem)exp.CurrentFolder.Items.Item(intIdx);

					//convert data into MailMessage
					message = new MailMessage();
					message.Subject = msgInbox.Subject;
					message.Body = msgInbox.Body;

					//add MailMessage to the ArrayList
					arrayMessages.Add( message );
				}
			}
			catch( Exception exception ) 
			{
				LogEvent( exception.Message );
			}
			finally
			{
				Marshal.ReleaseComObject( appOutlook );
			}

			return arrayMessages;
		}



	}
}
