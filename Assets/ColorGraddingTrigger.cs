using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Shooter
{
    public class ColorGraddingTrigger : MonoBehaviour
    {
        public PostProcessProfile pprofile;
        public Vignette Vignette;
        private Player _player;
        private bool _isEnter;
        private bool _getDamage;
        private bool _damageDone;
        private ColorGrading _colorGrading;

        void Start()
        {
            _player = FindObjectOfType<Player>();
            _colorGrading = pprofile.GetSetting<ColorGrading>();
            Vignette = pprofile.GetSetting<Vignette>();
            _colorGrading.temperature.value = -100;
            Vignette.intensity.value = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(TagManager.PLAYER))
            {
                _isEnter = true;
            }
        }

        void Update()
        {
            if (_isEnter & _colorGrading.temperature.value < 80)
            {
                _colorGrading.temperature.value += (Time.deltaTime*20);
            }

            if (_getDamage)
            {
                if(Vignette.intensity < 0.75)
                {
                    Vignette.intensity.value += Time.deltaTime*3;
                    print("++");
                }
                else
                {
                    _getDamage = false;
                    _damageDone = true;
                }
                return;
            }

            if (_damageDone)
            {
                if(Vignette.intensity > 0)
                {
                    Vignette.intensity.value -= Time.deltaTime;
                    print("--");
                }
                else
                {
                    _getDamage = false;
                    _damageDone = false;
                }
                return;
            }
        }

        public void GetDamage()
        {
            _getDamage = true;
        }
    }
}
