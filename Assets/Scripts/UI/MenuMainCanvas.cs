using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMainCanvas : MonoBehaviour
{
	public Text[] texts;
	public int CurrentLanguage;

	private void Awake()
	{
		texts = GetComponentsInChildren<Text>();
	}

	public void GetTextComponents()
	{
		texts = GetComponentsInChildren<Text>();
	}
}
