using System;

namespace BusinessRules
{
	/// <summary>
	/// Summary description for IssueCollection.
	/// </summary>
	public class IssueCollection : BusinessObjectCollection
	{
		public IssueCollection()
		{
			return;
		}

		public override BusinessObject New()
		{
			return new Issue();
		}

		public void MyCustomGroupAction()
		{
			return;
		}
	}
}
