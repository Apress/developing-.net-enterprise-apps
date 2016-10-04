using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PocketUI
{
	/// <summary>
	/// Summary description for FormSplash.
	/// </summary>
	public class FormSplash : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timerSplash;
		private Bitmap m_bmpImage;
		private int m_intTimeElapsed = 0;
		private int m_intTimeInterval = 100;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private int m_intTimerDuration = 2000;



		//initializes the source image and timer interval
		private void FormSplash_Load(object sender, System.EventArgs e)
		{
			try
			{
				//create and initialize the bitmap object
				m_bmpImage = new Bitmap( "\\Windows\\app_splash.jpg" );

				//activate the timer 
				timerSplash.Interval = m_intTimeInterval;
				timerSplash.Enabled = true;
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}
			return;
		}

		//handles the Tick event and determines if enough time has elapsed
		private void timerSplash_Tick(object sender, System.EventArgs e)
		{
			try
			{
				//compare the elapsed time against the expected duration
				if( m_intTimeElapsed >= m_intTimerDuration )
				{
					//time is up, close the splash screen
					timerSplash.Enabled = false;
					Close();
				}
				else
				{
					//still waiting, increment the elapsed time
					m_intTimeElapsed += m_intTimeInterval;
				}
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}
			return;
		}

		//display the bitmap image
		protected override void OnPaint( PaintEventArgs e )
		{
			try
			{
				//initialize a Graphics engine object and draw the image
				Graphics graphics = e.Graphics;
				graphics.DrawImage( m_bmpImage, 1, 1 );
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}
			return;
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSplash));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 8);
			this.pictureBox1.Size = new System.Drawing.Size(208, 50);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(152, 112);
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 64);
			this.label1.Size = new System.Drawing.Size(208, 20);
			this.label1.Text = "Copyright (c) 2000-2003, Sample Co.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Size = new System.Drawing.Size(208, 20);
			this.label2.Text = "All Rights Reserved.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// FormSplash
			// 
			this.ClientSize = new System.Drawing.Size(240, 144);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.pictureBox1);
			this.Text = "About IssueTracker...";

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Close();
		}


	}
}
