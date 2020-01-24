
using UnityEngine;

namespace Shooter
{
    public class FlameModel : Ammunition
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.getDamage(_Damage);
            }
        }
    }
}
