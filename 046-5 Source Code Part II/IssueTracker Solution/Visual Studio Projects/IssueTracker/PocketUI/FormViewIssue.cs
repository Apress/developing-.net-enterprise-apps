using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;



namespace PocketUI
{
	/// <summary>
	/// Summary description for FormNewIssue.
	/// </summary>
	public class FormViewIssue : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;

		private string m_strPassword;
		private System.Windows.Forms.TextBox txtSummary;
		private System.Windows.Forms.ComboBox lblPriority;
		private System.Windows.Forms.ComboBox lblType;
		private int m_intIssueID;

	
		public FormViewIssue()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.ComboBox();
			this.lblPriority = new System.Windows.Forms.ComboBox();
			this.txtSummary = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Size = new System.Drawing.Size(40, 20);
			this.label1.Text = "Type:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 32);
			this.label2.Text = "Priority:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 56);
			this.label3.Text = "Summary:";
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(64, 8);
			this.lblType.Size = new System.Drawing.Size(168, 22);
			// 
			// lblPriority
			// 
			this.lblPriority.Location = new System.Drawing.Point(64, 32);
			this.lblPriority.Size = new System.Drawing.Size(168, 22);
			// 
			// txtSummary
			// 
			this.txtSummary.Location = new System.Drawing.Point(64, 56);
			this.txtSummary.Multiline = true;
			this.txtSummary.Size = new System.Drawing.Size(168, 160);
			this.txtSummary.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(64, 224);
			this.btnOK.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(160, 224);
			this.btnCancel.Text = "Cancel";
			// 
			// FormViewIssue
			// 
			this.ClientSize = new System.Drawing.Size(240, 293);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtSummary);
			this.Controls.Add(this.lblPriority);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Text = "View Issue";
			this.Load += new System.EventHandler(this.FormViewIssue_Load);

		}
		#endregion

		private void FormViewIssue_Load( object sender, System.EventArgs e )
		{
			try
			{
				//instantiate the Web service proxy
				IssueService.IssueServices webserviceIssue =
					new IssueService.IssueServices();

				//invoke the Web service method
				string strResponse = webserviceIssue.GetSpecificIssue( m_strPassword,
					m_intIssueID );

				//initialize a new DataSet
				DataSet dsIssue = new DataSet();

				//initialize an XmlTextReader with the Web service results
				XmlTextReader xreader = new XmlTextReader( strResponse,
					XmlNodeType.Element, null );

				//feed the Web service response to the DataSet
				dsIssue.ReadXml( xreader );

				//Set the display fields based on values within the DataSet
				lblPriority.Text = 
					dsIssue.Tables["Dat_Issue"].Rows[0]["PriorityLabel"].ToString();
				lblType.Text =
					dsIssue.Tables["Dat_Issue"].Rows[0]["TypeLabel"].ToString();
				txtSummary.Text =
					dsIssue.Tables["Dat_Issue"].Rows[0]["Summary"].ToString();
//				lblAuthor.Text =
//					dsIssue.Tables["Dat_Issue"].Rows[0]["Lastname"].ToString().Trim() +
//					", " + 
//					dsIssue.Tables["Dat_Issue"].Rows[0]["Firstname"].ToString().Trim();
//				txtDescription.Text = 
//					dsIssue.Tables["Dat_Issue"].Rows[0]["Description"].ToString();
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}

			return;
		}

	}
}
