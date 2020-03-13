using UnityEngine;

namespace Shooter
{
    public class Firearms : WeaponBase
    {
        public ParticleSystem _explosion;

        protected override void Awake()
        {
            base.Awake();
            //_explosion = GetComponentInChildren<ParticleSystem>();
            _explosion.Stop();
        }
        
        public override void Fire()
        {
            if (IsReady)
            {
                var tempAmmunation = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                _explosion.Play();
                BulletsCount--;
            }
        }

        public override void StopFire()
        {
        }
    }
}
