using System;

namespace IntegrationCommon
{
	/// <summary>
	/// Summary description for IIntegrationServer.
	/// </summary>
	public interface IIntegrationServer
	{
		void ProcessRequest( string strData );
		void SendToAdapter( string strDestination, string strData );
		void LoadConfigurationData();
	}
}
