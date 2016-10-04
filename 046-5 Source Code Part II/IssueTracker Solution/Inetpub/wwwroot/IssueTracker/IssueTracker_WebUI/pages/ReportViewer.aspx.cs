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
using EnterpriseReports;



namespace WebUI.pages
{
	/// <summary>
	/// Summary description for ReportViewer.
	/// </summary>
	public class ReportViewer : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer reportViewer1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			OpenIssuesReport cachedOpenIssuesReport = new OpenIssuesReport();
			reportViewer1.ReportSource = cachedOpenIssuesReport;
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
