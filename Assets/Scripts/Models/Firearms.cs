using UnityEngine;

namespace Shooter
{
    public class Firearms : WeaponBase
    {
        public override void Fire()
        {
            if (IsReady)
            {
                var tempAmmunation = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                BulletsCount--;
            }    
        }

        private void Update()
        {
            transform.localRotation = Camera.main.transform.localRotation;
        }
        public override void StopFire()
        {
        }
    }
}
