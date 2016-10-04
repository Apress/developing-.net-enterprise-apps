using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;



namespace WinUI
{
	/// <summary>
	/// Summary description for ReportViewer.
	/// </summary>
	public class ReportViewer : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer reportViewer1;
		private System.Windows.Forms.Button btnPrevPage;
		private System.Windows.Forms.Button btnNextPage;
		private System.ComponentModel.Container components = null;
		private string _ReportSource = @"D:\My Documents\Visual Studio Projects\IssueTracker\EnterpriseReports\OpenIssuesReport.rpt";



		public ReportViewer()
		{
			InitializeComponent();
			reportViewer1.ReportSource = _ReportSource;
		}



		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}



		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.reportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.btnPrevPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.ActiveViewIndex = -1;
			this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.reportViewer1.DisplayBackgroundEdge = false;
			this.reportViewer1.DisplayGroupTree = false;
			this.reportViewer1.DisplayToolbar = false;
			this.reportViewer1.Location = new System.Drawing.Point(0, 32);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ReportSource = "D:\\My Documents\\Visual Studio Projects\\IssueTracker\\EnterpriseReports\\OpenIssuesR" +
				"eport.rpt";
			this.reportViewer1.ShowCloseButton = false;
			this.reportViewer1.ShowExportButton = false;
			this.reportViewer1.ShowGotoPageButton = false;
			this.reportViewer1.ShowGroupTreeButton = false;
			this.reportViewer1.ShowPageNavigateButtons = false;
			this.reportViewer1.ShowPrintButton = false;
			this.reportViewer1.ShowRefreshButton = false;
			this.reportViewer1.ShowTextSearchButton = false;
			this.reportViewer1.ShowZoomButton = false;
			this.reportViewer1.Size = new System.Drawing.Size(440, 328);
			this.reportViewer1.TabIndex = 0;
			// 
			// btnPrevPage
			// 
			this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnPrevPage.Location = new System.Drawing.Point(360, 8);
			this.btnPrevPage.Name = "btnPrevPage";
			this.btnPrevPage.Size = new System.Drawing.Size(32, 23);
			this.btnPrevPage.TabIndex = 1;
			this.btnPrevPage.Text = "<<";
			this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
			// 
			// btnNextPage
			// 
			this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNextPage.Location = new System.Drawing.Point(400, 8);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(32, 23);
			this.btnNextPage.TabIndex = 2;
			this.btnNextPage.Text = ">>";
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// ReportViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 366);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.btnPrevPage);
			this.Controls.Add(this.reportViewer1);
			this.Name = "ReportViewer";
			this.Text = "ReportViewer";
			this.ResumeLayout(false);

		}
		#endregion



		public string ReportPath
		{
			set
			{
				_ReportSource = value;
				reportViewer1.ReportSource = value;
			}
		}



		private void btnPrevPage_Click(object sender, System.EventArgs e)
		{
			reportViewer1.ShowPreviousPage();
		}



		private void btnNextPage_Click(object sender, System.EventArgs e)
		{
			reportViewer1.ShowNextPage();
		}



	}
}
