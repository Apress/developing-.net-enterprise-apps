using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace PocketUI
{
	/// <summary>
	/// Summary description for SoundLayer.
	/// </summary>
	public class SoundLayer
	{
		//specify the bitwise control flags
		[Flags]
			public enum AudioBitFlags : int
		{
			FILENAME = 0x00020000,
			ASYNC = 0x0001
		}

		//import a method from an unmanaged dll
		[DllImport("coredll")]
		private static extern bool PlaySound( string szSound, IntPtr hMod,
			AudioBitFlags flags );

		//abstract the external function with an exposed static play method
		public static void Play( string strFilename )
		{
			try
			{
				PlaySound( strFilename, IntPtr.Zero, 
					AudioBitFlags.FILENAME | AudioBitFlags.ASYNC );
			}
			catch( Exception x )
			{
				MessageBox.Show( "Unable to playback sound file." );
			}
			return;
		}



		public void PlayAlertSound()
		{
			//sound file should be added to project with 'Content' build type
			SoundLayer.Play( "\\Windows\\AlertSound.wav" );
		}



		//import a method from an unmanaged dll
		[DllImport("coredll.dll")]
		private static extern int LoadCursor(int zeroValue, int cursorID );

		//import a method from an unmanaged dll
		[DllImport("coredll.dll")]
		private static extern int SetCursor( int cursorHandle );

		// show or hide the wait cursor
		public void ShowWaitCursor( bool boolShowWait )
		{
			try
			{
				int cursorHandle = 0;

				if( boolShowWait )
				{
					//load the busy cursor
					cursorHandle = LoadCursor( 0, 32514 );
				}

				SetCursor( cursorHandle );
			}
			catch( Exception x )
			{
				MessageBox.Show( "Unable to set cursor." );
			}
			return;
		}


	}
}
