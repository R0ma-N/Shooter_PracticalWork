using UnityEngine;

namespace Shooter
{
    public class TargetModel : BaseObjectModel, IDamageable
    {
        public float Health;

        protected override void Awake()
        {
            base.Awake();
            Rigidbody.isKinematic = true;
            MeshRenderer.material.SetColor("_Color", Color.white);
        }

        public void getDamage(float damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                OnDeath();
            }
        }

        public void OnDeath()
        {
            Rigidbody.isKinematic = false;
            MeshRenderer.material.SetColor("_Color", Color.black);
            Destroy(gameObject, 2);
        }
    }
}
