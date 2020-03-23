using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Scrollbar Health; 

    void Start()
    {
        Health = GetComponent<Scrollbar>();
        Health.size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
