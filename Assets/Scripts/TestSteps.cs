﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSteps : MonoBehaviour
{
    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
}
