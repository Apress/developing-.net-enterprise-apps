using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;



namespace WebService
{
	/// <summary>
	/// Summary description for IssueServices.
	/// </summary>
	public class IssueServices : System.Web.Services.WebService
	{
		public IssueServices()
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
		public string GetSpecificIssue( string strKey, int argIssueID )
		{
			//check key
			LoginServices svcLogin = new LoginServices();

			if( svcLogin.CheckKey( strKey ).StartsWith( "OK" ) )
			{
				BusinessFacade.IssueManager mgrIssues = new
					BusinessFacade.IssueManager();

				return mgrIssues.GetSpecificIssueXml( argIssueID );
			}

			return null;
		}

	
	
	}
}
