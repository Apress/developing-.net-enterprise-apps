using System;

namespace BusinessRules
{
	/// <summary>
	/// Summary description for User.
	/// </summary>
	public class User : BusinessObject
	{
		private int _UserID = 0;
		private string _Password = "";
		private string _Firstname = "";
		private string _Lastname = "";
		private string _EmailAddress = "";
		private int _UserRole = 0;
		private DateTime _CreateDate = DateTime.Now;


		public enum UserRoleType
		{
			Guest = 0, 
			TypicalUser = 1, 
			Manager = 2, 
			Administrator = 3
		}

		public User()
		{
		}

		public User( string strFirstname, string strLastname )
		{
			_Firstname = strFirstname;
			_Lastname = strLastname;
		}

		public User(string strFirstname, string strLastname, string strEmailAddress)
		{
			_Firstname = strFirstname;
			_Lastname = strLastname;
			_EmailAddress = strEmailAddress;
		}

		public int UserID
		{
			set
			{
				_UserID = value;
			}
			get
			{
				return _UserID;
			}
		}

		public string Password
		{
			set
			{
				_Password = value;
			}
			get
			{
				return _Password;
			}
		}

		public string Firstname
		{
			set
			{
				_Firstname = value;
			}
			get
			{
				return _Firstname;
			}
		}

		public string Lastname
		{
			set
			{
				_Lastname = value;
			}
			get
			{
				return _Lastname;
			}
		}

		public string EmailAddress
		{
			set
			{
				_EmailAddress = value;
			}
			get
			{
				return _EmailAddress;
			}
		}

		public int UserRole
		{
			set
			{
				_UserRole = value;
			}
			get
			{
				return _UserRole;
			}
		}

		public DateTime CreateDate
		{
			set
			{
				_CreateDate = value;
			}
			get
			{
				return _CreateDate;
			}
		}

		public bool ValidateLogin()
		{
			return false;
		}

	}
}
