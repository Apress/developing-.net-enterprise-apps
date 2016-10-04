using System;
using BusinessRules;
using DataAccess;



namespace BusinessFacade
{
	/// <summary>
	/// Summary description for IssueManager.
	/// </summary>
	public class IssueManager
	{
		private BusinessObjectManager _ObjectManager = new BusinessObjectManager();



		public IssueManager()
		{
		}



		public void SaveIssue( Issue argIssue )
		{
			_ObjectManager.Insert( argIssue );
		}



		public Issue GetIssue( int intIssueID )
		{
			Issue objIssue = new Issue();

			_ObjectManager.SelectOne( objIssue, intIssueID );
			return objIssue;
		}



		public IssueCollection GetAllIssues()
		{
			IssueCollection objIssueCollection = new IssueCollection();

			_ObjectManager.SelectAll( objIssueCollection );
			return objIssueCollection;
		}



		public string GetSpecificIssueXml( int argLongIssueID )
		{
			string strOutput;
			Issue objIssue = new Issue();

			strOutput = _ObjectManager.SelectOneAsXML( objIssue, argLongIssueID );
			return strOutput;
		} 

	
	
	}
}
