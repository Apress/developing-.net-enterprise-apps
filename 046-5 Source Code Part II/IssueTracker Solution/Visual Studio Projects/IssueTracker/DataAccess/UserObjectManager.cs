using System;
using System.Diagnostics;
using System.DirectoryServices;
using BusinessRules;



namespace DataAccess
{
	/// <summary>
	/// Summary description for UserObjectManager.
	/// </summary>
	public class UserObjectManager
	{
		public UserObjectManager()
		{
		}



		public DirectoryEntry ValidateLogin( string strUsername, string strPassword )
		{
			DirectoryEntry dirResult = null;

			try
			{
				//initialize the root seaerch object
				DirectoryEntry dirEntry = new DirectoryEntry( "LDAP://srv-enterprise", 
					strUsername, strPassword );

				//initialize the search object
				DirectorySearcher dirSearcher = new DirectorySearcher( dirEntry );

				//set the filter to retrieve the specific user
				dirSearcher.Filter = "(&(objectClass=user)(mail=" +strUsername+ "))";
				dirSearcher.SearchScope = SearchScope.Subtree;

				//execute the search
				SearchResult searchResult = dirSearcher.FindOne();
				dirResult = searchResult.GetDirectoryEntry();

			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message + " for user " + strUsername, 
					EventLogEntryType.Error, 0 );
			}

			return dirResult;
		}



		public User GetUserProfile( DirectoryEntry entryUser )
		{
			User objUser = new User();

			try
			{
				//extract default user attributes
				objUser.Firstname = entryUser.Properties["givenName"][0].ToString();
				objUser.Lastname = entryUser.Properties["sn"][0].ToString();
				objUser.EmailAddress = entryUser.Properties["mail"][0].ToString();

				//extract application specific user attribute
				if( entryUser.Properties["memberOf"][0].ToString().IndexOf( 
					"IssueTrackerUser" ) > 0 )
					objUser.UserRole = (int)User.UserRoleType.TypicalUser;

				if( entryUser.Properties["memberOf"][0].ToString().IndexOf( 
					"IssueTrackerManager" ) > 0 )
					objUser.UserRole = (int)User.UserRoleType.Manager;

				if( entryUser.Properties["memberOf"][0].ToString().IndexOf( 
					"IssueTrackerAdministrator" ) > 0 )
					objUser.UserRole = (int)User.UserRoleType.Administrator;

			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
			}

			return objUser;
		}



		public User GetUserProfile_2( DirectoryEntry entryUser )
		{
			User objUser = new User();

			try
			{
				//extract default user attributes
				objUser.Firstname = entryUser.Properties["givenName"][0].ToString();
				objUser.Lastname = entryUser.Properties["sn"][0].ToString();
				objUser.EmailAddress = entryUser.Properties["mail"][0].ToString();

				//extract application specific user attribute
				objUser.UserRole = (int)entryUser.Properties["IssueTrackerRole"][0];

			}
			catch( Exception x )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
			}

			return objUser;
		}



		public User ValidateLoginWithProfile( string strUsername, string strPassword )
		{
			return GetUserProfile( ValidateLogin( strUsername, strPassword ) );
		}



	}
}
