using UnityEngine;

namespace Shooter
{
    public class Firearms : WeaponBase
    {
        private ParticleSystem _explosion = null;
        private AudioSource _shoot;

        protected override void Awake()
        {
            base.Awake();
            _explosion = GetComponentInChildren<ParticleSystem>();
            _shoot = GetComponent<AudioSource>();
            _explosion.Stop();
        }
        
        public override void Fire()
        {
            if (IsReady)
            {
                var tempAmmunation = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                _explosion.Play();
                _shoot.Play();
                BulletsCount--;
            }
        }

        public override void StopFire()
        {
        }
    }
}
