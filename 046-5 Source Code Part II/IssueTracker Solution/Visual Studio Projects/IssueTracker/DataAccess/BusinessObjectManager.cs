using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using BusinessRules;



namespace DataAccess
{
	/// <summary>
	/// Summary description for BusinessObjectManager.
	/// </summary>
	public class BusinessObjectManager
	{
		private DataComponent dataComponent = new DataComponent();



		public BusinessObjectManager()
		{
		}



		public bool SelectOne( BusinessObject objSource, int intObjectID )
		{
			bool boolStatus = false;
			string strObject;
			string strStoredProc;
			SqlParameter parameter;
			SqlCommand command;

			try
			{
				//get the object name
				Type objType = objSource.GetType();
				strObject = objType.FullName.Substring( objType.FullName.IndexOf(".")+1);

				//get the stored procedure name
				strStoredProc = "app_";
				strStoredProc += strObject;
				strStoredProc += "Select";

				//initialize the command
				command = new SqlCommand( strStoredProc, dataComponent.Connection );
				command.CommandType = CommandType.StoredProcedure;

				//add the ID parameter
				parameter = new SqlParameter( "@" + strObject + "ID", SqlDbType.Int );
				parameter.Direction = ParameterDirection.Input;
				parameter.Value = intObjectID;
				command.Parameters.Add( parameter );

				//execute query
				SqlDataReader reader = command.ExecuteReader();

				if( reader.Read() )
				{
					//examine results and set business object, set return code to true
					for( int intIndex = 0; intIndex < reader.FieldCount; intIndex++ )
					{
						string strColName = reader.GetName( intIndex );
						PropertyInfo field = objType.GetProperty( strColName );
						field.SetValue( objSource, reader.GetValue( intIndex ), null );
					}

					boolStatus = true;
				}
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				dataComponent.Connection.Close();
			}

			return boolStatus;
		}



		public bool SelectAll( BusinessObjectCollection objSource )
		{
			bool boolStatus = false;
			string strObject;
			string strStoredProc;
			SqlCommand command;

			try
			{
				//get the object name
				Type objType = objSource.GetType();
				strObject = objType.FullName.Substring( objType.FullName.IndexOf(".")+1);
				strObject = strObject.Replace( "Collection", "" );

				//get the stored procedure name
				strStoredProc = "app_";
				strStoredProc += strObject;
				strStoredProc += "SelectAll";

				//initialize the command
				command = new SqlCommand( strStoredProc, dataComponent.Connection );
				command.CommandType = CommandType.StoredProcedure;

				//execute query
				SqlDataReader reader = command.ExecuteReader();

				while( reader.Read() )
				{
					BusinessObject newObject = objSource.New();
					objType = newObject.GetType();

					for( int intIndex = 0; intIndex < reader.FieldCount; intIndex++ )
					{
						string strColName = reader.GetName( intIndex );
						PropertyInfo field = objType.GetProperty( strColName );
//JK						field.SetValue( objSource, reader.GetValue( intIndex ), null );
						field.SetValue( newObject, reader.GetValue( intIndex ), null );
					}

					objSource.Add( newObject );
				}

				boolStatus = true;
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				dataComponent.Connection.Close();
			}

			return boolStatus;
		}



		public bool Insert( BusinessObject objSource )
		{
			bool boolStatus = false;
			string strObject;
			string strStoredProc;
			SqlParameter parameter;
			SqlCommand command;

			try
			{
				//get the object name
				Type objType = objSource.GetType();
				strObject = objType.FullName.Substring( objType.FullName.IndexOf(".")+1);

				//get the stored procedure name
				strStoredProc = "app_";
				strStoredProc += strObject;
				strStoredProc += "Insert";

				//initialize the command
				command = new SqlCommand( strStoredProc, dataComponent.Connection );
				command.CommandType = CommandType.StoredProcedure;

				//add the parameters
				parameter = new SqlParameter( "@RETURN_VALUE", SqlDbType.Int );
				parameter.Direction = ParameterDirection.ReturnValue;
				command.Parameters.Add( parameter );

				PropertyInfo[] fields = objType.GetProperties();

				for( int intIndex = 0; intIndex < fields.Length; intIndex++ )
				{
					parameter = new SqlParameter( "@" + fields[intIndex].Name,
						fields[intIndex].PropertyType );

					parameter.Direction = ParameterDirection.Input;
					parameter.Value = fields[intIndex].GetValue( objSource, null );
					command.Parameters.Add( parameter );
				}

				//execute query
				command.ExecuteNonQuery();

				//return the results of the procedure
				if( (Int32)command.Parameters["@RETURN_VALUE"].Value == 0 )
					boolStatus = true;
			}
			catch( SqlException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				dataComponent.Connection.Close();
			}

			return boolStatus;
		}



		public bool Update( BusinessObject objSource )
		{
			bool boolStatus = false;
			string strObject;
			string strStoredProc;
			SqlParameter parameter;
			SqlCommand command;

			try
			{
				//get the object name
				Type objType = objSource.GetType();
				strObject = objType.FullName.Substring( objType.FullName.IndexOf(".")+1);

				//get the stored procedure name
				strStoredProc = "app_";
				strStoredProc += strObject;
				strStoredProc += "Update";

				//initialize the command
				command = new SqlCommand( strStoredProc, dataComponent.Connection );
				command.CommandType = CommandType.StoredProcedure;

				//add the parameters
				parameter = new SqlParameter( "@RETURN_VALUE", SqlDbType.Int );
				parameter.Direction = ParameterDirection.ReturnValue;
				command.Parameters.Add( parameter );

				//add the original id parameter
				parameter = new SqlParameter( "@Original_" + strObject + "ID",
					SqlDbType.Int );
				parameter.Direction = ParameterDirection.Input;
				FieldInfo field = objType.GetField( strObject + "ID" );
				parameter.Value = (int)field.GetValue( objSource );
				command.Parameters.Add( parameter );

				//original modified date parameter for concurrency check
				parameter = new SqlParameter( "@Original_ModifiedDate",
					SqlDbType.DateTime );
				parameter.Direction = ParameterDirection.Input;
				field = objType.GetField( "RowModified" );
				parameter.Value = (int)field.GetValue( objSource );
				command.Parameters.Add( parameter );

				//update the modified date
				objSource.RowModified = DateTime.Now;

				PropertyInfo[] fields = objType.GetProperties();

				for( int intIndex = 0; intIndex < fields.Length; intIndex++ )
				{
					parameter = new SqlParameter( "@" + fields[intIndex].Name,
						fields[intIndex].PropertyType );

					parameter.Direction = ParameterDirection.Input;
					parameter.Value = fields[intIndex].GetValue( objSource, null );
					command.Parameters.Add( parameter );
				}

				//execute query
				command.ExecuteNonQuery();

				//return the results of the procedure
				if( (Int32)command.Parameters["@RETURN_VALUE"].Value == 0 )
					boolStatus = true;
			}
			catch( SqlException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				dataComponent.Connection.Close();
			}

			return boolStatus;
		}



		public bool Delete( BusinessObject objSource )
		{
			bool boolStatus = false;
			string strObject;
			string strStoredProc;
			SqlParameter parameter;
			SqlCommand command;

			try
			{
				//get the object name
				Type objType = objSource.GetType();
				strObject = objType.FullName.Substring( objType.FullName.IndexOf(".")+1);

				//get the stored procedure name
				strStoredProc = "app_";
				strStoredProc += strObject;
				strStoredProc += "Delete";

				//initialize the command
				command = new SqlCommand( strStoredProc, dataComponent.Connection );
				command.CommandType = CommandType.StoredProcedure;

				//add the parameters
				parameter = new SqlParameter( "@RETURN_VALUE", SqlDbType.Int );
				parameter.Direction = ParameterDirection.ReturnValue;
				command.Parameters.Add( parameter );

				//add the ID parameter
				parameter = new SqlParameter( "@Original_" + strObject + "ID",
					SqlDbType.Int );
				parameter.Direction = ParameterDirection.Input;
				PropertyInfo field = objType.GetProperty( strObject + "ID" );
				parameter.Value = (int)field.GetValue( objSource, null );
				command.Parameters.Add( parameter );

				//original modified date parameter for concurrency check
				parameter = new SqlParameter( "@Original_ModifiedDate", 
					SqlDbType.DateTime );
				parameter.Direction = ParameterDirection.Input;
				field = objType.GetProperty( "RowModified" );
				parameter.Value = (int)field.GetValue( objSource, null );
				command.Parameters.Add( parameter );

				//update the modified date
				objSource.RowModified = DateTime.Now;

				//execute query
				command.ExecuteNonQuery();

				//return the results of the procedure
				if( (Int32)command.Parameters["@RETURN_VALUE"].Value == 0 )
					boolStatus = true;
			}
			catch( SqlException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				dataComponent.Connection.Close();
			}

			return boolStatus;
		}



		public string SelectOneAsXML( BusinessObject objSource, int intObjectID )
		{
			bool boolStatus = false;
			string strObject;
			string strStoredProc;
			string strOutput = "";
			SqlParameter parameter;
			SqlCommand command;

			try
			{
				//get the object name
				Type objType = objSource.GetType();
				strObject = objType.FullName.Substring( objType.FullName.IndexOf(".")+1);

				//get the stored procedure name
				strStoredProc = "app_";
				strStoredProc += strObject;
				strStoredProc += "SelectAsXml";

				//initialize the command
				command = new SqlCommand( strStoredProc, dataComponent.Connection );
				command.CommandType = CommandType.StoredProcedure;

				//add the ID parameter
				parameter = new SqlParameter( "@" + strObject + "ID", SqlDbType.Int );
				parameter.Direction = ParameterDirection.Input;
				parameter.Value = intObjectID;
				command.Parameters.Add( parameter );

				//execute query
				XmlReader reader = command.ExecuteXmlReader();
				
				reader.MoveToContent();
				strOutput = reader.ReadOuterXml();
				reader.Close();
				
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				dataComponent.Connection.Close();
			}

			return strOutput;
		}

	
	
	}
}
