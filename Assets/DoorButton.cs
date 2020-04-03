using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables ;

namespace Shooter
{

    public class DoorButton : MonoBehaviour, IDamageable
    {
        public PlayableDirector Door;
        private Material _light;
        private ParticleSystem _lighterns;

        void Start()
        {
            _light = GetComponentInParent<DoorLight>()._button;
            _lighterns = GetComponentInChildren<ParticleSystem>();
            _lighterns.Stop();
        }

        public void getDamage(float damage)
        {
            Debug.Log("INDABUTTON");
            _light.SetColor("_EmissionColor", Color.black);
            Door.enabled = true;
            _lighterns.Play();
        }
    }
}
