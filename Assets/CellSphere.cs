using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSphere : MonoBehaviour
{
    private Transform _player;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        //transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 1, _player.transform.position.z + 5);
       // transform.rotation = Camera.main.transform.rotation;
    }
}
