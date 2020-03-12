using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMainCanvas : MonoBehaviour
{
	public Text[] Texts;
	private ApplicationManager _applicationManager;
	public Localization localization;

	private void Awake()
	{
		localization = new Localization();
		_applicationManager = FindObjectOfType<ApplicationManager>();
		Texts = GetComponentsInChildren<Text>();

		print("Canvas Awake Index " + _applicationManager.LanguageIndex);
		if (_applicationManager.LanguageIndex == 0)
		{
			ChangeLanguageInLocal(Texts, localization.MainMenuEnglish);
		}
		else if (_applicationManager.LanguageIndex == 1)
		{
			ChangeLanguageInLocal(Texts, localization.MainMenuRussian);
		}
		else if (_applicationManager.LanguageIndex == 2)
		{
			ChangeLanguageInLocal(Texts, localization.MainMenuLatin);
		}
	}

	private void ChangeLanguageInLocal(Text[] menuFields, string[] localization)
	{
		for (int i = 0; i < localization.Length; i++)
		{
			menuFields[i].text = localization[i];
		}
	}
}
