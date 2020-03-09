using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour 
{
	private int LanguageIndex = 0;
	private MenuMainCanvas _canvas;
	private Text[] _MainMenuTextFields;
	private Text[] _SettingsMenuTextFields;
	private string[] _LocalizationText;
	private Localization localization;

	private void Awake()
	{
		_canvas = FindObjectOfType<MenuMainCanvas>();
		_MainMenuTextFields = _canvas.texts;
		localization = new Localization();
	}

	private void Start()
	{
		print(_SettingsMenuTextFields.Length);
	}

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void ChangeLanguage()
	{
		LanguageIndex++;
		if (LanguageIndex == 3) LanguageIndex = 0;
		print(LanguageIndex);

		if(LanguageIndex == 0)
		{
			_LocalizationText = localization.MainMenuEnglish;
			for (int i = 0; i < _MainMenuTextFields.Length; i++)
			{
				_MainMenuTextFields[i].text = _LocalizationText[i];
			}
		}
		else if (LanguageIndex == 1)
		{
			_LocalizationText = localization.MainMenuRussian;
			for (int i = 0; i < _MainMenuTextFields.Length; i++)
			{
				_MainMenuTextFields[i].text = _LocalizationText[i];
			}
		}
		else if (LanguageIndex == 2)
		{
			_LocalizationText = localization.MainMenuLatin;
			for (int i = 0; i < _MainMenuTextFields.Length; i++)
			{
				_MainMenuTextFields[i].text = _LocalizationText[i];
			}
		}

		_SettingsMenuTextFields = FindObjectOfType<SettingsLocalization>().TextFields;
		if (_SettingsMenuTextFields.Length != 0)
		{
			_canvas.GetTextComponents();
			print(_canvas.texts.Length);

			if (LanguageIndex == 0)
			{
				_LocalizationText = localization.SettingsEnglish;
				for (int i = 0; i < _canvas.texts.Length; i++)
				{
					_canvas.texts[i].text = _LocalizationText[i];
				}
			}
			else if (LanguageIndex == 1)
			{
				_LocalizationText = localization.SettingsRussian;
				for (int i = 0; i < _canvas.texts.Length; i++)
				{
					_canvas.texts[i].text = _LocalizationText[i];
				}
			}
			else if (LanguageIndex == 2)
			{
				_LocalizationText = localization.SettingsLatin;
				for (int i = 0; i < _canvas.texts.Length; i++)
				{
					_canvas.texts[i].text = _LocalizationText[i];
				}
			}

		}
	}

}
