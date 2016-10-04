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
	public class FormAbout : System.Windows.Forms.Form
	{
		private Bitmap m_bmpImage;
		private System.Windows.Forms.PictureBox pictureBox1;


//		//display the bitmap image
//		protected override void OnPaint( PaintEventArgs e )
//		{
//			try
//			{
//				//initialize a Graphics engine object and draw the image
//				Graphics graphics = e.Graphics;
//				graphics.DrawImage( m_bmpImage, 1, 1 );
//			}
//			catch( Exception x )
//			{
//				MessageBox.Show( x.Message );
//			}
//			return;
//		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSplash));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 56);
			this.pictureBox1.Size = new System.Drawing.Size(208, 50);
			// 
			// FormSplash
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(58)), ((System.Byte)(105)), ((System.Byte)(133)));
			this.Controls.Add(this.pictureBox1);
			this.Text = "IssueTracker";

		}
		#endregion
	}
}
