using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class WeaponDron : BaseObjectModel
    {
        [SerializeField] private Transform _barrel = null;
        [SerializeField] private Transform _barrel2 = null;
        [SerializeField] private Ammunition _ammunition = null;
        [SerializeField] private float _shootInterval = 0.5f;
        [SerializeField] private float _force = 999;
        [SerializeField ]private AudioSource _audioSource;

        private bool _isReady;
        private Timer _timer = new Timer();
        
        public void Fire()
        {
            _isReady = _timer.TimeIsUp(_shootInterval);
            if (_isReady)
            {
                var tempAmmunation = Instantiate(_ammunition, _barrel.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                tempAmmunation = Instantiate(_ammunition, _barrel2.position, _barrel2.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                _audioSource.Play();
            }
        }
    }
}
