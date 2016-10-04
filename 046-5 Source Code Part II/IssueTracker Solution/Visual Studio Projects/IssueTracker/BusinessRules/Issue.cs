using System;

namespace BusinessRules
{
	/// <summary>
	/// Summary description for Issue.
	/// </summary>
	public class Issue : BusinessObject
	{
		private int _IssueID;
		private int _TypeID;
		private int _UserID;
		private int _StatusID;
		private int _PriorityID;
		private string _Summary;
		private string _Description;
		private DateTime _EntryDate;



		//property accessor implementation
		public int IssueID
		{
			get { return _IssueID; }
			set { _IssueID = value; }
		}



		public int TypeID
		{
			get { return _TypeID; }
			set { _TypeID = value; }
		}



		public int UserID
		{
			get { return _UserID; }
			set { _UserID = value; }
		}



		public DateTime EntryDate
		{
			get { return _EntryDate; }
			set { _EntryDate = value; }
		}



		public int StatusID
		{
			get { return _StatusID; }
			set { _StatusID = value; }
		}



		public String Summary
		{
			get { return _Summary; }
			set { _Summary = value; }
		}



		public String Description
		{
			get { return _Description; }
			set { _Description = value; }
		}



		public int PriorityID
		{
			get { return _PriorityID; }
			set { _PriorityID = value; }
		}



		public string Validate()
		{
			string strErrorMessage = "";

			if( _TypeID == 0 )
				strErrorMessage += "Issue Type is not set. ";

			if( _StatusID == 0 )
				strErrorMessage += "Issue Status is not set. ";

			if( _PriorityID == 0 )
				strErrorMessage += "Issue Priority is not set. ";

			if( _Summary.Length == 0 )
				strErrorMessage += "Issue Summary has no value. ";

			if( _Summary.Length > 64 )
				strErrorMessage += "Issue Summary is too long. ";

			if( _Description.Length == 0 )
				strErrorMessage += "Issue Description has no value. ";

			if( _Description.Length > 255 )
				strErrorMessage += "Issue Description is too long. ";

			return strErrorMessage;
		}



	}
}
