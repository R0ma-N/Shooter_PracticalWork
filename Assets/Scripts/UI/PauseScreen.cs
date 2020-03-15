using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private Animator _animator;
    private Image image;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void MakeDarkScreen(bool value)
    {

        _animator.SetBool("Darking", value);
    }
}
