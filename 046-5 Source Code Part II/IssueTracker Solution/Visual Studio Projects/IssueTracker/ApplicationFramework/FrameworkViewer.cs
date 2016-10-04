using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;



namespace ApplicationFramework
{
	/// <summary>
	/// Summary description for FrameworkViewer.
	/// </summary>
	public class FrameworkViewer : System.Windows.Forms.Form
	{
		protected Controller.ControllerActions _ViewMode; 
		protected BusinessRules.BusinessObject _BusinessObject;
		protected BusinessRules.BusinessObjectCollection _BusinessObjectCollection;



		public BusinessRules.BusinessObject BusinessObject
		{
			set
			{
				_BusinessObject = value;
			}
			get
			{
				return _BusinessObject;
			}
		}
		
		
		
		public BusinessRules.BusinessObjectCollection BusinessObjectCollection
		{
			set
			{
				_BusinessObjectCollection = value;
			}
			get
			{
				return _BusinessObjectCollection;
			}
		}

		
		
		public Controller.ControllerActions ViewMode
		{
			set
			{
				_ViewMode = value;
			}
			get
			{
				return _ViewMode;
			}
		}



		public FrameworkViewer()
		{
			InitializeComponent();
		}



		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.FrameworkViewer_Load);
		}



		private void FrameworkViewer_Load(object sender, System.EventArgs e)
		{
			if( _ViewMode == Controller.ControllerActions.View )
			{
				//set all edit and list controls to read only
				foreach( Control controlItem in Controls )
				{
					if( controlItem.GetType().Name.CompareTo( "TextBox" ) == 0 ||
						controlItem.GetType().Name.CompareTo( "ComboBox" ) == 0 ||
						controlItem.GetType().Name.CompareTo( "ListBox" ) == 0 )
					{
						controlItem.Enabled = false;
					}
				}
			}

			return;
		}
	}
}
