using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinUI
{
	/// <summary>
	/// Summary description for FormAbout.
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAbout()
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
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(344, 136);
			this.label1.TabIndex = 0;
			this.label1.Text = @"The purpose of this sample application is to demonstrate a variety of capabilities that can be accomplished in a .NET WinForms application. Some examples include the ability to deploy child forms separately from the main application. This is one way that you can create a 'plug-in' framework for your application. Other examples include localization, using the CrystalReports viewer, and accessing the business object manager for selecting records.   No application framework is perfect for all applications; please review your product requirements to be sure that a MVC architecture is right for your application.";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(272, 144);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// FormAbout
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 176);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About this Sample";
			this.ResumeLayout(false);

		}
		#endregion



		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
