using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess
{
	/// <summary>
	/// Summary description for DataComponent.
	/// </summary>
	public class DataComponent : System.ComponentModel.Component
	{
		private System.Data.SqlClient.SqlConnection sqlConnection;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterType;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterMailMessage;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterPriority;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterReport;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterStatus;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand5;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand4;
		private DataAccess.ReferenceDataSet _IssueTrackerReference;
		private System.ComponentModel.Container components = null;



		public SqlConnection Connection
		{
			set
			{
				sqlConnection = value;
			}
			get
			{
				if( sqlConnection.State == ConnectionState.Closed )
				{
					sqlConnection.Open();
				}

				return sqlConnection;
			}
		}


		
		public ReferenceDataSet ReferenceDataSet
		{
			get
			{
				return _IssueTrackerReference;
			}
		}
		


		public DataComponent(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();

			try
			{
				if( sqlConnection.State == ConnectionState.Closed )
				{
					sqlConnection.Open();
				}

				sqlDataAdapterPriority.Fill( _IssueTrackerReference );
				sqlDataAdapterStatus.Fill( _IssueTrackerReference );
				sqlDataAdapterReport.Fill( _IssueTrackerReference );
				sqlDataAdapterType.Fill( _IssueTrackerReference );
				sqlDataAdapterMailMessage.Fill( _IssueTrackerReference );
			}
			catch( Exception )
			{
			}

			return;
		}



		public DataComponent()
		{
			InitializeComponent();

			try
			{
				sqlDataAdapterPriority.Fill( _IssueTrackerReference );
				sqlDataAdapterStatus.Fill( _IssueTrackerReference );
				sqlDataAdapterReport.Fill( _IssueTrackerReference );
				sqlDataAdapterType.Fill( _IssueTrackerReference );
				sqlDataAdapterMailMessage.Fill( _IssueTrackerReference );
			}
			catch( Exception )
			{
			}

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



		public ReferenceDataSet GetEntireDataSet()
		{
			return _IssueTrackerReference;
		}



		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlConnection = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapterType = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterMailMessage = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterPriority = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterReport = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterStatus = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this._IssueTrackerReference = new DataAccess.ReferenceDataSet();
			((System.ComponentModel.ISupportInitialize)(this._IssueTrackerReference)).BeginInit();
			// 
			// sqlConnection
			// 
//			this.sqlConnection.ConnectionString = "workstation id=localhost;packet size=4096;integrated security=SSPI" +
//				";persist security info=False;";

			this.sqlConnection.ConnectionString = "workstation id=\"KANALAJ-02\";packet size=4096;integrated security=SSPI;data source" +
				"=\"KANALAJ-02\";persist security info=False;initial catalog=IssueTracker";
			// 
			// sqlDataAdapterType
			// 
			this.sqlDataAdapterType.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapterType.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapterType.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "Val_IssueType", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("TypeID", "TypeID"),
																																																						  new System.Data.Common.DataColumnMapping("TypeLabel", "TypeLabel")})});
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "[app_TypeInsert]";
			this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand1.Connection = this.sqlConnection;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.UniqueIdentifier, 16, "TypeID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TypeLabel", System.Data.SqlDbType.VarChar, 32, "TypeLabel"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[app_TypeSelect]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapterMailMessage
			// 
			this.sqlDataAdapterMailMessage.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapterMailMessage.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapterMailMessage.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "Val_MailMessage", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("MailMessageID", "MailMessageID"),
																																																								   new System.Data.Common.DataColumnMapping("Format", "Format"),
																																																								   new System.Data.Common.DataColumnMapping("Priority", "Priority"),
																																																								   new System.Data.Common.DataColumnMapping("Subject", "Subject"),
																																																								   new System.Data.Common.DataColumnMapping("Body", "Body")})});
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "[app_MailMessageInsert]";
			this.sqlInsertCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand2.Connection = this.sqlConnection;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MailMessageID", System.Data.SqlDbType.Int, 4, "MailMessageID"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Format", System.Data.SqlDbType.Int, 4, "Format"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Priority", System.Data.SqlDbType.Int, 4, "Priority"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Subject", System.Data.SqlDbType.VarChar, 128, "Subject"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Body", System.Data.SqlDbType.VarChar, 2147483647, "Body"));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[app_MailMessageSelect]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapterPriority
			// 
			this.sqlDataAdapterPriority.InsertCommand = this.sqlInsertCommand3;
			this.sqlDataAdapterPriority.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapterPriority.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "Val_Priority", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("PriorityID", "PriorityID"),
																																																							 new System.Data.Common.DataColumnMapping("PriorityLabel", "PriorityLabel")})});
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "[app_PriorityInsert]";
			this.sqlInsertCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand3.Connection = this.sqlConnection;
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PriorityID", System.Data.SqlDbType.UniqueIdentifier, 16, "PriorityID"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PriorityLabel", System.Data.SqlDbType.VarChar, 32, "PriorityLabel"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "[app_PrioritySelect]";
			this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand3.Connection = this.sqlConnection;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapterReport
			// 
			this.sqlDataAdapterReport.InsertCommand = this.sqlInsertCommand4;
			this.sqlDataAdapterReport.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapterReport.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "Val_Reports", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("ReportID", "ReportID"),
																																																						  new System.Data.Common.DataColumnMapping("ReportLabel", "ReportLabel"),
																																																						  new System.Data.Common.DataColumnMapping("ReportFilePath", "ReportFilePath")})});
			// 
			// sqlInsertCommand4
			// 
			this.sqlInsertCommand4.CommandText = "[app_ReportInsert]";
			this.sqlInsertCommand4.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand4.Connection = this.sqlConnection;
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReportID", System.Data.SqlDbType.UniqueIdentifier, 16, "ReportID"));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReportLabel", System.Data.SqlDbType.VarChar, 32, "ReportLabel"));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReportFilePath", System.Data.SqlDbType.VarChar, 256, "ReportFilePath"));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "[app_ReportSelect]";
			this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand4.Connection = this.sqlConnection;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapterStatus
			// 
			this.sqlDataAdapterStatus.InsertCommand = this.sqlInsertCommand5;
			this.sqlDataAdapterStatus.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapterStatus.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "Val_Status", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("StatusID", "StatusID"),
																																																						 new System.Data.Common.DataColumnMapping("StatusLabel", "StatusLabel")})});
			// 
			// sqlInsertCommand5
			// 
			this.sqlInsertCommand5.CommandText = "[app_StatusInsert]";
			this.sqlInsertCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand5.Connection = this.sqlConnection;
			this.sqlInsertCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StatusID", System.Data.SqlDbType.UniqueIdentifier, 16, "StatusID"));
			this.sqlInsertCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StatusLabel", System.Data.SqlDbType.VarChar, 32, "StatusLabel"));
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "[app_StatusSelect]";
			this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand5.Connection = this.sqlConnection;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// _IssueTrackerReference
			// 
			this._IssueTrackerReference.DataSetName = "ReferenceDataSet";
			this._IssueTrackerReference.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this._IssueTrackerReference)).EndInit();

		}
		#endregion

	}
}
