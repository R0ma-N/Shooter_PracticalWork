using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour 
{
	public int LanguageIndex;
	public string MenuState;
	public string MenuUnderState;

	private Text[] _MainMenuTextFields;
	private Text[] _SettingsMenuTextFields;
	private Text[] _gameSettingsTextFields;
	private string[] _LocalizationText;
	public int TempIndex;

	private Localization localization;

	private void Awake()
	{
		localization = new Localization();

		//var DontDestroyObjs = GameObject.FindObjectsOfType<ApplicationManager>();
		//if(DontDestroyObjs.Length > 1)
		//{
		//	Destroy(this.gameObject);
		//}

		//DontDestroyOnLoad(this.gameObject);
	}

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	private void Start()
	{
		_MainMenuTextFields = FindObjectOfType<MenuMainCanvas>().Texts;
		localization.TemporaryLanguage = LanguageIndex;
		print("AppMan start " + LanguageIndex);
		print("AppMan start " + _MainMenuTextFields.Length + " " + localization.MainMenuEnglish.Length);
	}
	public void StartGame()
	{
		TempIndex = LanguageIndex;
		SceneManager.LoadScene(1);
		print("AppMan Load " + TempIndex);
	}

	public void ChangeLanguage()
	{
		LanguageIndex++;
		if (LanguageIndex == 3) LanguageIndex = 0;

		_MainMenuTextFields = FindObjectOfType<MenuMainCanvas>().Texts;
		localization = new Localization();

		print("AppMan OnChange " + LanguageIndex);

		if (LanguageIndex == 0)
		{
			ChangeLanguageInLocal(_MainMenuTextFields, localization.MainMenuEnglish);
		}
		else if (LanguageIndex == 1)
		{
			ChangeLanguageInLocal(_MainMenuTextFields, localization.MainMenuRussian);
		}
		else if (LanguageIndex == 2)
		{
			ChangeLanguageInLocal(_MainMenuTextFields, localization.MainMenuLatin);
		}
	}

	private void ChangeLanguageInLocal(Text[] menuFields, string[] localization)
	{
		for (int i = 0; i < localization.Length; i++)
		{
			menuFields[i].text = localization[i];
		}
	}

	public void GamePlay()
	{
		_gameSettingsTextFields = FindObjectOfType<GameSettingsMenu>().Texts;
		
		if (LanguageIndex == 0)
		{
			ChangeLanguageInLocal(_gameSettingsTextFields, localization.GameplayEnglish);
		}
		else if (LanguageIndex == 1)
		{
			ChangeLanguageInLocal(_gameSettingsTextFields, localization.GameplayRussian);
		}
		else if (LanguageIndex == 2)
		{
			ChangeLanguageInLocal(_gameSettingsTextFields, localization.GameplayLatin);
		}
	}

	public void Video()
	{
		var videoMenuTextFields = FindObjectOfType<MenuVideo>().Texts;
		string[] loc = new string[6];
		if (LanguageIndex == 0) { loc = localization.VideoEnglish; }
		else if (LanguageIndex == 1) { loc = localization.VideoRussian; }
		else if (LanguageIndex == 2) { loc = localization.VideoLatin; }
		ChangeLanguageInLocal(videoMenuTextFields, loc);
	}

	public void Audio()
	{
		var audioMenuTextFields = FindObjectOfType<MenuAudio>().Texts;
		string[] loc = new string[5];
		if (LanguageIndex == 0) { loc = localization.AudioEnglish; }
		else if (LanguageIndex == 1) { loc = localization.AudioRussian; }
		else if (LanguageIndex == 2) { loc = localization.AudioLatin; }
		ChangeLanguageInLocal(audioMenuTextFields, loc);
	}

	public void Settings()
	{
		_SettingsMenuTextFields = FindObjectOfType<SettingsMenuCanvas>().Texts;
		string[] loc = new string[5];
		if (LanguageIndex == 0) { loc = localization.SettingsEnglish; }
		else if (LanguageIndex == 1) { loc = localization.SettingsRussian; }
		else if (LanguageIndex == 2) { loc = localization.SettingsLatin; }
		ChangeLanguageInLocal(_SettingsMenuTextFields, loc);
	}
}
