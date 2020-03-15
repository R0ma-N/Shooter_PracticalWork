using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace Shooter
{
    public class MenuGamePause : MonoBehaviour
    {
        [HideInInspector] public Animator Animator;
        public AudioMixer audioSettings;
        public bool InterfacePause = false;
        public UnityEvent PressedClose = new UnityEvent();

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        public void MainMenu()
        {
            PressedClose?.Invoke();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }

        public void Close()
        {
            PressedClose?.Invoke();
        }

        public void MasterSoundControl(float value)
        {
            audioSettings.SetFloat("MasterVolume", value);
        }

        public void MusicSoundControl(float value)
        {
            audioSettings.SetFloat("MusicVolume", value);
        }

        public void SfxSoundControl(float value)
        {
            audioSettings.SetFloat("SfxVolume", value);
        }
    }
}
