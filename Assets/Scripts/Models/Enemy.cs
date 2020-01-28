using UnityEngine;
using UnityEngine.AI;

namespace Shooter
{
    public class Enemy : BaseObjectModel, IDamageable
    {
        public float Health;
        private NavMeshAgent agent;
        private Transform target;

        private Light _eyeLight;
        private ParticleSystem _explotion;
        private Timer _timer = new Timer();

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

        }

        public void getDamage(float damage)
        {
            Health -= damage;
            _eyeLight.enabled = _timer.TimeIsUp(0.5f);
            _eyeLight.enabled = true;

            if (Health <= 0)
            {
                OnDeath();
            }
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
