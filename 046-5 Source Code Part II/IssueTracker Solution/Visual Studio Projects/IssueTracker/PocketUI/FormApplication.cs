using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;



namespace PocketUI
{
	/// <summary>
	/// Summary description for FormApplication.
	/// </summary>
	public class FormApplication : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.MenuItem menuViewIssues;
		private System.Windows.Forms.ListView lstViewer;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuViewUsers;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.MainMenu mainMenu1;



		public FormApplication()
		{
			InitializeComponent();
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuViewIssues = new System.Windows.Forms.MenuItem();
			this.menuViewUsers = new System.Windows.Forms.MenuItem();
			this.menuAbout = new System.Windows.Forms.MenuItem();
			this.lstViewer = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			this.mainMenu1.MenuItems.Add(this.menuItem2);
			this.mainMenu1.MenuItems.Add(this.menuAbout);
			// 
			// menuItem1
			// 
			this.menuItem1.MenuItems.Add(this.menuFileExit);
			this.menuItem1.Text = "File";
			// 
			// menuFileExit
			// 
			this.menuFileExit.Text = "Exit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.MenuItems.Add(this.menuViewIssues);
			this.menuItem2.MenuItems.Add(this.menuViewUsers);
			this.menuItem2.Text = "View";
			// 
			// menuViewIssues
			// 
			this.menuViewIssues.Text = "Issues";
			this.menuViewIssues.Click += new System.EventHandler(this.menuViewIssues_Click);
			// 
			// menuViewUsers
			// 
			this.menuViewUsers.Text = "Users";
			// 
			// menuAbout
			// 
			this.menuAbout.Text = "About...";
			this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
			// 
			// lstViewer
			// 
			this.lstViewer.Columns.Add(this.columnHeader1);
			this.lstViewer.Columns.Add(this.columnHeader2);
			this.lstViewer.Columns.Add(this.columnHeader3);
			this.lstViewer.Size = new System.Drawing.Size(240, 272);
			this.lstViewer.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 60;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Priority";
			this.columnHeader2.Width = 60;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Summary";
			this.columnHeader3.Width = 117;
			// 
			// FormApplication
			// 
			this.Controls.Add(this.lstViewer);
			this.Menu = this.mainMenu1;
			this.Text = "IssueTracker";

		}
		#endregion



		static void Main() 
		{
			FormSplash dlgSplash = new FormSplash();
			dlgSplash.ShowDialog();
			Application.Run(new FormApplication());
		}



		private void menuViewIssues_Click(object sender, System.EventArgs e)
		{
			string strResponse;
			ListViewItem listItem;

			//prepare the ListView control, initially hidden from user
			lstViewer.Items.Clear();
			lstViewer.Visible = true;

			try
			{
				//create and populate a new DataSet
				DataSet datasetIssues = new DataSet();
				datasetIssues.ReadXml( "\\Windows\\issues.xml" );

				//iterate through the rows to populate the ListView control
				foreach( DataRow row in datasetIssues.Tables["Dat_Issue"].Rows )
				{
					listItem = new ListViewItem();

					listItem.Text = row["IssueID"].ToString();
					listItem.SubItems.Add( row["PriorityID"].ToString() );
					listItem.SubItems.Add( row["Summary"].ToString() );

					//add the created entry to the ListView control
					lstViewer.Items.Add( listItem );
				}

			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}

			return;
		
		}



		private void CreateSqlDatabase()
		{
			//specify the location of the local device database
			string strDataPath = "\\My Documents\\IssueTracker.sdf";

			try
			{
				//check to determine of local device database already exists    
				if( ! System.IO.File.Exists( strDataPath ) )
				{
					//define a connection string and create the device database file
					SqlCeEngine engine = new SqlCeEngine( "Data Source=" + strDataPath );
					engine.CreateDatabase();
				}
			}
			catch( SqlCeException x )
			{
				MessageBox.Show( x.Message );
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}

			return;
		}



		private void SynchronizeSqlDatabase()
		{
			//specify the location of the local device database
			string strDataPath = "\\My Documents\\IssueTracker.sdf";

			//create the data replication object
			SqlCeReplication replication = new SqlCeReplication();

			try
			{
				//define the source of the replication data
				replication.Publisher = "server_name";
				replication.PublisherDatabase = "IssueTracker"; //database name
				replication.Publication = "IssueTrackerPublication";

				//define the login credentials
				replication.PublisherLogin = "sa";
				replication.PublisherPassword = "";

				//define the subscriber-side connection string
				replication.SubscriberConnectionString = 
					"Provider=Microsoft.SQLServer.OLEDB.CE.2.0;"  +
					"Data Source=" + strDataPath;

				replication.Subscriber = "iPAQ Mobile Device";

				//define the location of the IIS replication service agent
				replication.InternetUrl = "http://jkanalakis/sqlce/ssceca20.dll";

				//define the replication mode and begin the process
				replication.ExchangeType = ExchangeType.BiDirectional;
				replication.Synchronize();
			}
			catch( SqlCeException x )
			{
				MessageBox.Show( x.Message );
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}

			return;
		}


		private void DisplayIssues()
		{
			string strDataPath = "\\My Documents\\IssueTracker.sdf";
			ListViewItem listItem;

			//create the connection object
			SqlCeConnection conn = new SqlCeConnection( "Data Source=" + strDataPath );

			try
			{
				//open the device database connection
				conn.Open();

				//create and initialize the command
				SqlCeCommand command = conn.CreateCommand();
				command.CommandText = "SELECT IssueID, PriorityID, RTRIM(Summary) " +
					"FROM Dat_Issues ORDER BY IssueID";

				//execute the query
				SqlCeDataReader reader = command.ExecuteReader();

				//build the display list
				lstViewer.Items.Clear();
				while( reader.Read() )
				{
					//build the display list row entries
					listItem = new ListViewItem();
					listItem.Text = reader.GetInt32(0).ToString();
					listItem.SubItems.Add( reader.GetInt16(1).ToString() );
					listItem.SubItems.Add( reader.GetString(3) );

					lstViewer.Items.Add( listItem );
				}

			}
			catch( SqlCeException x )
			{
				MessageBox.Show( x.Message );
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message );
			}
			finally
			{
				//close the database connection
				conn.Close();
			}

			return;
		}



		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}



		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout dlgAbout = new FormAbout();
			dlgAbout.ShowDialog();

			return;
		}



	}
}
