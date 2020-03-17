using UnityEngine;
using UnityEngine.AI;

namespace Shooter
{
    public class Enemy : BaseObjectModel
    {
        public float Health;

        public NavMeshAgent Agent;
        public WeaponDron Weapon;
        public ParticleSystem Explotion;
        public ZoneOfDetect ZoneOfDetect;
        public BodyDron Body;
        public EyeDron Eye;
        public bool PlayerDetected;
        public EnemyStates State;

        protected override void Awake()
        {
            base.Awake();
            Body = GetComponentInChildren<BodyDron>();
            Eye = GetComponentInChildren<EyeDron>();
            Agent = GetComponent<NavMeshAgent>();
            Explotion = GetComponentInChildren<ParticleSystem>();
            Weapon = GetComponentInChildren<WeaponDron>();
            ZoneOfDetect = GetComponentInChildren<ZoneOfDetect>();
            State = new EnemyStates();

            Eye.EyeGetDamage.AddListener(Destroy);
            Body.BodyGetDamage.AddListener(GetDamage);
            Explotion.Stop();
        }

        private void Update()
        {
            PlayerDetected = ZoneOfDetect.PlayerDetected;
        }

        private void GetDamage()
        {
            Health -= Body.Damage;
            if (Health <= 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            Eye.Light.enabled = false;
            Agent.enabled = false;
            Agent = null;
            Rigidbody.isKinematic = false;
            Body.Rigidbody.isKinematic = false;
            Eye.Rigidbody.isKinematic = false;
            Explotion.Play();
            //Destroy(gameObject, time);
        }

    }
}
