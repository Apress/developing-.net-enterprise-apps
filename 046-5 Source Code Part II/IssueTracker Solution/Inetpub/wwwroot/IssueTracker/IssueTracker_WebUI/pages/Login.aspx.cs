using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessRules;
using BusinessFacade;



namespace WebUI.pages
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtEmailAddress;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnOK;
	


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}



		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void btnOK_Click(object sender, System.EventArgs e)
		{
			User objUser = new User();

			objUser = UserManager.GetUser( txtEmailAddress.Text, txtPassword.Text );

			if( objUser != null )
			{
				//inserted code for testing
				if( objUser.Firstname.Length == 0 ){ objUser.Firstname = "TestUser"; }
				//inserted code for testing


				Session.Add( "USER_OBJECT", objUser );
				Response.Redirect( "IssueSummary.aspx", true );
			}

			return;
		}

	
	
	}
}
