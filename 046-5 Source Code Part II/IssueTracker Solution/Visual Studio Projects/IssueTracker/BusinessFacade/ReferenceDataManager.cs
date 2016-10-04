using System;
using System.Data;
using System.Data.SqlClient;
using DataAccess;
using System.Diagnostics;



namespace BusinessFacade
{
	/// <summary>
	/// Summary description for ReferenceDataManager.
	/// </summary>
	public class ReferenceDataManager
	{
		DataComponent _AppDataComponent;



		public ReferenceDataManager()
		{
			_AppDataComponent = new DataComponent();
		}



		public DataTable GetIssueTypes()
		{
			return _AppDataComponent.ReferenceDataSet.Val_IssueType;
		}

		
		
		public DataTable GetPriorities()
		{
			return _AppDataComponent.ReferenceDataSet.Val_Priority;
		}



		public DataTable GetStatuses()
		{
			return _AppDataComponent.ReferenceDataSet.Val_Status;
		}



		public string ExportDataToXml( string strFilename )
		{
			string strXmlData = "";

			try
			{
				//check to see if filename is valid
				if( strFilename != null && strFilename.Length > 0 )
				{
					System.IO.StreamWriter streamWrite = 
						new System.IO.StreamWriter( strFilename );

					_AppDataComponent.ReferenceDataSet.WriteXml( streamWrite, 
						XmlWriteMode.WriteSchema );

					streamWrite.Close();
				}
				else
				{
					//return xml output as a string
					strXmlData = _AppDataComponent.ReferenceDataSet.GetXml();
				}
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
			}

			return strXmlData;
		}

		
		
		public void ImportDataFromXml( string strXmlData, string strFilename )
		{
			try
			{
				if( strFilename != null && strFilename.Length > 0 )
				{
					//pull xml from file
					System.IO.StringReader streamRead = new System.IO.StringReader( 
						strFilename );

					_AppDataComponent.ReferenceDataSet.ReadXml( streamRead, 
						XmlReadMode.ReadSchema );
				}
				else
				{
					//pull xml from string argument
					System.IO.StringReader readerXml = new System.IO.StringReader( 
						strXmlData );

					_AppDataComponent.ReferenceDataSet.ReadXml( readerXml, 
						XmlReadMode.IgnoreSchema );
				}
			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
			}

			return;
		}

	
	
	}
}
