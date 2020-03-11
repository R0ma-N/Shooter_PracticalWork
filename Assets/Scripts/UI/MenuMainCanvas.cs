using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
	public class MenuMainCanvas : MonoBehaviour
	{
		public Text[] Texts;

		public void Awake()
		{
			Texts = GetComponentsInChildren<Text>();
		}
	}
}
