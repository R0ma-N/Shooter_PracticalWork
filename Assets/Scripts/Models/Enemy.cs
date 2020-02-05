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

        protected override void Awake()
        {
            base.Awake();
            Body = GetComponentInChildren<BodyDron>();
            Eye = GetComponentInChildren<EyeDron>();
            Agent = GetComponent<NavMeshAgent>();
            Explotion = GetComponentInChildren<ParticleSystem>();
            Weapon = GetComponentInChildren<WeaponDron>();
            ZoneOfDetect = GetComponentInChildren<ZoneOfDetect>();
        }

        public void Destroy(float time)
        {
            Destroy(gameObject, time);
        }

    }
}
