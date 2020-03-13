using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MakeDarkScreen(bool value)
    {
        _animator.SetBool("MakeDark", value);
    }
}
