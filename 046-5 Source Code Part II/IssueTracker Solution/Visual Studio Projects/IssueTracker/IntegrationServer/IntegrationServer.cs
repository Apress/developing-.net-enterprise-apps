using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Messaging;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Xml;
using System.Xml.Xsl;
using System.Configuration;



namespace IntegrationServer
{
	public class IntegrationServer : System.ServiceProcess.ServiceBase
	{
		private System.ComponentModel.Container components = null;
		static HttpChannel _Channel;
		static int _PortNumber = 3200;
		ArrayList _ApplicationMappings = new ArrayList();

		
		
		public IntegrationServer()
		{
			InitializeComponent();
		}



		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new IntegrationServer() };
			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}



		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.ServiceName = "Service1";
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
				_Channel = new HttpChannel( _PortNumber );

				ChannelServices.RegisterChannel( _Channel );

				RemotingConfiguration.RegisterWellKnownServiceType(
					typeof( IntegrationServer ),
					"IntegrationServer.soap",
					WellKnownObjectMode.Singleton );
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "Integration Adapter";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
				systemLog.Dispose();
			}
		}
 


		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
		}



		private void LoadConfigurationData()
		{
			//object representing a single application-to-application mapping
			MappingEntry entry;

			//using XPath to retrieve the configuration data
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load( "IntegrationServer.exe.config" );
			XmlNode root = xmldoc.DocumentElement;

			try 
			{
				XmlNodeList xnodelist = 
					root.SelectNodes( "/configuration/AppMappings/Integration" ); 

				foreach( XmlNode xnode in xnodelist )
				{
					//create a new entry object
					entry = new MappingEntry();

					entry.SourceSchema = xnode.Attributes["SourceSchema"].Value;

					entry.DestinationSchema = 
						xnode.Attributes["DestinationSchema"].Value;

					entry.DestinationAddress = 
						xnode.Attributes["DestinationAddress"].Value;

					entry.TransformationFile = xnode.Attributes["Transformation"].Value;

					//add this mapping to the collection
					_ApplicationMappings.Add( entry );

				}
    
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


	
		public void ProcessRequest( string strData )
		{
			string strOutput = "";
			System.IO.StringWriter sWriter = null;

			try
			{
				strData.Replace( "\r", "" );
				strData.Replace( "\n", "" );

				//initialize the source document
				XmlDataDocument xmlDoc = new XmlDataDocument();
				xmlDoc.LoadXml( strData );

				//initialize the transformation engine
				XslTransform xslTransformer = new XslTransform();
				xslTransformer.Load( "c:\\transformation.xsl" );
             
				//initialize the output string writer
				sWriter = new System.IO.StringWriter();

				//transform the document
				xslTransformer.Transform( xmlDoc, null, sWriter );

				//forward the response to the destination adapter
				strOutput = sWriter.GetStringBuilder().ToString();
//JK				SendToAdapter( "http://127.0.0.1:3202", strOutput );
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
				systemLog.Dispose();
			}
			finally
			{
				sWriter.Close();
			}

			return;
		}



		public void ProcessIncomingMessages()
		{
			MessageQueue queue = null;
			Message message = null;

			do
			{
				try
				{
					queue = new MessageQueue( "server\\integrationQueue" );
					message = queue.Receive( new TimeSpan(0,0,3) );

					message.Formatter = new XmlMessageFormatter(
						new string[] {"System.String,mscorlib"} );

					ProcessRequest( message.Body.ToString() );
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
					message.Dispose();
					queue.Dispose();
				}

			}while ( true );

			return;
		}





	}
}
