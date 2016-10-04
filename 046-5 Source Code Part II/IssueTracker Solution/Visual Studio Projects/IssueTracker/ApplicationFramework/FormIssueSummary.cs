using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using ApplicationFramework;
using BusinessRules;
using BusinessFacade;



namespace ApplicationFramework
{
	/// <summary>
	/// Summary description for FormIssueSummary.
	/// </summary>
	public class FormIssueSummary : FrameworkViewer //System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lstIssues;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;



		public FormIssueSummary()
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
			this.lstIssues = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lstIssues
			// 
			this.lstIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.lstIssues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstIssues.GridLines = true;
			this.lstIssues.Location = new System.Drawing.Point(0, 0);
			this.lstIssues.Name = "lstIssues";
			this.lstIssues.Size = new System.Drawing.Size(424, 374);
			this.lstIssues.TabIndex = 1;
			this.lstIssues.View = System.Windows.Forms.View.Details;
			this.lstIssues.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstIssues_MouseDown);
			this.lstIssues.Click += new System.EventHandler(this.lstIssues_DoubleClick);
			this.lstIssues.DoubleClick += new System.EventHandler(this.lstIssues_DoubleClick);
			this.lstIssues.DragLeave += new System.EventHandler(this.lstIssues_DragLeave);
			this.lstIssues.SelectedIndexChanged += new System.EventHandler(this.lstIssues_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Issue Summary";
			this.columnHeader1.Width = 420;
			// 
			// FormIssueSummary
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 374);
			this.Controls.Add(this.lstIssues);
			this.Name = "FormIssueSummary";
			this.Text = "Issue Summary";
			this.Load += new System.EventHandler(this.FormIssueSummary_Load);
			this.ResumeLayout(false);

		}
		#endregion



		private void FormIssueSummary_Load(object sender, System.EventArgs e)
		{
			IssueManager mgrIssues = new IssueManager();
			IssueCollection collIssues = mgrIssues.GetAllIssues();

			foreach( Issue issueItem in collIssues )
			{
				//store the description as a listviewitem
				ListViewItem item = new ListViewItem( issueItem.Summary );

				//store the reference id as a subitem
				item.SubItems.Add( issueItem.IssueID.ToString() );

				//add the listviewitem to the listview control
				lstIssues.Items.Add( item );
			}

			return;
		}



		private void FormIssueSummary_Load_1(object sender, System.EventArgs e)
		{
			IssueManager mgrIssues = new IssueManager();
			IssueCollection collIssues = mgrIssues.GetAllIssues();

			foreach( Issue issueItem in collIssues )
			{
				lstIssues.Items.Add( issueItem.Summary );
			}

			return;
		}



		private void lstIssues_DoubleClick(object sender, System.EventArgs e)
		{
			if( lstIssues.SelectedItems[0].SubItems[1] != null )
			{
				Issue myIssue = new Issue();
				myIssue.IssueID = int.Parse( lstIssues.SelectedItems[0].SubItems[1].Text );

				Controller.Process( myIssue, Controller.ControllerActions.View );
			}
			else
			{
				MessageBox.Show( this, "Invalid selection, please try again." );
			}

			return;
		}



		private void lstIssues_DoubleClick_1(object sender, System.EventArgs e)
		{
			//call a really long process...
			Thread threadProcess = new Thread( new ThreadStart( StallForTime ));
			threadProcess.Start();

			Issue myIssue = new Issue();
			myIssue.IssueID = 101;

			Controller.Process( myIssue, Controller.ControllerActions.View );
		}

		

		private void lstIssues_DoubleClick_2(object sender, System.EventArgs e)
		{
			//call a really long process...
			StallForTime();

			Issue myIssue = new Issue();
			myIssue.IssueID = 101;

			Controller.Process( myIssue, Controller.ControllerActions.View );
		}


		
		private void lstIssues_DoubleClick_3(object sender, System.EventArgs e)
		{
			Issue myIssue = new Issue();
			myIssue.IssueID = 101;

			Controller.Process( myIssue, Controller.ControllerActions.View );
		}



		public void StallForTime()
		{
			for( int i = 0; i < 100000; i++ )
			{
				for( int j = 0; j < 100000; j++ )
					;
			}
			System.Diagnostics.Debug.WriteLine( "Finished!" );
		}



		private void lstIssues_MouseDown( object sender,
			System.Windows.Forms.MouseEventArgs e )
		{
//			ListViewItem itemSelected = lstIssues.SelectedItems[0];
//
//			lstIssues.DoDragDrop( itemSelected.SubItems[0].Text, 
//				System.Windows.Forms.DragDropEffects.Copy );

			if( lstIssues.SelectedItems.Count > 0 )
			{
				ListViewItem itemSelected = lstIssues.SelectedItems[0];

				lstIssues.DoDragDrop( itemSelected.SubItems[0].Text, 
					System.Windows.Forms.DragDropEffects.Copy );
			}
			return;
		}



//		private void lstIssues_DragLeave( object sender,
//			System.Windows.Forms.MouseEventArgs e )
		private void lstIssues_DragLeave( object sender,
			System.EventArgs e )
		{
			ListViewItem itemSelected = lstIssues.SelectedItems[0];

			lstIssues.DoDragDrop( itemSelected.SubItems[0].Text, 
				System.Windows.Forms.DragDropEffects.Copy );

			return;
		}

		private void lstIssues_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

	
	
	}
}
