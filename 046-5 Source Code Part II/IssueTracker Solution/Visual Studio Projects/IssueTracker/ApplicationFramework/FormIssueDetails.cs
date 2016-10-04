using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ApplicationFramework;
using BusinessRules;
using BusinessFacade;



namespace ApplicationFramework
{
	/// <summary>
	/// Summary description for FormIssueDetails.
	/// </summary>
	public class FormIssueDetails :  FrameworkViewer //System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtSummary;
		private System.Windows.Forms.ComboBox cboPriority;
		private System.Windows.Forms.ComboBox cboStatus;
		private System.Windows.Forms.ComboBox cboType;
		private System.Windows.Forms.TextBox txtEntryDate;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnNext;
		IssueManager managerIssue = new IssueManager();
		private int m_intIssueID = 0;



		public FormIssueDetails()
		{
			InitializeComponent();
		}


		public void SetIssueID( int argIssueID )
		{
			m_intIssueID = argIssueID;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtEntryDate = new System.Windows.Forms.TextBox();
			this.cboType = new System.Windows.Forms.ComboBox();
			this.cboStatus = new System.Windows.Forms.ComboBox();
			this.cboPriority = new System.Windows.Forms.ComboBox();
			this.txtSummary = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Issue Details";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Entry Date:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Issue Type:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.TabIndex = 3;
			this.label4.Text = "Issue Status:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 144);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "Issue Priority:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 176);
			this.label6.Name = "label6";
			this.label6.TabIndex = 5;
			this.label6.Text = "Issue Summary:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 208);
			this.label7.Name = "label7";
			this.label7.TabIndex = 6;
			this.label7.Text = "Issue Description:";
			// 
			// txtEntryDate
			// 
			this.txtEntryDate.Location = new System.Drawing.Point(112, 48);
			this.txtEntryDate.Name = "txtEntryDate";
			this.txtEntryDate.Size = new System.Drawing.Size(120, 20);
			this.txtEntryDate.TabIndex = 7;
			this.txtEntryDate.Text = "";
			// 
			// cboType
			// 
			this.cboType.Location = new System.Drawing.Point(112, 80);
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(121, 21);
			this.cboType.TabIndex = 8;
			// 
			// cboStatus
			// 
			this.cboStatus.Location = new System.Drawing.Point(112, 112);
			this.cboStatus.Name = "cboStatus";
			this.cboStatus.Size = new System.Drawing.Size(121, 21);
			this.cboStatus.TabIndex = 9;
			// 
			// cboPriority
			// 
			this.cboPriority.Location = new System.Drawing.Point(112, 144);
			this.cboPriority.Name = "cboPriority";
			this.cboPriority.Size = new System.Drawing.Size(121, 21);
			this.cboPriority.TabIndex = 10;
			// 
			// txtSummary
			// 
			this.txtSummary.Location = new System.Drawing.Point(112, 176);
			this.txtSummary.Name = "txtSummary";
			this.txtSummary.Size = new System.Drawing.Size(296, 20);
			this.txtSummary.TabIndex = 11;
			this.txtSummary.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(112, 208);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(296, 144);
			this.txtDescription.TabIndex = 12;
			this.txtDescription.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(256, 360);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(336, 360);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnBack
			// 
			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBack.Location = new System.Drawing.Point(344, 16);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(32, 23);
			this.btnBack.TabIndex = 15;
			this.btnBack.Text = "<<";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnNext
			// 
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNext.Location = new System.Drawing.Point(384, 16);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(32, 23);
			this.btnNext.TabIndex = 16;
			this.btnNext.Text = ">>";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// FormIssueDetails
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(416, 390);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtSummary);
			this.Controls.Add(this.txtEntryDate);
			this.Controls.Add(this.cboPriority);
			this.Controls.Add(this.cboStatus);
			this.Controls.Add(this.cboType);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormIssueDetails";
			this.Text = "Issue Details";
			this.Load += new System.EventHandler(this.FormIssueDetails_Load);
			this.ResumeLayout(false);

		}
		#endregion



		private void FormIssueDetails_Load(object sender, System.EventArgs e)
		{
			//reference the application's DataSet object
			ReferenceDataManager mgrReference = new ReferenceDataManager();

			//bind the validation data
			cboPriority.DataSource = mgrReference.GetPriorities();
			cboPriority.DisplayMember = "PriorityLabel";
			cboPriority.ValueMember = "PriorityID";

			cboType.DataSource = mgrReference.GetIssueTypes();
			cboType.DisplayMember = "TypeLabel";
			cboType.ValueMember = "TypeID";

			cboStatus.DataSource = mgrReference.GetStatuses();
			cboStatus.DisplayMember = "StatusLabel";
			cboStatus.ValueMember = "StatusID";

			txtEntryDate.Text = DateTime.Now.ToString();


			if( _ViewMode == Controller.ControllerActions.View ||
				_ViewMode == Controller.ControllerActions.Edit )
			{
				Issue issue = managerIssue.GetIssue( ((Issue)BusinessObject).IssueID );

				txtEntryDate.DataBindings.Add( "Text", issue, "EntryDate" );
				cboType.DataBindings.Add( "Text", issue, "TypeID" );
				cboStatus.DataBindings.Add( "Text", issue, "StatusID" );
				cboPriority.DataBindings.Add( "Text", issue, "PriorityID" );
				txtSummary.DataBindings.Add( "Text", issue, "Summary" );
				txtDescription.DataBindings.Add( "Text", issue, "Description" );
			}

			return;
		}


		
		private void FormIssueDetails_Load_1(object sender, System.EventArgs e)
		{
			IssueManager managerIssue = new IssueManager();
			Issue issue = managerIssue.GetIssue( m_intIssueID );

			txtEntryDate.DataBindings.Add( "Text", issue, "EntryDate" );
			cboType.DataBindings.Add( "Text", issue, "TypeID" );
			cboStatus.DataBindings.Add( "Text", issue, "StatusID" );
			cboPriority.DataBindings.Add( "Text", issue, "PriorityID" );
			txtSummary.DataBindings.Add( "Text", issue, "Summary" );
			txtDescription.DataBindings.Add( "Text", issue, "Description" );

			return;
		}



		private void btnBack_Click(object sender, System.EventArgs e)
		{
//			BindingContext[managerIssue].Position--;
			BindingContext[managerIssue].Position--;
			return;
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
//			BindingContext[managerIssue].Position++;
			BindingContext[managerIssue].Position++;
			return;
		}



		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Close();
		
		}



		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

	
	
	}
}
