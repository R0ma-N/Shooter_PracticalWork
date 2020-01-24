
using UnityEngine;

namespace Shooter
{
    public class BulletModel : Ammunition
    {
        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, _timeToDestruct);
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.getDamage(_Damage);
            }

            Destroy(gameObject);
        }
    }
}
