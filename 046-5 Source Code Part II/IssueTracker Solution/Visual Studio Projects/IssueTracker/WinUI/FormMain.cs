using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using Microsoft.Win32;
using System.Threading;
using ApplicationFramework;
using BusinessRules;
using BusinessFacade;



namespace WinUI
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer Timer1;
		private System.Windows.Forms.StatusBar statusbar;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuIssues;
		private System.Windows.Forms.MenuItem menuUsers;
		private System.Windows.Forms.MenuItem menuSettings;
		private System.Windows.Forms.MenuItem menuSettingsShowTime;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuHelpContents;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		private System.Windows.Forms.MenuItem menuReport;
		private FormIssueDetails dlgViewIssue = new FormIssueDetails();


		public FormMain()
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
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.statusbar = new System.Windows.Forms.StatusBar();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuIssues = new System.Windows.Forms.MenuItem();
			this.menuUsers = new System.Windows.Forms.MenuItem();
			this.menuReport = new System.Windows.Forms.MenuItem();
			this.menuSettings = new System.Windows.Forms.MenuItem();
			this.menuSettingsShowTime = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpContents = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// Timer1
			// 
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// statusbar
			// 
			this.statusbar.Location = new System.Drawing.Point(0, 424);
			this.statusbar.Name = "statusbar";
			this.statusbar.Size = new System.Drawing.Size(528, 22);
			this.statusbar.TabIndex = 1;
			// 
			// imageList
			// 
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuIssues,
																					 this.menuUsers,
																					 this.menuReport,
																					 this.menuSettings,
																					 this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFileExit});
			this.menuFile.Text = "&File";
			// 
			// menuFileExit
			// 
			this.menuFileExit.Index = 0;
			this.menuFileExit.Text = "E&xit";
			this.menuFileExit.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuIssues
			// 
			this.menuIssues.Index = 1;
			this.menuIssues.Text = "&Issues";
			this.menuIssues.Click += new System.EventHandler(this.menuIssues_Click);
			// 
			// menuUsers
			// 
			this.menuUsers.Index = 2;
			this.menuUsers.Text = "&Users";
			// 
			// menuReport
			// 
			this.menuReport.Index = 3;
			this.menuReport.Text = "Report";
			this.menuReport.Click += new System.EventHandler(this.menuReport_Click);
			// 
			// menuSettings
			// 
			this.menuSettings.Index = 4;
			this.menuSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuSettingsShowTime});
			this.menuSettings.Text = "&Settings";
			// 
			// menuSettingsShowTime
			// 
			this.menuSettingsShowTime.Index = 0;
			this.menuSettingsShowTime.Text = "Show &Time In Statusbar";
			this.menuSettingsShowTime.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 5;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuHelpContents,
																					 this.menuItem3,
																					 this.menuHelpAbout});
			this.menuHelp.Text = "&Help";
			// 
			// menuHelpContents
			// 
			this.menuHelpContents.Index = 0;
			this.menuHelpContents.Text = "Contents";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Index = 2;
			this.menuHelpAbout.Text = "About...";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 446);
			this.Controls.Add(this.statusbar);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu;
			this.Name = "FormMain";
			this.Text = "IssueTracker Enterprise Desktop";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
			this.ResumeLayout(false);

		}
		#endregion



		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//Enable XP visual styles
			Application.EnableVisualStyles();
			Application.DoEvents();

			
			FormLogin login = new FormLogin();

			if( login.ShowDialog() == DialogResult.OK )
			{
				Application.Run(new FormMain());
			}
		}



		private void FormMain_Load(object sender, System.EventArgs e)
		{
			RegistryKey  regkeyAppRoot =
				Registry.CurrentUser.CreateSubKey("Software\\IssueTracker\\Settings");

			String strWindowState = (String)regkeyAppRoot.GetValue("WindowState");

			if( strWindowState != null && strWindowState.CompareTo("Maximized") == 0 )
				WindowState = System.Windows.Forms.FormWindowState.Maximized;

			else if(strWindowState != null && strWindowState.CompareTo("Minimized") == 0)
				WindowState = FormWindowState.Minimized;

			else
				WindowState = FormWindowState.Normal;

			IssueCollection myColl = new IssueCollection();
			Controller.ParentForm = this;
			Controller.Process( myColl, Controller.ControllerActions.View );

			return;
		}

		

		private void FormMain_Load_1( object sender, System.EventArgs e )
		{
			IssueCollection myColl = new IssueCollection();
			Controller.Process( myColl, Controller.ControllerActions.View );
			
			return;
		}

		
		
		private void FormMain_Load_2( object sender, System.EventArgs e )
		{
			FormIssueSummary dlgSummary = new FormIssueSummary();
			dlgSummary.MdiParent = this;
			dlgSummary.Show();

			return;
		}



		private void InitializeTimer()
		{
			Timer1.Interval = 1000;
			Timer1.Enabled = true;
		}



		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			String strDateOutput = "";
			DateTime dateNow = DateTime.Now;

			// Sets the CurrentCulture property to U.S. English.
			Thread.CurrentThread.CurrentCulture = new CultureInfo( "en-US" );

			//display time
			strDateOutput = dateNow.ToShortTimeString();

			// Displays dt, formatted using the ShortDatePattern
			// and the CurrentThread.CurrentCulture.
			strDateOutput += " -       US Date Format: " + dateNow.ToString( "d" );
      
			// Creates a CultureInfo for German in Germany.
			CultureInfo cultureinfo = new CultureInfo( "de-DE" );

			// Displays dt, formatted using the ShortDatePattern
			// and the CultureInfo.
			strDateOutput += " & German Date Format: " + dateNow.ToString( "d", cultureinfo );

			//statusbar.Panels[0].Text = strDateOutput;

			statusbar.Text = strDateOutput;

			return;
		}



		public void DisplayReminderMessage()
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

			DateTime dateNow = DateTime.Now;
			dateNow = dateNow.AddDays(30);

			MessageBox.Show( "A 30 Day reminder will be sent on: " + 
				dateNow.ToString("d") );

			return;
		}
		
		
		
		public String GetFormattedCurrency( int intAmount, String strCulture )
		{
			CultureInfo culture = new CultureInfo( strCulture );

			return intAmount.ToString( "c", culture );
		}
		
		
		
		private void Timer1_Tick_1( object Sender, EventArgs e )
		{
			statusbar.Text = "Current Time: " + DateTime.Now.ToLongTimeString();
		}

		
		
		private void FormMain_DragEnter( object sender, 
			System.Windows.Forms.DragEventArgs e )
		{
			if( e.Data.GetDataPresent( DataFormats.Text ) ) 
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
			return;
		}

		
		
		private void FormMain_DragDrop( object sender, 
			System.Windows.Forms.DragEventArgs e )
		{
			//close the active MDI child
			if( this.ActiveMdiChild != null )
				this.ActiveMdiChild.Close();

			//initialize the new MDI child
			this.dlgViewIssue = new FormIssueDetails();
			dlgViewIssue.MdiParent = this;
			dlgViewIssue.Dock = System.Windows.Forms.DockStyle.Fill;

			//supply the IssueID carried through the Drag process
			dlgViewIssue.SetIssueID( int.Parse( e.Data.GetData( 
				DataFormats.Text ).ToString() ) );

			//display the new MDI child
			dlgViewIssue.Show();

			return;
		}



		private void FormMain_Closing( object sender, 
			System.ComponentModel.CancelEventArgs e )
		{
			//save the window state
			String strPath = "Software\\IssueTracker\\Settings";
			String strWindowState = "";

			RegistryKey  regkeyAppRoot = Registry.CurrentUser.CreateSubKey( strPath );

			if( WindowState == FormWindowState.Maximized )
				strWindowState = "Maximized";

			else if( WindowState == FormWindowState.Minimized )
				strWindowState = "Minimized";

			else
				strWindowState = "Normal";

			regkeyAppRoot.SetValue( "WindowState", strWindowState );

			return;
		}



		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Close();
		}



		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			InitializeTimer();
		}



		private void menuIssues_Click(object sender, System.EventArgs e)
		{
			IssueCollection myColl = new IssueCollection();
			Controller.ParentForm = this;
			Controller.Process( myColl, Controller.ControllerActions.View );
		}



		private void menuReport_Click(object sender, System.EventArgs e)
		{
			ReportViewer dlgReports = new ReportViewer();
			dlgReports.ShowDialog();
			return;
		}



		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout dlgAbout = new FormAbout();
			dlgAbout.ShowDialog();

			return;
		}

		
		
	}
}
