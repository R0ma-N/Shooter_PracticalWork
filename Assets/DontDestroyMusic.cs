using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    private DontDestroyMusic[] _ojbjs;
    private AudioSource _music;

    void Awake()
    {
        _music = GetComponent<AudioSource>();
        _music.pitch = 1;
        //DontDestroyOnLoad(this);

        //_ojbjs = GameObject.FindObjectsOfType<DontDestroyMusic>();
       
        //if (_ojbjs.Length > 1)
        //{
            
        //    Destroy(this.gameObject);
        //}
    }

    public void OnPlayerDeath()
    {
        _music.pitch = 0.3f;
    }
}
