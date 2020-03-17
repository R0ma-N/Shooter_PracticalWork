
using UnityEngine;

namespace Shooter
{
    public class Flamethrower : WeaponBase
    {
        private ParticleSystem _fire = null;
        private AudioSource _fireSound;
        
        override protected void Awake()
        {
             base.Awake();
            _fire = GetComponentInChildren<ParticleSystem>();
            _fireSound = GetComponent<AudioSource>();
            _fire.Stop();
        }

        public override void Fire()
        {
            if (IsReady)
            {
                _fire.Play();
                _fireSound.Play();
            }

            BulletsCount--;

            if (BulletsCount == 1) 
            { 
                StopFire();                
                BulletsCount = 0;
            }
        }

        public override void StopFire()
        {
            _fire.Stop();
            _fireSound.Stop();
        }
    }
}
