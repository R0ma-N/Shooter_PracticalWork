using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsLocalization : MonoBehaviour
{
    public Text[] TextFields;
    private Localization _localization;

    private void Awake()
    {
        _localization = new Localization();
        TextFields = GetComponentsInChildren<Text>();
    }
}
