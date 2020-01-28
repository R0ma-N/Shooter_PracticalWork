using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class WeaponDron : WeaponBase
    {
        [SerializeField] private Transform _barrel2;

        public override void Fire()
        {           
            if (IsReady)
            {
                var tempAmmunation = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                tempAmmunation = Instantiate(Ammunition, _barrel2.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
            }
        }

        public override void StopFire()
        {

        }
    }
}
