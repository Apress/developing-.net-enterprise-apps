using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Xml;



namespace ApplicationFramework
{
	/// <summary>
	/// Summary description for Controller.
	/// </summary>
	public class Controller
	{
		//definition of action types
		public enum ControllerActions
		{
			New = 1,
			View = 2, 
			Edit = 3,
			Delete = 4
		}


		//reference to the controller MDI parent
		static private Form _ParentForm;

		//container for all of the individual object mappings
		static ArrayList _ObjectMappings = new ArrayList();


		//property accessor to set parent form
		public static Form ParentForm
		{
			set
			{
				_ParentForm = value;
			}
		}


		static Controller()
		{
			ObjectMappingEntry entry;

			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load( "WinUI.exe.config" );
			XmlNode root = xmldoc.DocumentElement;

			try 
			{
				XmlNodeList xnodelist = 
					root.SelectNodes( "/configuration/Viewers/Include" ); 

				foreach( XmlNode xnode in xnodelist )
				{
					//create a new entry object
					entry = new ObjectMappingEntry();

					//translate the integer into a ControllerAction
					switch( int.Parse(xnode.Attributes["Action"].Value) )
					{
						case 1:
							entry.Action = ControllerActions.New;
							break;
						case 2:
							entry.Action = ControllerActions.View;
							break;
						case 3:
							entry.Action = ControllerActions.Edit;
							break;
						case 4:
							entry.Action = ControllerActions.Delete;
							break;
					}

					//set the BusinessObjectName
					entry.BusinessObjectName = 
						xnode.Attributes["BusinessObjectName"].Value;

					//set the viewer name
					entry.Viewer = xnode.Attributes["Viewer"].Value;

					//add this mapping to the collection
					_ObjectMappings.Add( entry );

				}
    
			} 
			catch( Exception x ) 
			{          
				EventLog systemLog = new EventLog();
				systemLog.Source = "IssueTracker";
				systemLog.WriteEntry( x.Message, EventLogEntryType.Error, 0 );
			}
 
			return;
		}

		
		static void Controller_1()
		{
			//hard-code new issue mapping
			ObjectMappingEntry entry;

			entry = new ObjectMappingEntry();
			entry.Action = ControllerActions.View;
			entry.BusinessObjectName = "IssueCollection";
			entry.Viewer = "WinUI.FormIssueSummary";
			_ObjectMappings.Add( entry );

			entry = new ObjectMappingEntry();
			entry.Action = ControllerActions.View;
			entry.BusinessObjectName = "Issue";
			entry.Viewer = "WinUI.FormIssueDetails";
			_ObjectMappings.Add( entry );

			entry = new ObjectMappingEntry();
			entry.Action = ControllerActions.New;
			entry.BusinessObjectName = "Issue";
			entry.Viewer = "WinUI.FormIssueDetails";
			_ObjectMappings.Add( entry );

			return;
		}


		public static void Process_1( object argObject, ControllerActions argAction )
		{
			//based on mapping, display specific form
			foreach( ObjectMappingEntry objMapping in _ObjectMappings )
			{
				//find the right business object
				if( argObject.GetType().Name.CompareTo( 
					objMapping.BusinessObjectName ) == 0 )
				{
					//find the right action
					if( objMapping.Action == argAction )
					{
						//start the viewer
						Type typeViewer = Assembly.GetExecutingAssembly().GetType( 
							objMapping.Viewer );

						Form formViewer = (Form)Activator.CreateInstance(typeViewer);
						formViewer.MdiParent = _ParentForm;
						formViewer.WindowState = FormWindowState.Maximized;
						formViewer.Show();

						break;
					}
				}
			}
			return;
		}



		public static void Process( object argObject, ControllerActions argAction )
		{
			//based on mapping, display specific form
			foreach( ObjectMappingEntry objMapping in _ObjectMappings )
			{
				//find the right business object
				if( argObject.GetType().Name.CompareTo( 
					objMapping.BusinessObjectName ) == 0 )
				{
					//find the right action
					if( objMapping.Action == argAction )
					{
						Assembly asm = Assembly.Load( objMapping.Viewer.Substring( 0,
							objMapping.Viewer.IndexOf( '.' ) ) );

						Type typeViewer = asm.GetType( objMapping.Viewer );

						FrameworkViewer formViewer = 
							(FrameworkViewer)Activator.CreateInstance( typeViewer );

						if( objMapping.BusinessObjectName.EndsWith( "Collection" ) )
						{
							formViewer.BusinessObjectCollection = (BusinessRules.BusinessObjectCollection)argObject;
						}
						else
						{
							formViewer.BusinessObject = (BusinessRules.BusinessObject)argObject;
						}

						formViewer.ViewMode = argAction;
						formViewer.MdiParent = _ParentForm;
						formViewer.Show();
						break;
					}
				}
			}

			return;
		}



	}
}
