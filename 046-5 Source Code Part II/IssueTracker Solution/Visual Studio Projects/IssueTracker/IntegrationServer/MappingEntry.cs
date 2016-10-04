using System;

namespace IntegrationServer
{
	/// <summary>
	/// Summary description for MappingEntry.
	/// </summary>
	class MappingEntry
	{
		string _SourceSchema;
		string _DestinationSchema;
		string _DestinationAddress;
		string _TransformationFile;

		public string SourceSchema
		{
			get
			{
				return _SourceSchema;
			}
			set
			{
				_SourceSchema = value;
			}
		}

		public string DestinationSchema
		{
			get
			{
				return _DestinationSchema;
			}
			set
			{
				_DestinationSchema = value;
			}
		}

		public string DestinationAddress
		{
			get
			{
				return _DestinationAddress;
			}
			set
			{
				_DestinationAddress = value;
			}
		}

		public string TransformationFile
		{
			get
			{
				return _TransformationFile;
			}
			set
			{
				_TransformationFile = value;
			}
		}

	}
}
