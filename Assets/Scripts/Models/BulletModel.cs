
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
                Debug.Log("CollissionDamag");
            }
            Debug.Log(collision.collider.name);
            Destroy(gameObject);
        }
    }
}
