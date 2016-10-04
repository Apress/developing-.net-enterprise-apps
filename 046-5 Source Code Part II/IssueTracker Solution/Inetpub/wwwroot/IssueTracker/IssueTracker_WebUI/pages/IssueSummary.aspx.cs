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
using BusinessFacade;
using BusinessRules;



namespace WebUI.pages
{
	/// <summary>
	/// Summary description for IssueSummary.
	/// </summary>
	public class IssueSummary : ReflectionPage //System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid gridIssues;
		protected System.Web.UI.WebControls.Label lblGreeting;
		protected System.Web.UI.WebControls.Label Label3;
		private IssueManager _Issues = new IssueManager();



		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				User objUser = (User)Session["USER_OBJECT"];
				lblGreeting.Text = "Welcome to IssueTracker, " + objUser.Firstname;
			}
			catch( Exception x )
			{
			}

			gridIssues.DataSource = _Issues.GetAllIssues();
			gridIssues.DataBind();

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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
