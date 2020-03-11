using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Shooter
{
    public class ColorGraddingTrigger : MonoBehaviour
    {
        private Player _player;
        private bool _isEnter;
        [SerializeField] private PostProcessProfile _pprofile;
        private ColorGrading _colorGrading;

        void Start()
        {
            _player = FindObjectOfType<Player>();
            _colorGrading = _pprofile.GetSetting<ColorGrading>();
            _colorGrading.temperature.value = -100;
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
        }
    }
}
