
using UnityEngine;

namespace Shooter
{
    public class BulletModel : Ammunition
    {
        private ParticleSystem _explosion;
        private TrailRenderer _trailRenderer;
        private Rigidbody _rigidbody;
        private MeshRenderer _meshRenderer;
        private AudioSource _explotion;
        
        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, _timeToDestruct);
            _explosion = GetComponentInChildren<ParticleSystem>();
            _trailRenderer = GetComponent<TrailRenderer>();
            _rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponent<MeshRenderer>();
            TryGetComponent<AudioSource>(out AudioSource explotion);
            _explotion = explotion;
            _explosion.Stop();
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.getDamage(_Damage);
                Debug.Log("CollissionDamag");
            }

            if (collision.collider)
            {
            }
            Debug.Log(collision.collider.name);
            _trailRenderer.enabled = false;
            _rigidbody.velocity = new Vector3(0, 0, 0);
            _explosion.Play();
            //_explotion.Play();
            Destroy(gameObject,0.7f);
        }
    }
}
