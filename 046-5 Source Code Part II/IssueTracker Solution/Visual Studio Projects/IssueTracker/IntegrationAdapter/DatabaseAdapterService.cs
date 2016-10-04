using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Xml;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Messaging;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Configuration;



namespace IntegrationAdapter
{
	public class DatabaseAdapterService : System.ServiceProcess.ServiceBase,
		IntegrationCommon.IIntegrationAdapter
	{
		private System.IO.FileSystemWatcher _DirectoryWatch;
		private System.ComponentModel.Container components = null;
		private static HttpChannel _Channel = new HttpChannel();
		private static string _IntegrationServerPath = "http://127.0.0.1:3200";
		private static IntegrationCommon.IIntegrationServer _IntegrationService;



		public DatabaseAdapterService()
		{
			InitializeComponent();
		}



		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new DatabaseAdapterService() };
			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}



		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._DirectoryWatch = new System.IO.FileSystemWatcher();
			((System.ComponentModel.ISupportInitialize)(this._DirectoryWatch)).BeginInit();
			// 
			// _DirectoryWatch
			// 
			this._DirectoryWatch.EnableRaisingEvents = true;
			this._DirectoryWatch.Changed += new System.IO.FileSystemEventHandler(this._DirectoryWatch_Changed);
			// 
			// DatabaseAdapterService
			// 
			this.ServiceName = "Service1";
			((System.ComponentModel.ISupportInitialize)(this._DirectoryWatch)).EndInit();

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



		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			try
			{
				LoadConfigurationData();

				ChannelServices.RegisterChannel( _Channel );

				_IntegrationService = (IntegrationCommon.IIntegrationServer)Activator.GetObject(
					typeof( IntegrationCommon.IIntegrationServer ),
					_IntegrationServerPath + "/IntegrationServer.soap" );
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
				systemLog.Dispose();
			}

			return;
		}
 


		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
		}



		public void LoadConfigurationData()
		{
			AppSettingsReader settings = new AppSettingsReader();

			_DirectoryWatch.Filter = (string)settings.GetValue( "FileType", 
				typeof(string) );

			_DirectoryWatch.Path = (string)settings.GetValue( "Directory", 
				typeof(string));

			return;
		}



		public string ReadRecord( int intRecordID )
		{
			string stroutput = null;
			XmlReader reader = null;
			SqlConnection connection = null;
			SqlParameter parameter = null;
			SqlCommand command = null;

			try
			{
				//later, connection string is retrieved from a configuration file
				connection = new SqlConnection( 
					"workstation id=MONTEREY;packet size=4096;user id=sa;data " + 
					"source=MONTEREY;persist security info=False;" + 
					"initial catalog=DemoApp" );

				connection.Open();

				command = new SqlCommand( "adapter_ReadRecord", connection );
				command.CommandType = CommandType.StoredProcedure;

				//add the ID parameter
				parameter = new SqlParameter( "@ID", SqlDbType.Int );
				parameter.Direction = ParameterDirection.Input;
				parameter.Value = intRecordID;
				command.Parameters.Add( parameter );

				reader = command.ExecuteXmlReader();
				reader.MoveToContent();

				stroutput = reader.ReadOuterXml();
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "Integration Adapter";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
				systemLog.Dispose();
			}
			finally
			{
				reader.Close();
				connection.Close();
				connection.Dispose();
				command.Dispose();
			}

			return SendToServer( stroutput );
		}



		public string ReadAllRecords()
		{
			string strOutput = "";
			OleDbConnection connection = null;
			OleDbDataAdapter adapter = null;
			DataSet datasetFileData = null;

			try
			{
				connection = new OleDbConnection(
					"Provider=Microsoft.Jet.OLEDB.4.0;" +
					"Data Source=" + "c:\\" + ";" +
					"Extended Properties=\"text;HDR=YES;FMT=Delimited\"" );

				adapter = new OleDbDataAdapter( "select ID, SubmittedOn, Priority, " +
					"Severity, Condition, ShortDescription, ComposedBy from " +
					"appdemo.csv", connection );

				datasetFileData = new DataSet( "DemoDat" );

				adapter.Fill( datasetFileData );
				strOutput = datasetFileData.GetXml();
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "Integration Adapter";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
				systemLog.Dispose();
			}
			finally
			{
				connection.Close();
				connection.Dispose();
				adapter.Dispose();
				datasetFileData.Dispose();
			}

			return SendToServer( strOutput );
		}



		public bool WriteRecords( string strData )
		{
			return false;
		}



		public string SendToServer( string strData )
		{
			MessageQueue queue = null;


			try
			{
				queue = new MessageQueue( "server\\integrationQueue" );
				queue.Send( "AppDemo", strData );
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "Integration Adapter";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
				systemLog.Dispose();
			}
			finally
			{
				queue.Dispose();
			}

			return strData;
		}



		private void _DirectoryWatch_Changed(object sender, System.IO.FileSystemEventArgs e)
		{
			//read the file and send to the server
			ReadAllRecords();
			return;
		}


	}
}
