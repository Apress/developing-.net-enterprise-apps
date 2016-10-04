using System;
using BusinessRules;
using DataAccess;



namespace BusinessFacade
{
	/// <summary>
	/// Summary description for UserManager.
	/// </summary>
	public class UserManager
	{
		private static UserObjectManager _ObjectManager = new UserObjectManager();



		public UserManager()
		{
		}



		public static User GetUser( string strEmailAddress, string strPassword )
		{
			User objUser = null;

			objUser = _ObjectManager.ValidateLoginWithProfile( strEmailAddress, 
				strPassword );

			return objUser;
		}
	}
}
