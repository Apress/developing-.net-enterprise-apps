using System;
using System.Collections;
using System.Diagnostics;
using System.Messaging;
using BusinessRules;



namespace SystemFrameworks
{
	/// <summary>
	/// Summary description for MessagingFramework.
	/// </summary>
	public class MessagingFramework
	{
		private string _ProcessName = "";
		private string _QueueInboxName = "";
		private string _QueueOutboxName = "";
		private string _QueueErrorsName = "";

		public enum QueueType
		{
			Inbox = 1,
			Outbox = 2,
			Errors = 3
		}

		public MessagingFramework()
		{
			_ProcessName = "Undefined";
			_QueueInboxName = ".\\private$\\" + _ProcessName + "Inbox";
			_QueueOutboxName = ".\\private$\\" + _ProcessName + "Outbox";
			_QueueErrorsName = ".\\private$\\" + _ProcessName + "Errors";

			return;
		}

		public MessagingFramework( string strProcessName )
		{
			_ProcessName = strProcessName;
			_QueueInboxName = ".\\private$\\" + _ProcessName + "Inbox";
			_QueueOutboxName = ".\\private$\\" + _ProcessName + "Outbox";
			_QueueErrorsName = ".\\private$\\" + _ProcessName + "Errors";

			return;
		}

		public string ProcessName
		{
			get
			{
				return _ProcessName;
			}
			set
			{
				_ProcessName = value;
				_QueueInboxName = ".\\private$\\" + _ProcessName + "Inbox";
				_QueueOutboxName = ".\\private$\\" + _ProcessName + "Outbox";
				_QueueErrorsName = ".\\private$\\" + _ProcessName + "Errors";
			}
		}



		public void CreateQueues()
		{
			try
			{
				//create the inbox queue
				if( ! MessageQueue.Exists( _QueueInboxName ) )
					MessageQueue.Create( _QueueInboxName );

				//create the outbox queue
				if( ! MessageQueue.Exists( _QueueOutboxName ) )
					MessageQueue.Create( _QueueOutboxName );

				//create the errors queue
				if( ! MessageQueue.Exists( _QueueErrorsName ) )
					MessageQueue.Create( _QueueErrorsName );

			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}

			return;
		}



		public void DeleteQueues()
		{
			try
			{
				//delete the inbox queue
				if( ! MessageQueue.Exists( _QueueInboxName ) )
					MessageQueue.Delete( _QueueInboxName );

				//delete the outbox queue
				if( ! MessageQueue.Exists( _QueueOutboxName ) )
					MessageQueue.Delete( _QueueOutboxName );

				//delete the errors queue
				if( ! MessageQueue.Exists( _QueueErrorsName ) )
					MessageQueue.Delete( _QueueErrorsName );

			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}

			return;
		} 



		public void SendMessage( string strTargetProcess, string strSubject, 
			string strBody )
		{
			MessageQueue queue = null;
			string strTargetQueueName;

			try
			{
				strTargetQueueName = ".\\private$\\" + strTargetProcess + "Inbox";

				if( MessageQueue.Exists( strTargetQueueName ) )
				{
					queue = new MessageQueue( strTargetQueueName );
					queue.Send( strSubject, strBody );
				}
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return;
		}



		public Message ReceiveMessage()
		{
			MessageQueue queue = null;
			Message message = null;

			try
			{
				queue = new MessageQueue( _QueueInboxName );

				//retrieve message from the queue
				message = queue.Receive();
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return message;
		}



		public Message PeekMessages( string strLookFor )
		{
			MessageQueue queue = null;
			Message message = null;

			try
			{
				queue = new MessageQueue( _QueueInboxName );
				message = queue.Peek();

				string[] types = { "System.String" };
				message.Formatter = new XmlMessageFormatter( types );

				if( message.Label.IndexOf( strLookFor ) >= 0 )
					return message;
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return message;
		}



		public MessageEnumerator ReceiveAllMessages()
		{
			MessageQueue queue = null;
			MessageEnumerator enumerator = null;

			try
			{
				queue = new MessageQueue( _QueueInboxName );

				//retrieve all messages from the queue
				enumerator = (MessageEnumerator)(queue.GetEnumerator());
			}
			catch( Exception exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return enumerator;
		}



		public ArrayList ListAllQueues()
		{
			ArrayList arrayQueues = new ArrayList();

			try
			{
				arrayQueues.AddRange( MessageQueue.GetPrivateQueuesByMachine( "." ) );
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}

			return arrayQueues;
		}



		public ArrayList ListApplicationQueues()
		{
			ArrayList arrayQueues = new ArrayList();

			try
			{
				arrayQueues.AddRange( 
					MessageQueue.GetPublicQueuesByLabel( _QueueInboxName ) );

				arrayQueues.AddRange( 
					MessageQueue.GetPublicQueuesByLabel( _QueueOutboxName ) );

				arrayQueues.AddRange( 
					MessageQueue.GetPublicQueuesByLabel( _QueueErrorsName ) );
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}

			return arrayQueues;
		}



		public void EmptyQueue( MessagingFramework.QueueType queueType )
		{
			MessageQueue queue = null;

			try
			{
				switch( queueType )
				{
					case QueueType.Inbox:
						queue = new MessageQueue( _QueueInboxName );
						break;

					case QueueType.Outbox:
						queue = new MessageQueue( _QueueOutboxName );
						break;

					case QueueType.Errors:
						queue = new MessageQueue( _QueueErrorsName );
						break;
				}

				queue.Purge();
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}

			return;
		}



		public void SendMessage( string strTargetProcess, string strSubject, 
			string strBody, int intMaxWaitSeconds )
		{
			string strTargetQueueName;
			string strTargetErrorsQueueName;

			try
			{
				strTargetQueueName = ".\\private$\\" + strTargetProcess + "Inbox";
				strTargetErrorsQueueName = ".\\private$\\" + strTargetProcess + "Errors";

				if( MessageQueue.Exists( strTargetQueueName ) )
				{
					MessageQueue queue = new MessageQueue( strTargetQueueName );
					MessageQueue queueErrors = 
						new MessageQueue( strTargetErrorsQueueName );

					Message message = new Message();
					message.Label = strSubject;
					message.Body = strBody;
					message.TimeToBeReceived = new TimeSpan( 0, 0, intMaxWaitSeconds );

					message.AdministrationQueue = queueErrors;
					message.AcknowledgeType = AcknowledgeTypes.NegativeReceive;

					queue.Send( message );
				}
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}

			return;
		}



		public void ResendMessage()
		{
			MessageQueue queueErrors = null;
			MessageQueue queueDestination = null;
			ArrayList messagesArray = new ArrayList();

			try
			{
				queueErrors = new MessageQueue( _QueueErrorsName );
				messagesArray.AddRange( queueErrors.GetAllMessages() );

				foreach( Message message in messagesArray )
				{ 
					queueDestination = message.ResponseQueue;
					queueDestination.Send( message );
				}

				queueErrors.Purge();
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queueErrors.Close();
				queueDestination.Close();
			}
    
			return;
		}



		public void SendBusinessObject( string strTargetProcess, string strSubject, 
			BusinessObject objSource )
		{
			string strTargetQueueName;
			MessageQueue queue = null;

			try
			{
				strTargetQueueName = ".\\private$\\" + strTargetProcess + "Inbox";

				queue = new MessageQueue( strTargetQueueName );
				Message message = new Message();

				//specify the message formatter
				BinaryMessageFormatter formatter = new BinaryMessageFormatter();
				message.Formatter = formatter;

				//set the message properties
				message.Label = strSubject;
				formatter.Write( message, objSource );

				//send the binary serialized message
				queue.Send( message );
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return;
		}



		public BusinessObject ReceiveBusinessObject()
		{
			MessageQueue queue = null;
			BusinessObject objReceived = null;

			try
			{
				queue = new MessageQueue( _QueueInboxName );

				//retrieve message from the queue
				Message message = queue.Receive();

				//specify the message formatter
				message.Formatter = new BinaryMessageFormatter();

				//display retrieved object data
				objReceived = (BusinessObject)message.Body;
			}
			catch( MessageQueueException exception )
			{
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return objReceived;
		}



		public void SendTransactionMessages( string strTargetProcess, 
			ArrayList arrayMessages )
		{
			string strTargetQueueName;
			MessageQueueTransaction queueTransaction = new MessageQueueTransaction();
			MessageQueue queue = null;

			try
			{
				strTargetQueueName = ".\\private$\\" + strTargetProcess + "Inbox";
				queue = new MessageQueue( strTargetQueueName );
                    
				queueTransaction.Begin();

				foreach( Message message in arrayMessages )
				{
					queue.Send( message, queueTransaction );
				}

				queueTransaction.Commit();
			}
			catch( Exception exception )
			{
				queueTransaction.Abort();

				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return;
		}



		public Message ReceiveTransactionMessage()
		{
			MessageQueueTransaction queueTransaction = new MessageQueueTransaction();
			Message message = null;
			MessageQueue queue = null;

			try
			{
				queue = new MessageQueue( _QueueInboxName );
                    
				queueTransaction.Begin();
				message = queue.Receive( queueTransaction );
				queueTransaction.Commit();
			}
			catch( Exception exception )
			{
				queueTransaction.Abort();

				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( exception.Message, EventLogEntryType.Error, 0 );
			}
			finally
			{
				queue.Close();
			}

			return message;
		}



	}
}
