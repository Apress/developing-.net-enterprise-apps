using System;

namespace BusinessRules
{
	/// <summary>
	/// Summary description for BusinessObject.
	/// </summary>
	public abstract class BusinessObject
	{
		private DateTime _RowModified;

		public BusinessObject()
		{
			return;
		}
		public bool Select()
		{
			return false;
		}
		public bool Insert()
		{
			return false;
		}
		public bool Update()
		{
			return false;
		}
		public bool Delete()
		{
			return false;
		}
		public bool Validate()
		{
			return false;
		}

		public DateTime RowModified
		{
			set
			{
				_RowModified = value;
			}
			get
			{
				return _RowModified;
			}
		}
	}
}
