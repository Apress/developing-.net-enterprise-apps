using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using SystemFrameworks;
using BusinessRules;



namespace AnalysisService
{
	public class AnalysisService : System.ServiceProcess.ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;



		public AnalysisService()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();
		}



		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new AnalysisService(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new AnalysisService() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}



		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.ServiceName = "AnalysisService";
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
			Thread listeningThread = new Thread( new ThreadStart(MessageListener) );
			listeningThread.Start();
 
			return;
		}



		public static void MessageListener()
		{
			Issue objIssue = null;

			MessagingFramework messagingServices = new MessagingFramework();
			messagingServices.ProcessName = "AnalysisService";
			messagingServices.CreateQueues();

			while( true )
			{
				objIssue = (Issue)messagingServices.ReceiveBusinessObject();
				//perform analysis on issue object

				Thread.Sleep(1000);
			}

			return;
		}  
 


		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
		}



	}
}
