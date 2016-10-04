namespace WebUI.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using BusinessRules;

	/// <summary>
	///		Summary description for AppHeader
	/// </summary>
	public class AppMenu : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lnkViewIssue;
		protected System.Web.UI.WebControls.LinkButton lnkNewIssue;
		protected System.Web.UI.WebControls.LinkButton lnkEditIssue;
		protected System.Web.UI.WebControls.LinkButton lnkDeleteIssue;
		protected System.Web.UI.WebControls.LinkButton lnkHelp;
		protected System.Web.UI.WebControls.LinkButton lnkLogout;



		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			User objUser = (User)Session["USER_OBJECT"];

			switch( objUser.UserRole )
			{
				case (int)User.UserRoleType.Administrator:
					lnkDeleteIssue.Enabled = true;
					goto case (int)User.UserRoleType.Manager;

				case (int)User.UserRoleType.Manager:
					lnkEditIssue.Enabled = true;
					goto case (int)User.UserRoleType.TypicalUser;

				case (int)User.UserRoleType.TypicalUser:
					lnkNewIssue.Enabled = true;
					lnkViewIssue.Enabled = true;
					goto case (int)User.UserRoleType.Guest;

				case (int)User.UserRoleType.Guest:
					break;
			}

			return;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lnkHelp.Click += new System.EventHandler(this.lnkHelp_Click);
			this.lnkLogout.Click += new System.EventHandler(this.lnkLogout_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void lnkLogout_Click(object sender, System.EventArgs e)
		{
			//clear out the session data
			Session.Clear();

			//forward user to login page
			Response.Redirect( "Login.aspx", true );

			return;
		}



		private void lnkHelp_Click(object sender, System.EventArgs e)
		{
			//forward user to login page
			Response.Redirect( "Help.aspx", true );

			return;
		}

	
	}
}
