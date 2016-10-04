using System;




namespace BusinessRules
{
	/// <summary>
	/// Summary description for MailMessageTemplate.
	/// </summary>
	public class MailMessageTemplate : BusinessObject
	{
		public int MailMessageID = 0;
		public int Format = 0;
		public int Priority = 0;
		public string Subject = "";
		public string Body = "";

		
		
		public MailMessageTemplate()
		{
		}

		
		
	}
}
