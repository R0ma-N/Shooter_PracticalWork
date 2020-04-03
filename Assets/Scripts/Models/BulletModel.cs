using UnityEngine;

namespace Shooter
{
    public class BulletModel : Ammunition
    {
        public ParticleSystem _explosion;
        public Light _light;
        private TrailRenderer _trailRenderer;
        private Rigidbody _rigidbody;
        private MeshRenderer _meshRenderer;
        private AudioSource _explotion;
        
        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, _timeToDestruct);
            _trailRenderer = GetComponent<TrailRenderer>();
            _rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            TryGetComponent<AudioSource>(out AudioSource explotion);
            _explotion = explotion;
            if(_explosion)
            _explosion.Pause();
            //_light = GetComponent<Light>();
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.getDamage(_Damage);
                Debug.Log("CollissionDamag");
            }

            Debug.Log(collision.collider.name);
            _trailRenderer.enabled = false;
            _rigidbody.velocity = new Vector3(0, 0, 0);
            _meshRenderer.enabled = false;
            _light.enabled = false;
            if(_explosion)
            _explosion.Play();
            _explotion.Play();
            Destroy(gameObject,0.7f);
        }
    }
}
