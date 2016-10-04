using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;



namespace WinUI
{
	/// <summary>
	/// Summary description for FormLogin.
	/// </summary>
	public class FormLogin : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edtEmail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtPassword;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		private bool m_boolLoggedIn = false;
		private string m_strAccessKey = "";



		public FormLogin()
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
			this.label1 = new System.Windows.Forms.Label();
			this.edtEmail = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.edtPassword = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "E-mail Address:";
			// 
			// edtEmail
			// 
			this.edtEmail.Location = new System.Drawing.Point(96, 8);
			this.edtEmail.Name = "edtEmail";
			this.edtEmail.Size = new System.Drawing.Size(176, 20);
			this.edtEmail.TabIndex = 1;
			this.edtEmail.Text = "TestUser";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password:";
			// 
			// edtPassword
			// 
			this.edtPassword.Location = new System.Drawing.Point(96, 40);
			this.edtPassword.Name = "edtPassword";
			this.edtPassword.PasswordChar = '*';
			this.edtPassword.Size = new System.Drawing.Size(176, 20);
			this.edtPassword.TabIndex = 3;
			this.edtPassword.Text = "TestPassword";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(120, 72);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(200, 72);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FormLogin
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(282, 104);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.edtPassword);
			this.Controls.Add(this.edtEmail);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormLogin";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Issue Tracker Login";
			this.ResumeLayout(false);

		}
		#endregion


		
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}



		private void btnOK_Click(object sender, System.EventArgs e)
		{

			//validate login via web service
			string strWebServiceResponse = "";

//			net.mynamespace.www.LoginServices wsLogin = new net.mynamespace.www.LoginServices();
//
//			strWebServiceResponse = wsLogin.ValidateLogin( edtEmail.Text, edtPassword.Text );
//
//			if( strWebServiceResponse.StartsWith( "ERR" ) == false )
//			{
				m_strAccessKey = strWebServiceResponse;
				m_boolLoggedIn = true;
				DialogResult = DialogResult.OK;
				Close();
//			}
//			else
//			{
//				System.Windows.Forms.MessageBox.Show( "Login Failed." );
//				DialogResult = DialogResult.Cancel;
//			}

			return;

		}



	}
}
