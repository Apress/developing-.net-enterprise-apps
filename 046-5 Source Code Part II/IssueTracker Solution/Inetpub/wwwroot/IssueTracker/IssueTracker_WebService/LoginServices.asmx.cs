using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using BusinessFacade;
using BusinessRules;



namespace WebService
{
	/// <summary>
	/// Summary description for LoginServices.
	/// </summary>
	public class LoginServices : System.Web.Services.WebService
	{
		public LoginServices()
		{
			InitializeComponent();
		}



		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion



		[WebMethod( EnableSession=true ) ]
		public string ValidateLogin( string strEmailAddress, string strPassword )
		{
			//validate login by getting the user data
			User objUser = UserManager.GetUser( strEmailAddress, strPassword );

			if( objUser != null )
			{
				//if successful, return the key
				if( Session[strEmailAddress] == null )
					Session[strEmailAddress] = 1;

				return Session.SessionID;
			}

			//if not successful, return error message
			return "ERR: Unable to validate login.";
		}


	
		[WebMethod( EnableSession=true ) ]
		public string CheckKey( string strKey )
		{
			//determine if key is still valid
			if( Session.SessionID.CompareTo( strKey ) == 0 )
				return "OK: The Key is still valid.";

			else
				return "ERR: The Key is not valid.";
		}

	

	}
}
