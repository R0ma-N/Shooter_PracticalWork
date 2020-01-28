using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class WeaponDron : WeaponBase
    {
        [SerializeField] 
        public override void Fire()
        {
            _readyToShoot = _timer.TimeIsUp(_shootInterval);
            if (_readyToShoot)
            {
                var tempAmmunation = Instantiate(_bullets, _barrelLeft.position, _barrelLeft.rotation);
                tempAmmunation.AddForce(_barrelLeft.forward * _bulletForce);
                tempAmmunation = Instantiate(_bullets, _barrelRight.position, _barrelRight.rotation);
                tempAmmunation.AddForce(_barrelRight.forward * _bulletForce);
            }
        }
    }
}
