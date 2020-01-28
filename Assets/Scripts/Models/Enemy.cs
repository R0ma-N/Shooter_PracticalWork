using UnityEngine;
using UnityEngine.AI;

namespace Shooter
{
    public class Enemy : BaseObjectModel
    {
        public float Health;

        [SerializeField] private Ammunition _bullets;
        [SerializeField] private float _bulletForce = 999;


        private NavMeshAgent agent;
        private Transform target;

        private Light _eyeLight;
        private ParticleSystem _explotion;
        private Timer _timer = new Timer();
        private float _shootInterval = 1;
        private bool _readyToShoot;
        private WeaponBase _weapon;

        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
            _eyeLight = GetComponentInChildren<Light>();
            _explotion = GetComponentInChildren<ParticleSystem>();
            target = FindObjectOfType<CharacterController>().transform;
            _weapon = GetComponent<WeaponDron>();

            Rigidbody.isKinematic = true;
            _eyeLight.enabled = true;
            _explotion.Stop();
        }

        void Update()
        {
            if(agent.enabled)
            agent.SetDestination(target.position);
            _weapon.Fire();
        }

        

        public void OnDeath()
        {
            _eyeLight.enabled = false;
            Rigidbody.isKinematic = false;
            _explotion.Play();
            agent.enabled = false;
            Destroy(gameObject, 1);
        }

    }
}
