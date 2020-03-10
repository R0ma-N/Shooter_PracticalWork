using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMainCanvas : MonoBehaviour
{
	public Text[] Texts;
	public int CurrentLanguage;

	private void Awake()
	{
		Texts = GetComponentsInChildren<Text>();
	}

	public Text[] GetTextComponents()
	{
		Texts = GetComponentsInChildren<Text>();
		return Texts;
	}
}
