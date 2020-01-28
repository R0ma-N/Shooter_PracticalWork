using UnityEngine;
using UnityEngine.AI;

namespace Shooter
{
    public class Enemy : BaseObjectModel
    {
        public float Health;

        [SerializeField] private Transform _barrelLeft;
        [SerializeField] private Transform _barrelRight;
        [SerializeField] private Ammunition _bullets;
        [SerializeField] private float _bulletForce = 999;


        private NavMeshAgent agent;
        private Transform target;

        private Light _eyeLight;
        private ParticleSystem _explotion;
        private Timer _timer = new Timer();
        private float _shootInterval = 1;
        private bool _readyToShoot;

        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
            _eyeLight = GetComponentInChildren<Light>();
            _explotion = GetComponentInChildren<ParticleSystem>();
            target = FindObjectOfType<CharacterController>().transform;

            Rigidbody.isKinematic = true;
            _eyeLight.enabled = true;
            _explotion.Stop();
        }

        void Update()
        {
            if(agent.enabled)
            agent.SetDestination(target.position);
            Fire();
        }

        

        public void OnDeath()
        {
            _eyeLight.enabled = false;
            Rigidbody.isKinematic = false;
            _explotion.Play();
            agent.enabled = false;
            Destroy(gameObject, 1);
        }

        public void Fire()
        {
            _readyToShoot = _timer.TimeIsUp(_shootInterval);
            if (_readyToShoot)
            {
                var tempAmmunation = Instantiate(_bullets, _barrelLeft.position, _barrelLeft.rotation);
                tempAmmunation.AddForce(_barrelLeft.forward* _bulletForce);
                tempAmmunation = Instantiate(_bullets, _barrelRight.position, _barrelRight.rotation);
                tempAmmunation.AddForce(_barrelRight.forward * _bulletForce);
            }
        }
    }
}
