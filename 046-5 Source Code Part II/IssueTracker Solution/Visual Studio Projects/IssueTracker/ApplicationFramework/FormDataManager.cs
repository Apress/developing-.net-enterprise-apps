using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DataAccess;



namespace ApplicationFramework
{
	/// <summary>
	/// Summary description for FormDataManager.
	/// </summary>
	public class FormDataManager : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.DataGrid datagridTypes;
		private System.Windows.Forms.DataGrid datagridStatuses;
		private System.Windows.Forms.DataGrid datagridPriorities;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private DataAccess.DataComponent mgrReference = new DataAccess.DataComponent();


		public FormDataManager()
		{
			InitializeComponent();
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
			this.datagridTypes = new System.Windows.Forms.DataGrid();
			this.datagridStatuses = new System.Windows.Forms.DataGrid();
			this.datagridPriorities = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.datagridTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datagridStatuses)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datagridPriorities)).BeginInit();
			this.SuspendLayout();
			// 
			// datagridTypes
			// 
			this.datagridTypes.DataMember = "";
			this.datagridTypes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.datagridTypes.Location = new System.Drawing.Point(8, 32);
			this.datagridTypes.Name = "datagridTypes";
			this.datagridTypes.Size = new System.Drawing.Size(184, 248);
			this.datagridTypes.TabIndex = 0;
			// 
			// datagridStatuses
			// 
			this.datagridStatuses.DataMember = "";
			this.datagridStatuses.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.datagridStatuses.Location = new System.Drawing.Point(208, 32);
			this.datagridStatuses.Name = "datagridStatuses";
			this.datagridStatuses.Size = new System.Drawing.Size(184, 248);
			this.datagridStatuses.TabIndex = 1;
			// 
			// datagridPriorities
			// 
			this.datagridPriorities.DataMember = "";
			this.datagridPriorities.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.datagridPriorities.Location = new System.Drawing.Point(408, 32);
			this.datagridPriorities.Name = "datagridPriorities";
			this.datagridPriorities.Size = new System.Drawing.Size(184, 248);
			this.datagridPriorities.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 3;
			this.label1.Text = "Types";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(208, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "Statuses";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(408, 8);
			this.label3.Name = "label3";
			this.label3.TabIndex = 5;
			this.label3.Text = "Priorities";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(424, 288);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(512, 288);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			// 
			// FormDataManager
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 318);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.datagridPriorities);
			this.Controls.Add(this.datagridStatuses);
			this.Controls.Add(this.datagridTypes);
			this.Name = "FormDataManager";
			this.Text = "FormDataManager";
			this.Load += new System.EventHandler(this.FormDataManager_Load);
			((System.ComponentModel.ISupportInitialize)(this.datagridTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datagridStatuses)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datagridPriorities)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion



		private void FormDataManager_Load(object sender, System.EventArgs e)
		{
			datagridTypes.DataSource = mgrReference.GetEntireDataSet();
			datagridTypes.DataMember = "Val_IssueType";

			datagridStatuses.DataSource = mgrReference.GetEntireDataSet();
			datagridStatuses.DataMember = "Val_IssueType";

			datagridPriorities.DataSource = mgrReference.GetEntireDataSet();
			datagridPriorities.DataMember = "Val_IssueType";

			return;
		}

	
	}
}
