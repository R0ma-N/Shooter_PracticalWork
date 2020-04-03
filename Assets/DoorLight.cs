using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLight : MonoBehaviour
{
    public Material _button;
    private Material[] _lights;
    private Material _signalLamp;

    void Awake()
    {
        _lights = GetComponent<MeshRenderer>().materials;
        _button = _lights[2];
        _signalLamp = _lights[0];
        _signalLamp.SetColor("_EmissionColor", Color.red);
    }

    public void TurnLight()
    {
        _signalLamp.SetColor("_EmissionColor", Color.green);
    }
}
