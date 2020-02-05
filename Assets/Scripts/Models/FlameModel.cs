
using UnityEngine;

namespace Shooter
{
    public class FlameModel : Ammunition
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                if (other.gameObject.GetComponent<EyeDron>())
                {
                    return;
                }
                
                damageable.getDamage(_Damage);
            }
        }
    }
}
