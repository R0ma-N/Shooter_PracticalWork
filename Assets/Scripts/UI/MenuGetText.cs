using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGetText : MonoBehaviour
{
    public Text[] Texts;
    private void Awake()
    {
        Texts = GetComponentsInChildren<Text>();
    }
}
