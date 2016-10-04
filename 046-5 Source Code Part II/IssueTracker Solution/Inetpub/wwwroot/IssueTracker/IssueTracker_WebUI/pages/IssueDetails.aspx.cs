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
	/// Summary description for IssueDetails.
	/// </summary>
	public class IssueDetails : ReflectionPage //System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox Issue_IssueID;
		protected System.Web.UI.WebControls.DropDownList Issue_TypeID;
		protected System.Web.UI.WebControls.DropDownList Issue_StatusID;
		protected System.Web.UI.WebControls.TextBox Issue_EntryDate;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList Issue_PriorityID;
		protected System.Web.UI.WebControls.TextBox Issue_Summary;
		protected System.Web.UI.WebControls.TextBox Issue_Description;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblError;

		ReferenceDataManager _DataManager = new ReferenceDataManager();
		protected System.Web.UI.WebControls.Label Label8;
		private IssueManager _Issues = new IssueManager();



		/* FIRST VERSION OF METHOD, LOAD A STATIC OBJECT  (P.198)
		private void Page_Load(object sender, System.EventArgs e)
		{
			if( IsPostBack )
			{
				//perform validation logic
			}
			else
			{
				//perform page initialization logic
				Issue myIssue = new Issue();
				myIssue.Summary = "This is test summary text.";
				myIssue.Description = "This is a detailed test description.";
				myIssue.EntryDate = new DateTime();
				myIssue.PriorityID = 3;
				myIssue.TypeID = 3;

				BusinessObject = myIssue;
	        
				ReflectBusinessObject();
			}
		}
		*/



		// SECOND VERSION OF METHOD, LOADING OBJECT FROM DATABASE
		private void Page_Load(object sender, System.EventArgs e)
		{
			//display the business object data
			BusinessObject = _Issues.GetIssue( int.Parse(Request.Params["IssueID"]) );
			ReflectBusinessObject();

			//display the reference data
			Issue_TypeID.DataSource = _DataManager.GetIssueTypes();
			Issue_TypeID.DataTextField = "TypeLabel";
			Issue_TypeID.DataValueField = "TypeID";

			Issue_StatusID.DataSource = _DataManager.GetStatuses();
			Issue_StatusID.DataTextField = "StatusLabel";
			Issue_StatusID.DataValueField = "StatusID";

			Issue_PriorityID.DataSource = _DataManager.GetPriorities();
			Issue_PriorityID.DataTextField = "PriorityLabel";
			Issue_PriorityID.DataValueField = "PriorityID";

			Page.DataBind();

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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Issue objIssue = new Issue();

			//assign business object properties
			objIssue.Description = Issue_Description.Text;
			objIssue.EntryDate = DateTime.Parse( Issue_EntryDate.Text );
			objIssue.PriorityID = int.Parse( Issue_PriorityID.SelectedValue );
			objIssue.StatusID = int.Parse( Issue_StatusID.SelectedValue );
			objIssue.Summary = Issue_Summary.Text;
			objIssue.TypeID = int.Parse( Issue_TypeID.SelectedValue );

			//validate business object
			lblError.Text = objIssue.Validate();

			if( lblError.Text.Length == 0 )
				Response.Redirect( "IssueSummary.aspx", true );

			return;
		}


		
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "IssueSummary.aspx", true );

			return;
		}

	}
}
