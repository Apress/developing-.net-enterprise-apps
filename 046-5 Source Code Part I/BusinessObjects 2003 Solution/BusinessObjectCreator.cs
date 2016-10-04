using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data;
using System.IO;



namespace BusinessObjectJumpStart
{
	
	/// <summary>
	/// Summary description for BusinessObjectCreator.
	/// </summary>
	public class BusinessObjectCreator : System.Windows.Forms.Form
	{


 		#region [class variables]

		//add-in variables
		private string _ConnectionString = "";
		private string _WorkingDatabase = "";
		private string _WorkingTable = "";
		private Hashtable _TableLinks = new Hashtable();
		private Hashtable _TableNames = new Hashtable();
		private SqlConnection connection;
		private _DTE applicationObject;
		private FileStream file = null;
		private StreamWriter sw = null;

		//designer variables
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TabPage pageDatabase;
		private System.Windows.Forms.TabPage pageBusinessObject;
		private System.Windows.Forms.TabPage pageFinish;
		private System.Windows.Forms.TextBox txtObjectName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TextBox txtPropertyName;
		private System.Windows.Forms.CheckBox chkObjectReadOnly;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboObjectType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lstObjectProperties;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAddColumn;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.RadioButton rbtGenerated;
		private System.Windows.Forms.RadioButton rbtCustom;
		private System.Windows.Forms.TreeView treeDatabase;
		private System.Windows.Forms.ListView lstColumns;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.TabControl tabApplication;
		private System.Windows.Forms.RichTextBox txtCustomSproc;
		private System.Windows.Forms.ImageList imagelistTree;
		private System.Windows.Forms.ColumnHeader Size;
		private System.Windows.Forms.TabPage pageConnect;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.RadioButton rbtConnectSQL;
		private System.Windows.Forms.RadioButton rbtConnectWindows;
		private System.Windows.Forms.TabPage pageOptions;
		private System.Windows.Forms.CheckBox chkSprocs;
		private System.Windows.Forms.CheckBox chkReflectionUI;
		private System.Windows.Forms.Label lblVersion;
		private System.ComponentModel.IContainer components;

		#endregion



		#region region: basic add-in overhead code

		/// <summary>
		/// BusinessObjectCreator constructor taking a DTE parameter
		/// </summary>
		public BusinessObjectCreator( _DTE argApplicationObject )
		{
			InitializeComponent();
			applicationObject = argApplicationObject;
			cboObjectType.Text = "Integer";
			OpenLogFile();

			return;
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

		#endregion



		#region region: windows form designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BusinessObjectCreator));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tabApplication = new System.Windows.Forms.TabControl();
			this.pageConnect = new System.Windows.Forms.TabPage();
			this.rbtConnectSQL = new System.Windows.Forms.RadioButton();
			this.rbtConnectWindows = new System.Windows.Forms.RadioButton();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.pageDatabase = new System.Windows.Forms.TabPage();
			this.btnAddColumn = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.lstColumns = new System.Windows.Forms.ListView();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.treeDatabase = new System.Windows.Forms.TreeView();
			this.imagelistTree = new System.Windows.Forms.ImageList(this.components);
			this.pageBusinessObject = new System.Windows.Forms.TabPage();
			this.txtPropertyName = new System.Windows.Forms.TextBox();
			this.chkObjectReadOnly = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cboObjectType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lstObjectProperties = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.Size = new System.Windows.Forms.ColumnHeader();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.pageFinish = new System.Windows.Forms.TabPage();
			this.txtCustomSproc = new System.Windows.Forms.RichTextBox();
			this.rbtCustom = new System.Windows.Forms.RadioButton();
			this.rbtGenerated = new System.Windows.Forms.RadioButton();
			this.pageOptions = new System.Windows.Forms.TabPage();
			this.chkReflectionUI = new System.Windows.Forms.CheckBox();
			this.chkSprocs = new System.Windows.Forms.CheckBox();
			this.txtObjectName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tabApplication.SuspendLayout();
			this.pageConnect.SuspendLayout();
			this.pageDatabase.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pageBusinessObject.SuspendLayout();
			this.pageFinish.SuspendLayout();
			this.pageOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(352, 520);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(432, 520);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(640, 48);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(472, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 40);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// tabApplication
			// 
			this.tabApplication.Controls.Add(this.pageConnect);
			this.tabApplication.Controls.Add(this.pageDatabase);
			this.tabApplication.Controls.Add(this.pageBusinessObject);
			this.tabApplication.Controls.Add(this.pageFinish);
			this.tabApplication.Controls.Add(this.pageOptions);
			this.tabApplication.Location = new System.Drawing.Point(0, 88);
			this.tabApplication.Name = "tabApplication";
			this.tabApplication.SelectedIndex = 0;
			this.tabApplication.Size = new System.Drawing.Size(640, 424);
			this.tabApplication.TabIndex = 1;
			this.tabApplication.SelectedIndexChanged += new System.EventHandler(this.tabApplication_SelectedIndexChanged);
			// 
			// pageConnect
			// 
			this.pageConnect.Controls.Add(this.rbtConnectSQL);
			this.pageConnect.Controls.Add(this.rbtConnectWindows);
			this.pageConnect.Controls.Add(this.txtServer);
			this.pageConnect.Controls.Add(this.txtPassword);
			this.pageConnect.Controls.Add(this.label6);
			this.pageConnect.Controls.Add(this.txtLogin);
			this.pageConnect.Controls.Add(this.label8);
			this.pageConnect.Controls.Add(this.label7);
			this.pageConnect.Controls.Add(this.btnConnect);
			this.pageConnect.Location = new System.Drawing.Point(4, 22);
			this.pageConnect.Name = "pageConnect";
			this.pageConnect.Size = new System.Drawing.Size(632, 398);
			this.pageConnect.TabIndex = 3;
			this.pageConnect.Text = "Database Connect";
			// 
			// rbtConnectSQL
			// 
			this.rbtConnectSQL.Location = new System.Drawing.Point(8, 32);
			this.rbtConnectSQL.Name = "rbtConnectSQL";
			this.rbtConnectSQL.Size = new System.Drawing.Size(208, 24);
			this.rbtConnectSQL.TabIndex = 13;
			this.rbtConnectSQL.Text = "Connect by SQL Server Login";
			this.rbtConnectSQL.CheckedChanged += new System.EventHandler(this.rbtConnectSQL_CheckedChanged_1);
			// 
			// rbtConnectWindows
			// 
			this.rbtConnectWindows.Checked = true;
			this.rbtConnectWindows.Location = new System.Drawing.Point(8, 8);
			this.rbtConnectWindows.Name = "rbtConnectWindows";
			this.rbtConnectWindows.Size = new System.Drawing.Size(208, 24);
			this.rbtConnectWindows.TabIndex = 12;
			this.rbtConnectWindows.TabStop = true;
			this.rbtConnectWindows.Text = "Connect by Windows Authentication";
			this.rbtConnectWindows.CheckedChanged += new System.EventHandler(this.rbtConnectWindows_CheckedChanged_1);
			// 
			// txtServer
			// 
			this.txtServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtServer.Location = new System.Drawing.Point(104, 64);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(160, 20);
			this.txtServer.TabIndex = 1;
			this.txtServer.Text = "";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(104, 112);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(160, 20);
			this.txtPassword.TabIndex = 5;
			this.txtPassword.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Password:";
			// 
			// txtLogin
			// 
			this.txtLogin.Location = new System.Drawing.Point(104, 88);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(160, 20);
			this.txtLogin.TabIndex = 3;
			this.txtLogin.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 23);
			this.label8.TabIndex = 0;
			this.label8.Text = "Server Name:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 23);
			this.label7.TabIndex = 2;
			this.label7.Text = "Login Name:";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(24, 152);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.TabIndex = 6;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// pageDatabase
			// 
			this.pageDatabase.Controls.Add(this.btnAddColumn);
			this.pageDatabase.Controls.Add(this.panel2);
			this.pageDatabase.Location = new System.Drawing.Point(4, 22);
			this.pageDatabase.Name = "pageDatabase";
			this.pageDatabase.Size = new System.Drawing.Size(632, 398);
			this.pageDatabase.TabIndex = 0;
			this.pageDatabase.Text = "Explore Database";
			// 
			// btnAddColumn
			// 
			this.btnAddColumn.Enabled = false;
			this.btnAddColumn.Location = new System.Drawing.Point(136, 368);
			this.btnAddColumn.Name = "btnAddColumn";
			this.btnAddColumn.Size = new System.Drawing.Size(136, 23);
			this.btnAddColumn.TabIndex = 9;
			this.btnAddColumn.Text = "Add to Business Object";
			this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.lstColumns);
			this.panel2.Controls.Add(this.treeDatabase);
			this.panel2.Location = new System.Drawing.Point(0, 8);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(624, 352);
			this.panel2.TabIndex = 8;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 352);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// lstColumns
			// 
			this.lstColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader6,
																						 this.columnHeader7,
																						 this.columnHeader8,
																						 this.columnHeader9});
			this.lstColumns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstColumns.Enabled = false;
			this.lstColumns.FullRowSelect = true;
			this.lstColumns.GridLines = true;
			this.lstColumns.Location = new System.Drawing.Point(200, 0);
			this.lstColumns.Name = "lstColumns";
			this.lstColumns.Size = new System.Drawing.Size(424, 352);
			this.lstColumns.TabIndex = 0;
			this.lstColumns.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Column Name";
			this.columnHeader6.Width = 115;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Data Type";
			this.columnHeader7.Width = 99;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Data Size";
			this.columnHeader8.Width = 70;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Nullable";
			this.columnHeader9.Width = 79;
			// 
			// treeDatabase
			// 
			this.treeDatabase.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeDatabase.Enabled = false;
			this.treeDatabase.ImageList = this.imagelistTree;
			this.treeDatabase.Location = new System.Drawing.Point(0, 0);
			this.treeDatabase.Name = "treeDatabase";
			this.treeDatabase.Size = new System.Drawing.Size(200, 352);
			this.treeDatabase.TabIndex = 0;
			this.treeDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDatabase_AfterSelect);
			this.treeDatabase.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDatabase_BeforeExpand);
			// 
			// imagelistTree
			// 
			this.imagelistTree.ImageSize = new System.Drawing.Size(16, 16);
			this.imagelistTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelistTree.ImageStream")));
			this.imagelistTree.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pageBusinessObject
			// 
			this.pageBusinessObject.Controls.Add(this.txtPropertyName);
			this.pageBusinessObject.Controls.Add(this.chkObjectReadOnly);
			this.pageBusinessObject.Controls.Add(this.label4);
			this.pageBusinessObject.Controls.Add(this.label3);
			this.pageBusinessObject.Controls.Add(this.cboObjectType);
			this.pageBusinessObject.Controls.Add(this.label2);
			this.pageBusinessObject.Controls.Add(this.lstObjectProperties);
			this.pageBusinessObject.Controls.Add(this.btnAdd);
			this.pageBusinessObject.Controls.Add(this.btnRemove);
			this.pageBusinessObject.Location = new System.Drawing.Point(4, 22);
			this.pageBusinessObject.Name = "pageBusinessObject";
			this.pageBusinessObject.Size = new System.Drawing.Size(632, 398);
			this.pageBusinessObject.TabIndex = 1;
			this.pageBusinessObject.Text = "Define Business Object";
			// 
			// txtPropertyName
			// 
			this.txtPropertyName.Location = new System.Drawing.Point(72, 320);
			this.txtPropertyName.Name = "txtPropertyName";
			this.txtPropertyName.Size = new System.Drawing.Size(176, 20);
			this.txtPropertyName.TabIndex = 10;
			this.txtPropertyName.Text = "";
			// 
			// chkObjectReadOnly
			// 
			this.chkObjectReadOnly.Location = new System.Drawing.Point(72, 368);
			this.chkObjectReadOnly.Name = "chkObjectReadOnly";
			this.chkObjectReadOnly.Size = new System.Drawing.Size(32, 24);
			this.chkObjectReadOnly.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 368);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 13;
			this.label4.Text = "Read-&Only:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 320);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "&Name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboObjectType
			// 
			this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboObjectType.Items.AddRange(new object[] {
															   "bigint",
															   "binary",
															   "bit",
															   "char",
															   "datetime",
															   "decimal",
															   "float",
															   "image",
															   "int",
															   "money",
															   "text",
															   "uniqueidentifier"});
			this.cboObjectType.Location = new System.Drawing.Point(72, 344);
			this.cboObjectType.Name = "cboObjectType";
			this.cboObjectType.Size = new System.Drawing.Size(176, 21);
			this.cboObjectType.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 344);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "&Type:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lstObjectProperties
			// 
			this.lstObjectProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.columnHeader1,
																								  this.columnHeader2,
																								  this.columnHeader4,
																								  this.columnHeader5,
																								  this.columnHeader3,
																								  this.Size});
			this.lstObjectProperties.FullRowSelect = true;
			this.lstObjectProperties.GridLines = true;
			this.lstObjectProperties.LabelEdit = true;
			this.lstObjectProperties.Location = new System.Drawing.Point(8, 8);
			this.lstObjectProperties.Name = "lstObjectProperties";
			this.lstObjectProperties.Size = new System.Drawing.Size(616, 160);
			this.lstObjectProperties.TabIndex = 17;
			this.lstObjectProperties.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Property Name";
			this.columnHeader1.Width = 159;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 102;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Bound Table";
			this.columnHeader4.Width = 142;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Bound Column";
			this.columnHeader5.Width = 134;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Read-Only";
			this.columnHeader3.Width = 75;
			// 
			// Size
			// 
			this.Size.Text = "Size";
			this.Size.Width = 0;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(256, 320);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 15;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(336, 320);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.TabIndex = 16;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// pageFinish
			// 
			this.pageFinish.Controls.Add(this.txtCustomSproc);
			this.pageFinish.Controls.Add(this.rbtCustom);
			this.pageFinish.Controls.Add(this.rbtGenerated);
			this.pageFinish.Location = new System.Drawing.Point(4, 22);
			this.pageFinish.Name = "pageFinish";
			this.pageFinish.Size = new System.Drawing.Size(632, 398);
			this.pageFinish.TabIndex = 2;
			this.pageFinish.Text = "Edit Stored Procedures";
			// 
			// txtCustomSproc
			// 
			this.txtCustomSproc.Enabled = false;
			this.txtCustomSproc.Location = new System.Drawing.Point(24, 56);
			this.txtCustomSproc.Name = "txtCustomSproc";
			this.txtCustomSproc.Size = new System.Drawing.Size(600, 336);
			this.txtCustomSproc.TabIndex = 9;
			this.txtCustomSproc.Text = "";
			// 
			// rbtCustom
			// 
			this.rbtCustom.Location = new System.Drawing.Point(8, 32);
			this.rbtCustom.Name = "rbtCustom";
			this.rbtCustom.Size = new System.Drawing.Size(216, 24);
			this.rbtCustom.TabIndex = 7;
			this.rbtCustom.Text = "Use Custom Stored Procedures";
			this.rbtCustom.CheckedChanged += new System.EventHandler(this.rbtCustom_CheckedChanged);
			// 
			// rbtGenerated
			// 
			this.rbtGenerated.Checked = true;
			this.rbtGenerated.Location = new System.Drawing.Point(8, 8);
			this.rbtGenerated.Name = "rbtGenerated";
			this.rbtGenerated.Size = new System.Drawing.Size(216, 24);
			this.rbtGenerated.TabIndex = 6;
			this.rbtGenerated.TabStop = true;
			this.rbtGenerated.Text = "Use Generated Stored Procedures";
			this.rbtGenerated.CheckedChanged += new System.EventHandler(this.rbtGenerated_CheckedChanged);
			// 
			// pageOptions
			// 
			this.pageOptions.Controls.Add(this.chkReflectionUI);
			this.pageOptions.Controls.Add(this.chkSprocs);
			this.pageOptions.Location = new System.Drawing.Point(4, 22);
			this.pageOptions.Name = "pageOptions";
			this.pageOptions.Size = new System.Drawing.Size(632, 398);
			this.pageOptions.TabIndex = 4;
			this.pageOptions.Text = "Options";
			// 
			// chkReflectionUI
			// 
			this.chkReflectionUI.Location = new System.Drawing.Point(8, 32);
			this.chkReflectionUI.Name = "chkReflectionUI";
			this.chkReflectionUI.Size = new System.Drawing.Size(248, 24);
			this.chkReflectionUI.TabIndex = 5;
			this.chkReflectionUI.Text = "Include ReflectionUI for Web Applications";
			this.chkReflectionUI.Visible = false;
			// 
			// chkSprocs
			// 
			this.chkSprocs.Location = new System.Drawing.Point(8, 8);
			this.chkSprocs.Name = "chkSprocs";
			this.chkSprocs.Size = new System.Drawing.Size(216, 24);
			this.chkSprocs.TabIndex = 4;
			this.chkSprocs.Text = "Add Stored Procedures to Database";
			// 
			// txtObjectName
			// 
			this.txtObjectName.Location = new System.Drawing.Point(128, 56);
			this.txtObjectName.Name = "txtObjectName";
			this.txtObjectName.Size = new System.Drawing.Size(312, 20);
			this.txtObjectName.TabIndex = 4;
			this.txtObjectName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Business Object Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(0, 536);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(100, 16);
			this.lblVersion.TabIndex = 6;
			this.lblVersion.Text = "2.0a";
			// 
			// BusinessObjectCreator
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(634, 552);
			this.ControlBox = false;
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.txtObjectName);
			this.Controls.Add(this.tabApplication);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BusinessObjectCreator";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = ".NET Business Objects 2003 by John Kanalakis";
			this.Load += new System.EventHandler(this.BusinessObjectCreator_Load);
			this.panel1.ResumeLayout(false);
			this.tabApplication.ResumeLayout(false);
			this.pageConnect.ResumeLayout(false);
			this.pageDatabase.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pageBusinessObject.ResumeLayout(false);
			this.pageFinish.ResumeLayout(false);
			this.pageOptions.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion



		#region region: event handler code
		
		/// <summary>
		/// Removes a business object property from the list
		/// </summary>
		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			WriteToLog( "Remove attribute from business object designer [BEGIN:" + DateTime.Now + "]" );

			try
			{
				if( lstObjectProperties.SelectedItems.Count > 1 )
				{
					for( int intIndex = 0; intIndex < lstObjectProperties.SelectedItems.Count; intIndex++ )
					{
						lstObjectProperties.Items.RemoveAt( lstObjectProperties.SelectedIndices[0] );
					}
				}
				else
					lstObjectProperties.Items.RemoveAt( lstObjectProperties.SelectedIndices[0] );
			}
			catch( Exception x )
			{
				WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
			}

			WriteToLog( "Remove attribute from business object designer [END:" + DateTime.Now + "]" );

			return;
		}



		/// <summary>
		/// Adds a business object property to the list
		/// </summary>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			WriteToLog( "Add attribute to business object designer [BEGIN:" + DateTime.Now + "]" );

			try
			{
				if( txtPropertyName.Text.Length == 0 )
				{
					MessageBox.Show( "Please specify a name for this property." );
					return;
				}
				if( cboObjectType.SelectedItem.ToString().Length == 0 )
				{
					MessageBox.Show( "Please specify a data type for this property." );
					return;
				}

				ListViewItem item = new ListViewItem( txtPropertyName.Text );
				item.SubItems.Add( cboObjectType.SelectedItem.ToString() );
				item.SubItems.Add( "" );
				item.SubItems.Add( "" );
				item.SubItems.Add( chkObjectReadOnly.Checked.ToString() );

				lstObjectProperties.Items.Add( item );

				txtPropertyName.Text = "";
				txtPropertyName.Focus();
				cboObjectType.SelectedText = "";
				chkObjectReadOnly.Checked = false;
			}
			catch( Exception x )
			{
				WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
			}

			WriteToLog( "Add attribute to business object designer [END:" + DateTime.Now + "]" );

			return;
		}



		/// <summary>
		/// If a Web Application project belongs to the solution, then ReflectionUI
		/// code can be added
		/// </summary>
		private void UpdateAsaxFile()
		{
			EditPoint objEdit;

			WriteToLog( "Update the Global.asax file [BEGIN:" + DateTime.Now + "]" );

			try
			{
				//update the Global.asax file in the Web App project
				foreach( Project proj in applicationObject.Solution.Projects )
				{
					//find the Web project
					if( proj.UniqueName.StartsWith( "http://" ) )
					{
						//find the Global.asax file
						foreach( ProjectItem projItem in proj.ProjectItems )
						{
							//System.Diagnostics.Debug.WriteLine( "Files:" + projItem.Name );

							if( projItem.Name.EndsWith( ".asax" ) )
							{
								//start editing file
								EnvDTE.Window wndEditor = projItem.Open( "{7651A701-06E5-11D1-8EBD-00A0C90F26EA}" );

								foreach( ProjectItem projDetails in projItem.ProjectItems )
								{
									System.Diagnostics.Debug.WriteLine( ".asax member files:" + projDetails.Name );

									if( projDetails.Name.EndsWith( ".asax.cs" ) )
									{
										if( projDetails.Document.MarkText( "BusinessObjects", 0 ) == false )
										{
											//add the using statement to the  document
											//((Document)projDetails).
											//										objEdit = ((CodeFunction)cdMethods).StartPoint.CreateEditPoint();
											//										objEdit.LineDown( 2 );

											//search to see if code already exists...

											foreach( CodeElement cdElement in projDetails.FileCodeModel.CodeElements )
											{
												//System.Diagnostics.Debug.WriteLine( cdElement.Name );

												foreach(CodeElement cdClassElmnt in ((CodeNamespace)cdElement).Members)
												{

													if( cdClassElmnt.Kind == vsCMElement.vsCMElementClass )
													{
														//System.Diagnostics.Debug.WriteLine( "class name:" + cdClassElmnt.Name );

														((CodeClass)cdClassElmnt).AddVariable( 
															"Application_BusinessObjectManager", "BusinessObjects.BusinessObjectManager", 
															0, EnvDTE.vsCMAccess.vsCMAccessPublic, null );

													
														//edit the application_start method
														foreach(CodeElement cdMethods in ((CodeClass)cdClassElmnt).Members)
														{
															//System.Diagnostics.Debug.WriteLine( "class methods?:" + cdMethods.Name );
											
															if( cdMethods.Name.CompareTo( "Application_Start" ) == 0 )
															{
																objEdit = ((CodeFunction)cdMethods).StartPoint.CreateEditPoint();
																objEdit.LineDown( 2 );
																objEdit.Insert( "\tApplication.Lock();\n" );
																objEdit.Insert( "\t\t\tApplication_BusinessObjectManager = new BusinessObjects.BusinessObjectManager();\n" );
																objEdit.Insert( "\t\t\tApplication_BusinessObjectManager.DatabaseOpenConnection();\n" );
																objEdit.Insert( "\t\t\tApplication[\"Application_BusinessObjectManager\"] = Application_BusinessObjectManager;\n" );
																objEdit.Insert( "\t\t\tApplication.UnLock();\n" );
																objEdit.Insert( "\t\t" );
															}
														}

														//edit the application_end method
													}

													if(cdClassElmnt.Kind == vsCMElement.vsCMElementInterface)
													{
														System.Diagnostics.Debug.WriteLine( "interface name:" + cdClassElmnt.Name );
													}

												}

											}
										}

									}
								}

							}

						} //foreach( ProjectItem

					} //if( proj.UniqueName

				} //foreach( Project proj

			}
			catch( Exception x )
			{
				WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
				System.Diagnostics.Debug.WriteLine( x.Message );
			}

			WriteToLog( "Update the Global.asax file [END:" + DateTime.Now + "]" );

			return;
		}



		private void AddBusinessObjectsProject()
		{
			return;
		}



		/// <summary>
		/// Accepts the user input and creates the business object project and code
		/// </summary>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			EditPoint objEdit = null;
			TextDocument objNewDocument;
			string strSavePath = "";

			WriteToLog( "btnOK_Click event handler [BEGIN:" + DateTime.Now + "]" );

			if( txtObjectName.Text.Length == 0 )
			{
				MessageBox.Show( "Please specify a name for this business object." );
				WriteToLog( "btnOK_Click event handler [END:" + DateTime.Now + "]" );
				return;
			}

			try
			{
				//update the database connection info with the selected database name
				_ConnectionString += "initial catalog=";
				_ConnectionString += _WorkingDatabase;

				//update the global.asax file to add object manager
				if( chkReflectionUI.Checked == true )
				{
					UpdateAsaxFile();
				}

				//get the BusinessObjects project and path information
				EnvDTE.Project projBusinessObjects = FindBusinessObjectsProject();
				strSavePath = GetPathFromFilename( projBusinessObjects.FileName );


				//create the custom business object source file
				try
				{
					//create the custom business object source file
					WriteToLog( "Create the custom business object source [" + DateTime.Now + "]" );
					applicationObject.ItemOperations.NewFile( "General\\Text File", txtObjectName.Text + ".cs", Constants.vsViewKindCode );
			
					objNewDocument = (TextDocument)applicationObject.ActiveDocument.Object( "TextDocument" );
					objEdit = (EditPoint)objNewDocument.StartPoint.CreateEditPoint();
					objEdit.Insert( CreateBusinessObjectCode() );
					objEdit.DTE.ActiveDocument.Save( strSavePath + "\\MyObjects\\" + txtObjectName.Text + ".cs" );
					projBusinessObjects.ProjectItems.AddFromFile( strSavePath + "\\MyObjects\\" + txtObjectName.Text + ".cs" );
				}
				catch( Exception x )
				{
					System.Diagnostics.Debug.WriteLine( x.Message );
					WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
				}


				//create the custom business object collection source file
				try
				{
					WriteToLog( "Create the custom business object collection source [" + DateTime.Now + "]" );
					applicationObject.ItemOperations.NewFile( "General\\Text File", 
						txtObjectName.Text + "Collection.cs", Constants.vsViewKindCode );
			
					objNewDocument = (TextDocument)applicationObject.ActiveDocument.Object( "TextDocument" );
					objEdit = (EditPoint)objNewDocument.StartPoint.CreateEditPoint();
					objEdit.Insert( CreateBusinessObjectCollectionCode() );
					objEdit.DTE.ActiveDocument.Save( strSavePath + "\\MyObjects\\" + txtObjectName.Text + "Collection.cs" );
					projBusinessObjects.ProjectItems.AddFromFile( strSavePath + "\\MyObjects\\" + txtObjectName.Text + "Collection.cs" );
				}
				catch( Exception x )
				{
					System.Diagnostics.Debug.WriteLine( x.Message );
					WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
				}


				//create the stored procedures source file
				try
				{
					WriteToLog( "Create the stored procedures [" + DateTime.Now + "]" );
					applicationObject.ItemOperations.NewFile( "General\\Text File", strSavePath + txtObjectName.Text + ".cs", Constants.vsViewKindCode );
					objNewDocument = (TextDocument)applicationObject.ActiveDocument.Object( "TextDocument" );
					objEdit = (EditPoint)objNewDocument.StartPoint.CreateEditPoint();
					objEdit.Insert( CreateStoredProcedures( false ) );
					objEdit.DTE.ActiveDocument.Save( strSavePath + "\\StoredProcedures\\" + txtObjectName.Text + "_StoredProcedures.txt" );
					projBusinessObjects.ProjectItems.AddFromFile( strSavePath + "\\StoredProcedures\\" + txtObjectName.Text + "_StoredProcedures.txt" );
				}
				catch( Exception x )
				{
					System.Diagnostics.Debug.WriteLine( x.Message );
					WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
				}
				

				try
				{
					//replace the default connection string in the object manager
					WriteToLog( "replace the default connection string in the object manager [" + DateTime.Now + "]" );
					applicationObject.ItemOperations.OpenFile( strSavePath + "\\BusinessObjectManager.cs", Constants.vsViewKindCode );
					objNewDocument = (TextDocument)applicationObject.ActiveDocument.Object( "TextDocument" );
					bool b = objNewDocument.ReplaceText( "@@_ENTER_YOUR_DEFAULT_CONNECTION_STRING_@@",
						_ConnectionString, (int)vsFindOptions.vsFindOptionsMatchWholeWord ); //vsFindOptions.vsFindOptionsNone );
					objEdit.DTE.ActiveDocument.Close( vsSaveChanges.vsSaveChangesYes );
				}
				catch( Exception x )
				{
					System.Diagnostics.Debug.WriteLine( x.Message );
					WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
				}

			}
			catch( Exception x )
			{
				System.Diagnostics.Debug.WriteLine( x.Message );
				WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
			}
			finally
			{
				Close();
			}

			WriteToLog( "btnOK_Click event handler [END:" + DateTime.Now + "]" );

			CloseLogFile();

			return;
		}


		
		/// <summary>
		/// Cancels the BusinessObjectCreator dialog box
		/// </summary>
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			WriteToLog( "btnCancel_Click event handler [BEGIN:" + DateTime.Now + "]" );

			try
			{
				connection.Close();
			}
			catch( Exception x )
			{
				System.Diagnostics.Debug.WriteLine( x.Message );
				WriteToLog( x.Message + " [EXCEPTION:" + DateTime.Now + "]" );
			}
			finally
			{
				//if( MessageBox.Show( "Are you sure you want to cancel?", "Warning", MessageBoxButtons.YesNo ) == DialogResult.Yes )
				//{
				Close();
				//}
			}
		
			WriteToLog( "btnCancel_Click event handler [END:" + DateTime.Now + "]" );

			CloseLogFile();

			return;
		}

		
		
		private void BusinessObjectCreator_Load(object sender, System.EventArgs e)
		{
			WriteToLog( "BusinessObjectCreator_Load event handler [BEGIN:" + DateTime.Now + "]" );

			//check the registry for expiration
			RegistryKey regkeyAppRoot = Registry.CurrentUser.CreateSubKey( "Software\\BOJS\\Settings" );
			
			if( ((string)regkeyAppRoot.GetValue( "Key" )) == null ||
				((string)regkeyAppRoot.GetValue( "Key" )).CompareTo( "A051YZY" ) != 0 )
			{
				//product is not registered

				DateTime dateStarted = new DateTime();
				long longDate = 0;
				
				if( regkeyAppRoot.GetValue( "Registration" ) != null )
				{
					string strValue = (string)regkeyAppRoot.GetValue( "Registration" );
					longDate = long.Parse( strValue );
				}

				if( longDate > 0 )
				{
					dateStarted = new DateTime( longDate );
				}
				else
				{
					//create start eval date if not entered
					string strPath ="Software\\BOJS\\Settings";
					regkeyAppRoot = Registry.CurrentUser.CreateSubKey( strPath );
					regkeyAppRoot.SetValue( "Registration", DateTime.Now.Ticks );
					dateStarted = new DateTime( DateTime.Now.Ticks );
				}

				TimeSpan spanDifference = DateTime.Now.Subtract( dateStarted );


				WriteToLog( "BusinessObjectCreator_Load event handler [END:" + DateTime.Now + "]" );

				return;
			}

			//RegistryKey regkeyAppRoot = Registry.CurrentUser.CreateSubKey( "Software\\BOJS\\Settings" );
			txtServer.Text = (string)regkeyAppRoot.GetValue( "ServerName" );
			txtLogin.Text = (string)regkeyAppRoot.GetValue( "LoginName" );
			txtPassword.Text = (string)regkeyAppRoot.GetValue( "Password" );
			//txtDatabase.Text = (string)regkeyAppRoot.GetValue( "DatabaseName" );

			txtServer.Enabled = false;
			txtLogin.Enabled = false;
			txtPassword.Enabled = false;

			WriteToLog( "BusinessObjectCreator_Load event handler [END:" + DateTime.Now + "]" );

			return;
		}

		

		private void rbtConnectWindows_CheckedChanged_1(object sender, System.EventArgs e)
		{
			txtServer.Enabled = false;
			txtLogin.Enabled = false;
			txtPassword.Enabled = false;

			return;
		}


		
		private void rbtConnectSQL_CheckedChanged_1(object sender, System.EventArgs e)
		{
			txtServer.Enabled = true;
			txtLogin.Enabled = true;
			txtPassword.Enabled = true;

			return;
		}

		#endregion



		#region region: dynamic code generation methods

		private string CreateBusinessObjectCode()
		{
			string strOutput = "";


			//create using header
			strOutput += "using System;\n";
			strOutput += "\n";
			strOutput += "\n";

			//create namespace header
			strOutput += "namespace BusinessObjects" + "\n";
			strOutput += "{" + "\n";

			//create class declaration
			strOutput += "\tpublic class " + txtObjectName.Text + " : BusinessObject" + "\n";
			strOutput += "\t{" + "\n";

			//create the private class variables
			foreach( ListViewItem itemProperty in lstObjectProperties.Items )
			{
				strOutput += "\t\tprivate ";
				strOutput += DataDescriptionToType( itemProperty.SubItems[1].Text );
				strOutput += " _" + itemProperty.Text + ";\n";
			}


			//create the class constructor
			strOutput += "\n\n";
			strOutput += "\t\tpublic " + txtObjectName.Text +  "()\n";
			strOutput += "\t\t{" + "\n";
			strOutput += "\t\t\t_StoredProcSelectOne = \"usp_" + txtObjectName.Text+ "_Load\";\n";
			strOutput += "\t\t\t_StoredProcInsert = \"usp_" + txtObjectName.Text+ "_Insert\";\n";
			strOutput += "\t\t\t_StoredProcUpdate = \"usp_" + txtObjectName.Text+ "_Update\";\n";
			strOutput += "\t\t\t_StoredProcDelete = \"usp_" + txtObjectName.Text+ "_Delete\";\n\n";
			strOutput += "\t\t\treturn;\n";
			strOutput += "\t\t}" + "\n\n";


			//create the public class properties
			foreach( ListViewItem itemProperty in lstObjectProperties.Items )
			{
				strOutput += "\t\tpublic ";

				//map the data type to c# data type
				strOutput += DataDescriptionToType( itemProperty.SubItems[1].Text );

				strOutput += " " + itemProperty.Text + "\n";
				strOutput += "\t\t{" + "\n";
				strOutput += "\t\t\tset" + "\n";
				strOutput += "\t\t\t{\n";
				strOutput += "\t\t\t\t_" + itemProperty.Text + " = value;\n";
				strOutput += "\t\t\t}\n";

				strOutput += "\t\t\tget" + "\n";
				strOutput += "\t\t\t{\n";
				strOutput += "\t\t\t\treturn _" + itemProperty.Text + ";\n";
				strOutput += "\t\t\t}\n";
				
				strOutput += "\t\t}" + "\n";
				strOutput += "\n";
			}


			//close class declaration
			strOutput += "\t}" + "\n";

			//close namespace
			strOutput += "}" + "\n";

			//System.Diagnostics.Debug.WriteLine( strOutput );
			return strOutput;
		}

		
		private string CreateBusinessObjectCollectionCode()
		{
			string strOutput = "";

			//create using header
			strOutput += "using System;\n";
			strOutput += "\n";
			strOutput += "\n";

			//create namespace header
			strOutput += "namespace BusinessObjects" + "\n";
			strOutput += "{" + "\n";
			strOutput += "\n";

			//create class declaration
			strOutput += "\tpublic class " + txtObjectName.Text + "Collection : BusinessObjectCollection" + "\n";
			strOutput += "\t{" + "\n";
			strOutput += "\t\tpublic " + txtObjectName.Text + "Collection()\n";
			strOutput += "\t\t{\n";
			strOutput += "\t\t\t_StoredProcSelectAll = \"usp_" + txtObjectName.Text+ "_LoadAll\";\n\n";
			strOutput += "\t\t\treturn;\n";
			strOutput += "\t\t}\n";
			strOutput += "\n";
			strOutput += "\n";

			//create the new method
			strOutput += "\t\t//create a new instace of the " + txtObjectName.Text + " object\n";
			strOutput += "\t\tpublic override BusinessObject New()\n";
			strOutput += "\t\t{\n";
			strOutput += "\t\t\treturn new " + txtObjectName.Text + "();\n";
			strOutput += "\t\t}\n";
			strOutput += "\n";
			strOutput += "\n";


			//create the add method
			strOutput += "\t\tpublic new void Add( BusinessObject argObject )\n";
			strOutput += "\t\t{\n";
			strOutput += "\t\t\t_Objects.Add( argObject );\n";
			strOutput += "\t\t\treturn;\n";
			strOutput += "\t\t}\n";
			strOutput += "\n";


			//close the class and namespace
			strOutput += "\t}\n";
			strOutput += "}\n\n";

			return strOutput;
		}
		

		private string CreateStoredProcedures( bool boolPreview )
		{
			string strDocument = "";
			string strOutput = "";
			Hashtable hashLocalDuplicates = new Hashtable();

			IdentifyTableJoins();

			///////////////////////////////
			//CREATE SELECT ALL STRORED PROC
			//
			strOutput = "CREATE PROCEDURE [dbo].[usp_" +txtObjectName.Text+ "_LoadAll]\n";
			strOutput += "AS SET NOCOUNT ON;\n";
			strOutput += "SELECT ";

			foreach( ListViewItem itemProperty in lstObjectProperties.Items )
			{
				strOutput += itemProperty.SubItems[2].Text;
				strOutput += ".";
				strOutput += itemProperty.SubItems[3].Text;
				strOutput += ", ";
			}
			//remove the last trailing comma
			strOutput = strOutput.Substring( 0, strOutput.Length - 2);

			strOutput += "\nFROM ";
			foreach( string strTable in _TableNames.Keys )
			{
				strOutput += strTable + ", ";
			}
			//remove the last trailing comma
			strOutput = strOutput.Substring( 0, strOutput.Length - 2);

			//is there more than one table involved
			if( _TableLinks.Count > 0 )
			{
				strOutput += " WHERE ";
				foreach( string strClause in _TableLinks.Values )
				{		
					strOutput += strClause + " AND ";
				}
				//remove the last trailing AND
				strOutput = strOutput.Substring( 0, strOutput.Length - 4);
			}
			if( !boolPreview )
			{
				if( chkSprocs.Checked )
				{
					CreateProcedureInDatabase( strOutput );
				}
			}
			
			strDocument += strOutput;
			strDocument += "\nGO\n\n\n\n";



			///////////////////////////////
			//CREATE SELECT ONE STORED PROC
			//
			strOutput = "CREATE PROCEDURE [dbo].[usp_" +txtObjectName.Text+ "_Load]\n";
			strOutput += "(\n";
			strOutput += "\t@" + lstObjectProperties.Items[0].Text;
			strOutput += " " + DataDescriptionToType( lstObjectProperties.Items[0].SubItems[1].Text );
			strOutput += "\n)\n";
			strOutput += "AS SET NOCOUNT ON;\n";
			strOutput += "SELECT ";

			foreach( ListViewItem itemProperty in lstObjectProperties.Items )
			{
				strOutput += itemProperty.SubItems[2].Text;
				strOutput += ".";
				strOutput += itemProperty.SubItems[3].Text;
				strOutput += ", ";
			}

			//remove the last trailing comma
			strOutput = strOutput.Substring( 0, strOutput.Length - 2);

			strOutput += "\nFROM ";
			foreach( string strTable in _TableNames.Keys )
			{
				strOutput += strTable + ", ";
			}
			//remove the last trailing comma
			strOutput = strOutput.Substring( 0, strOutput.Length - 2);


			strOutput += "\nWHERE ";
			foreach( string strClause in _TableLinks.Values )
			{		
				strOutput += strClause + " AND ";
			}

			strOutput += "(" + lstObjectProperties.Items[0].Text;
			strOutput += " = @" + lstObjectProperties.Items[0].Text;
			strOutput += ")\n";

			if( !boolPreview )
			{
				if( chkSprocs.Checked )
				{
					CreateProcedureInDatabase( strOutput );
				}
			}
			
			strDocument += strOutput;
			strDocument += "GO\n\n\n\n";



			///////////////////////////////
			//CREATE INSERT ONE STORED PROC
			//
			hashLocalDuplicates = new Hashtable();
			strOutput = "CREATE PROCEDURE [dbo].[usp_" +txtObjectName.Text+ "_Insert]\n";
			strOutput += "(\n";
			foreach( ListViewItem itemProperty in lstObjectProperties.Items )
			{
				if( !hashLocalDuplicates.ContainsKey( itemProperty.Text ) )
				{
					strOutput += "\t@" + itemProperty.Text;
					strOutput += " " + DataDescriptionToDatabaseType( itemProperty.SubItems[1].Text, itemProperty.SubItems[5].Text );
					strOutput += ",\n";

					//add to local hash
					hashLocalDuplicates.Add( itemProperty.Text, 1 );
				}
			}
			//remove the last trailing comma
			strOutput = strOutput.Substring( 0, strOutput.Length - 2);

			strOutput += "\n)\n";
			strOutput += "AS \nSET NOCOUNT OFF;\n";
			strOutput += "BEGIN TRANSACTION\n";
			
			foreach( string strTable in _TableNames.Keys )
			{
				strOutput += "INSERT INTO " + strTable + "\n(";

				//iterate through the control table
				foreach( ListViewItem itemProperty in lstObjectProperties.Items )
				{
					if( itemProperty.SubItems[2].Text.CompareTo( strTable ) == 0 )
					{
						strOutput += itemProperty.SubItems[2].Text;
						strOutput += ".";
						strOutput += itemProperty.SubItems[3].Text;
						strOutput += ", ";
					}
				}
				//remove the last trailing comma
				strOutput = strOutput.Substring( 0, strOutput.Length - 2);

				strOutput += ") \nVALUES \n(";
				foreach( ListViewItem itemProperty in lstObjectProperties.Items )
				{
					if( itemProperty.SubItems[2].Text.CompareTo( strTable ) == 0 )
					{
						strOutput += "@" + itemProperty.Text;
						strOutput += ", ";
					}
				}
				//remove the last trailing comma
				strOutput = strOutput.Substring( 0, strOutput.Length - 2);
				
				strOutput += ")\n";
			}
			strOutput += "COMMIT TRANSACTION\n";

			if( !boolPreview )
			{
				if( chkSprocs.Checked )
				{
					CreateProcedureInDatabase( strOutput );
				}
			}

			strDocument += strOutput;
			strDocument += "GO\n\n\n\n";



			///////////////////////////////
			//CREATE UPDATE ONE STORED PROC
			//
			hashLocalDuplicates = new Hashtable();
			strOutput = "CREATE PROCEDURE [dbo].[usp_" +txtObjectName.Text+ "_Update]\n";
			strOutput += "(\n";
			foreach( ListViewItem itemProperty in lstObjectProperties.Items )
			{
				if( !hashLocalDuplicates.ContainsKey( itemProperty.Text ) )
				{
					strOutput += "\t@" + itemProperty.Text;
					strOutput += " " + DataDescriptionToDatabaseType( itemProperty.SubItems[1].Text, itemProperty.SubItems[5].Text );
					strOutput += ",\n";

					//add to local hash
					hashLocalDuplicates.Add( itemProperty.Text, 1 );
				}
			}
			strOutput += "\t@Original_" + lstObjectProperties.Items[0].Text + " int\n";

			strOutput += "\n)\n";
			strOutput += "AS \nSET NOCOUNT OFF;\n";

			strOutput += "BEGIN TRANSACTION\n";
			
			
			//clear out local hash and use again to build individual table inserts
			//by looping through the list

			foreach( string strTable in _TableNames.Keys )
			{
				strOutput += "UPDATE " + strTable + " SET ";

				//iterate through the control table
				foreach( ListViewItem itemProperty in lstObjectProperties.Items )
				{
					if( itemProperty.SubItems[2].Text.CompareTo( strTable ) == 0 )
					{
						strOutput += itemProperty.SubItems[2].Text;
						strOutput += ".";
						strOutput += itemProperty.SubItems[3].Text;
						strOutput += " = ";
						strOutput += "@" + itemProperty.Text;
						strOutput += ", ";
					}
				}
				//remove the last trailing comma
				strOutput = strOutput.Substring( 0, strOutput.Length - 2);

				//complete where clause
				strOutput += "\nWHERE ";
				strOutput += "(@";
				strOutput += lstObjectProperties.Items[0].Text + " = @Original_";
				strOutput += lstObjectProperties.Items[0].Text + ")\n";
				strOutput += "IF @@ROWCOUNT = 0\n";
				strOutput += "\tRAISERROR ('Warning:Optimistic concurrency failed.', 10, 1)";
				strOutput += "\n";
			}
			strOutput += "COMMIT TRANSACTION\n";

			if( !boolPreview )
			{
				if( chkSprocs.Checked )
				{
					CreateProcedureInDatabase( strOutput );
				}
			}

			strDocument += strOutput;
			strDocument += "GO\n\n\n\n";



			///////////////////////////////
			//CREATE DELETE ONE STORED PROC
			//
			hashLocalDuplicates = new Hashtable();
			strOutput = "CREATE PROCEDURE [dbo].[usp_" +txtObjectName.Text+ "_Delete]\n";
			strOutput += "(\n";

			ListViewItem lstPrimaryKey = lstObjectProperties.Items[0];
			strOutput += "\t@" + lstPrimaryKey.Text;
			strOutput += " " + lstPrimaryKey.SubItems[1].Text;
			strOutput += "\n)\n";
			strOutput += "AS SET NOCOUNT OFF;\n";
			strOutput += "BEGIN TRANSACTION\n";

			strOutput += "DELETE FROM " + lstPrimaryKey.SubItems[2].Text;
			strOutput += "\nWHERE ";
			strOutput += "(" + lstPrimaryKey.Text;
			strOutput += " = @" + lstPrimaryKey.Text;
			strOutput += ")\n";
			strOutput += "COMMIT TRANSACTION\n";

			if( !boolPreview )
			{
				if( chkSprocs.Checked )
				{
					CreateProcedureInDatabase( strOutput );
				}
			}
			
			strOutput += "GO\n\n\n\n";
			strDocument += strOutput;

			return strDocument;
		}


		#endregion



		#region region: shared utility methods

		/// <summary>
		/// Takes a filename and the extension and returns the path without a trailing 
		/// back-slash
		/// </summary>
		private string GetPathFromFilename( string strFilename )
		{
			string strOutput = "";

			for( int intIndex = strFilename.Length - 1; intIndex > 0; intIndex--)
			{
				if( strFilename[intIndex] == '\\' )
				{
					strOutput = strFilename.Substring( 0, intIndex );
					break;
				}
			}
			
			return strOutput;
		}
		


		private string DataDescriptionToType( string argDescription )
		{
			//map the data type to c# data type
			if( argDescription.CompareTo( "int" ) == 0 )
				return "int";
			else if( argDescription.CompareTo( "bigint" ) == 0 )
				return "long";
			else if( argDescription.CompareTo( "binary" ) == 0 )
				return "byte";
			else if( argDescription.CompareTo( "bit" ) == 0 )
				return "byte";
			else if( argDescription.CompareTo( "char" ) == 0 )
				return "string";
			else if( argDescription.CompareTo( "datetime" ) == 0 )
				return "DateTime";
			else if( argDescription.CompareTo( "decimal" ) == 0 )
				return "float";
			else if( argDescription.CompareTo( "image" ) == 0 )
				return "System.Drawing.Image";
			else if( argDescription.CompareTo( "money" ) == 0 )
				return "float";
			else if( argDescription.CompareTo( "text" ) == 0 )
				return "string";
			else if( argDescription.CompareTo( "uniqueidentifier" ) == 0 )
				return "System.Guid";
			else if( argDescription.CompareTo( "nvarchar" ) == 0 )
				return "string";
			else if( argDescription.CompareTo( "ntext" ) == 0 )
				return "string";
			else if( argDescription.CompareTo( "nchar" ) == 0 )
				return "string";

			return argDescription;
														}


		private string DataDescriptionToDatabaseType( string argDescription, string strSize  )
		{
			if( argDescription.CompareTo( "char" ) == 0 )
				return "char (" + strSize + ")" ;
			else if( argDescription.CompareTo( "datetime" ) == 0 )
				return "DateTime";
				
			return argDescription;
		}


		private EnvDTE.Project FindBusinessObjectsProject()
		{
			bool boolProjectFound = false;
			EnvDTE.Project projApplication = null;
			EnvDTE.Project projBusinessObjects = null;


			try
			{
				if( applicationObject.Solution.Projects.Count > 0 )
				{
					//look for the business object project
					foreach( EnvDTE.Project projItem in applicationObject.Solution.Projects )
					{
						if( projItem.Kind.CompareTo( "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}" ) == 0 )
						{
							if( projItem.UniqueName.StartsWith( "http:" ) )
							{
								projApplication = projItem;
							}
						}

						if( projItem.Name == "BusinessObjects" )
						{
							projBusinessObjects = projItem;
							boolProjectFound = true;
							break;
						}
					}
				}

				if( boolProjectFound == false )
				{
					try
					{
						//create a an new project from scratch using wizards
						projBusinessObjects = applicationObject.Solution.AddFromTemplate( 
							@"C:\Program Files\Business Objects JumpStart\Templates\BusinessObjects.csproj",
							GetPathFromFilename( applicationObject.Solution.FileName ) + @"\BusinessObjects",
							"BusinessObjects",
							false );
					}
					catch( Exception x )
					{
						System.Diagnostics.Debug.WriteLine( "***" + x.Message );
					}
				}

				//add the new project reference to the base project
				if( projBusinessObjects != null )
				{
					VSLangProj.VSProject castProject = (VSLangProj.VSProject)projApplication.Object;
					castProject.References.AddProject( projBusinessObjects );
				}
			}
			catch( Exception x )
			{
				System.Diagnostics.Debug.WriteLine( "***" + x.Message );
			}

			return projBusinessObjects;
		}



		public bool CreateProcedureInDatabase( string strStoredProcedure )
		{
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand sqlCommand = null;

			try
			{
				sqlConnection = new SqlConnection( _ConnectionString );
				sqlConnection.Open();
				sqlCommand = new SqlCommand( strStoredProcedure, sqlConnection );
				sqlCommand.ExecuteNonQuery();
			}
			catch( SqlException x )
			{
				System.Diagnostics.Debug.WriteLine( "***" + strStoredProcedure );
				System.Diagnostics.Debug.WriteLine( "***Exception: " + x.Message );
				return false;
			}
			finally
			{
				sqlCommand.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
			return true;
		}
		

		private bool IdentifyTableJoins()
		{
			bool boolFoundLink = false;
			string strClause = "";
			Hashtable hashNames = new Hashtable();

			//clear out the tables if already filled
			_TableLinks.Clear();
			_TableNames.Clear();

			//iterate through the object list and look for a duplicate
			foreach( ListViewItem itemProperty in lstObjectProperties.Items )
			{
				if( hashNames.Contains( itemProperty.SubItems[3].Text ) )
				{
					boolFoundLink = true;

					
					strClause = hashNames[itemProperty.SubItems[3].Text] + "." + itemProperty.SubItems[3].Text;
					strClause += " = " + itemProperty.SubItems[2].Text + "." + itemProperty.SubItems[3].Text;

					//add the column name
					_TableLinks.Add( itemProperty.SubItems[3].Text, strClause );

					//add the table name
					if( !_TableNames.Contains( itemProperty.SubItems[2].Text ) )
						_TableNames.Add( itemProperty.SubItems[2].Text, 1 );
				}
				else
				{
					//add the column name
					hashNames.Add( itemProperty.SubItems[3].Text, itemProperty.SubItems[2].Text );

					//add the table name
					if( !_TableNames.Contains( itemProperty.SubItems[2].Text ) )
						_TableNames.Add( itemProperty.SubItems[2].Text, 1 );
				}
			}

			return boolFoundLink;
		}



		private void WriteToLog( string strText )
		{
			sw.WriteLine( strText );
			return;
		}



		private void OpenLogFile()
		{
			try
			{
				file = new FileStream( @"c:\BusinessObjects2003_Log.txt", FileMode.OpenOrCreate, FileAccess.Write );
				sw = new StreamWriter( file );
			}
			catch( Exception x )
			{
				System.Diagnostics.Debug.WriteLine( x.Message );
			}

			return;
		}

		

		private void CloseLogFile()
		{
			try
			{
				sw.Close();
				file.Close();
			}
			catch( Exception x )
			{
				System.Diagnostics.Debug.WriteLine( x.Message );
			}

			return;
		}

		#endregion



		#region Database Interaction Code

		private void rbtCustom_CheckedChanged(object sender, System.EventArgs e)
		{
			txtCustomSproc.Enabled = true;
		}



		private void rbtGenerated_CheckedChanged(object sender, System.EventArgs e)
		{
			txtCustomSproc.Enabled = false;
		}



		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			string strPath ="Software\\BOJS\\Settings";
			RegistryKey regkeyAppRoot = Registry.CurrentUser.CreateSubKey( strPath );

			btnConnect.Enabled = false;
			btnAddColumn.Enabled = true;
			treeDatabase.Enabled = true;
			lstColumns.Enabled = true;

			
			if( rbtConnectWindows.Checked )
			{
				_ConnectionString = "workstation id=localhost;packet size=4096;integrated security=SSPI" +
					";persist security info=False;";
			}
			else
			{
				//save the database connection info, except password
				regkeyAppRoot.SetValue( "ServerName", txtServer.Text );
				regkeyAppRoot.SetValue( "LoginName", txtLogin.Text );
				regkeyAppRoot.SetValue( "Password", txtPassword.Text );

				_ConnectionString = "workstation id=" + txtServer.Text + ";packet size=4096;user id=" + txtLogin.Text +
					";data source=" + txtServer.Text + ";pwd=" + txtPassword.Text + ";persist security info=False;"; //initial catalog=" +
				//txtDatabase.Text;
			}


			//open the database connection
			try
			{
				connection = new SqlConnection( _ConnectionString );
				connection.Open();
				SqlCommand command = new SqlCommand( "select catalog_name from Information_Schema.Schemata", connection );
				SqlDataReader reader = command.ExecuteReader();
				while( reader.Read() )
				{
					//add a table to the listview collection
					TreeNode node = new TreeNode( reader.GetValue(0).ToString(), 0, 0 );
					node.Nodes.Add( "Tables" );
					treeDatabase.Nodes.Add( node );
				}
				treeDatabase.SelectedNode = treeDatabase.TopNode;
				tabApplication.SelectedIndex = 1;

				reader.Close();
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message, "Warning" );
				btnConnect.Enabled = true;
				btnAddColumn.Enabled = false;
				treeDatabase.Enabled = false;
				lstColumns.Enabled = false;
			}
			finally
			{
				//connection.Close();
			}
			
			
			return;
		}


		private void pageDatabase_Click(object sender, System.EventArgs e)
		{
			RegistryKey regkeyAppRoot = Registry.CurrentUser.CreateSubKey( "Software\\BOJS\\Settings" );
			txtServer.Text = (string)regkeyAppRoot.GetValue( "ServerName" );
			txtLogin.Text = (string)regkeyAppRoot.GetValue( "LoginName" );
			txtPassword.Text = (string)regkeyAppRoot.GetValue( "Password" );
			//txtDatabase.Text = (string)regkeyAppRoot.GetValue( "DatabaseName" );
		}


		private void rbtConnectWindows_CheckedChanged(object sender, System.EventArgs e)
		{
			txtServer.Enabled = false;
			txtLogin.Enabled = false;
			txtPassword.Enabled = false;
		}

		private void rbtConnectSQL_CheckedChanged(object sender, System.EventArgs e)
		{
			txtServer.Enabled = true;
			txtLogin.Enabled = true;
			txtPassword.Enabled = true;
		}


		private void treeDatabase_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			_WorkingDatabase = e.Node.Text;


			//open the database connection
			try
			{
				connection.ChangeDatabase( _WorkingDatabase );

				SqlCommand command = new SqlCommand( "select * from information_schema.tables where table_type = 'BASE TABLE'", connection );
				SqlDataReader reader = command.ExecuteReader();
				treeDatabase.SelectedNode = e.Node;
				treeDatabase.SelectedNode.Nodes.Clear();

				while( reader.Read() )
				{
					//add a table to the listview collection
					if( reader.GetValue(2).ToString().CompareTo( "dtproperties" ) != 0 )
					{
						TreeNode node = new TreeNode( reader.GetValue(2).ToString(), 1, 1 );
						treeDatabase.SelectedNode.Nodes.Add( node );
					}
				}

				reader.Close();
			}
			catch( Exception x )
			{
				MessageBox.Show( x.Message, "Warning" );
			}
			finally
			{
				//connection.Close();
			}

			return;
		}


		private void treeDatabase_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if( e.Node.Nodes.Count == 0 )
			{
				//this is a table, display columns
				_WorkingDatabase = e.Node.Parent.Text;
				_WorkingTable = e.Node.Text;


				try
				{
					connection.ChangeDatabase( _WorkingDatabase );

					SqlCommand command = new SqlCommand( "select * from information_schema.columns where TABLE_NAME = '" + _WorkingTable + "'", connection );
					SqlDataReader reader = command.ExecuteReader();
					//treeDatabase.SelectedNode = e.Node;
					//treeDatabase.SelectedNode.Nodes.Clear();

					lstColumns.Items.Clear();

					while( reader.Read() )
					{
						//add a table to the listview collection
						ListViewItem item = new ListViewItem( reader.GetValue(3).ToString() );
						item.SubItems.Add( reader.GetValue(7).ToString() );
						item.SubItems.Add( reader.GetValue(8).ToString() );
						item.SubItems.Add( reader.GetValue(6).ToString().ToUpper() );
						lstColumns.Items.Add( item );
					}

					reader.Close();
				}
				catch( Exception x )
				{
					MessageBox.Show( x.Message, "Warning" );
				}
				finally
				{
					//connection.Close();
				}

			}
		}


		private void btnAddColumn_Click(object sender, System.EventArgs e)
		{
			for( int intIndex = 0; intIndex < lstColumns.SelectedItems.Count; intIndex++ )
			{
				string strColumnName = lstColumns.SelectedItems[intIndex].Text;
				string strDataType = lstColumns.SelectedItems[intIndex].SubItems[1].Text;
				string strDataSize = lstColumns.SelectedItems[intIndex].SubItems[2].Text;

				ListViewItem item = new ListViewItem( strColumnName );
				item.SubItems.Add( strDataType );
				item.SubItems.Add( _WorkingTable );
				item.SubItems.Add( strColumnName );
				item.SubItems.Add( "False" );
				item.SubItems.Add( strDataSize );

				lstObjectProperties.Items.Add( item );

				txtPropertyName.Text = "";
				txtPropertyName.Focus();
				cboObjectType.SelectedText = "";
				chkObjectReadOnly.Checked = false;
			}
		}


		private void tabApplication_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if( tabApplication.SelectedIndex == 3 )
				{
					txtCustomSproc.Text = CreateStoredProcedures( true );
				}
			}
			catch( Exception x )
			{
				System.Diagnostics.Debug.WriteLine( x.Message );
			}

			return;
		}

		#endregion 



	}
}
