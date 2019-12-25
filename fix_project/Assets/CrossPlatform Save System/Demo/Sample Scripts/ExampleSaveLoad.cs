using UnityEngine;
using UnityEngine.UI;

namespace CrossPlatformSaveSystem
{
	public class ExampleSaveLoad : MonoBehaviour
	{
		public int clicks = 0;

		public Text platform_display;
		public Text clicks_display;
		public Text autoSave_display;

		//Declares a instance of SampleSaveFile
		SampleSaveFile file;

		void Start ()
		{
			// Creates a new instance of SampleSaveFile
			file = new SampleSaveFile ();

			string p;
			
			// Displays current platform
			// Only for demonstration purpose
			if (Application.platform == RuntimePlatform.Android)
			{
				p = "Android";
			}
			else if (Application.platform == RuntimePlatform.WebGLPlayer)
			{
				p = "WebGL";
			}
			else if (Application.platform == RuntimePlatform.WindowsPlayer)
			{
				p = "Windows";
			}
			else if (Application.platform == RuntimePlatform.WindowsEditor)
			{
				p = "Editor";
			}
			else
			{
				p = Application.platform.ToString ();
				Debug.LogWarning ("Save System Test: Platform not Supported.");
			}
			platform_display.text = string.Format ("Current Platform: {0}", p);

			//Loads current file from autosave
			file = (SampleSaveFile)SaveManager.LoadDataFromAutosave ();

			//If file exists, displays data
			//Not doing this will render NullReferenceException error messages
			if (file != null)
			{
				clicks = file.Clicks;
				clicks_display.text = clicks.ToString ();

				autoSave_display.text = "AutoSave file: " + SaveManager.CurrentSaveFile;
			}
		}
		
		public void ButtonSave (string filename)
		{
			//Create new instance of SampleSaveFile if file is empty
			if (file == null)
				file = new SampleSaveFile ();

			//Updates data of current file
			file.Clicks = clicks;
			//Calls SaveManager to save the file
			SaveManager.SaveDataToFile (file, filename);

			autoSave_display.text = "AutoSave file: " + filename;
		}

		public void ButtonLoad (string filename)
		{
			//Loads file with given name
			file = (SampleSaveFile)SaveManager.LoadDataFromFile (filename);

			//Check if file is not null
			if (file == null)
			{
				autoSave_display.text = "AutoSave file: Null";
			}
			else
			{
				clicks = file.Clicks;
				clicks_display.text = clicks.ToString ();

				autoSave_display.text = "AutoSave file: " + SaveManager.CurrentSaveFile;
			}
		}

		public void ButtonSaveToActiveFile ()
		{
			//Updates data of current file
			file.Clicks = clicks;
			//Calls SaveManager to save the file
			SaveManager.SaveDataToAutoSave (file);
		}

		public void ButtonLoadFromActiveFile ()
		{
			//Loads current file from autosave
			file = (SampleSaveFile)SaveManager.LoadDataFromAutosave ();

			if (file == null)
			{
				autoSave_display.text = "AutoSave file: Null";
			}
			else
			{
				clicks = file.Clicks;
				clicks_display.text = clicks.ToString ();

				autoSave_display.text = "AutoSave file: " + SaveManager.CurrentSaveFile;
			}
		}

		public void ButtonClick ()
		{
			clicks++;
			clicks_display.text = clicks.ToString ();
		}
	}
}
