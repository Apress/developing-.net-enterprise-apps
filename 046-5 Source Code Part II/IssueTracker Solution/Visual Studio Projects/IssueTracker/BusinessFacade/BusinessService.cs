using System;
using System.Diagnostics;



namespace BusinessFacade
{
	/// <summary>
	/// Summary description for BusinessService.
	/// </summary>
	public abstract class BusinessService
	{
		EventLog _SystemLog = new EventLog();



		public BusinessService()
		{
		}



		public void LogEvent( string strMessage )
		{
			try
			{
				_SystemLog.Source = "IssueTracker";
				_SystemLog.WriteEntry( strMessage, EventLogEntryType.Error, 0 );
			}
			catch( Exception x )
			{
				Debug.WriteLine( "Unable to write to Event Log." );
				Debug.WriteLine( "Event Massage:" + strMessage );
			}
			return;
		}



	}
}
