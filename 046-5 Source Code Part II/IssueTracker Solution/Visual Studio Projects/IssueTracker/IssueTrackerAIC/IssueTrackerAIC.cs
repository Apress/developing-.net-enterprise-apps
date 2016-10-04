using System;
using System.EnterpriseServices;



namespace IssueTrackerAIC
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class IssueTrackerAIC : ServicedComponent, IBTSAppIntegration
	{
		public IssueTrackerAIC()
		{
		}

		string IBTSAppIntegration.ProcessMessage( string strDocument )
		{
			return "Welcome to BizTalk!";
		}
	}
}
