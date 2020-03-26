using UnityEngine;
using UnityEngine.AI;

namespace Shooter
{
    public class Enemy : BaseObjectModel
    {
        public float Health;
        public Transform[] PatrolPoints;
        public int IndexOfDestinationPoint;

        public NavMeshAgent Agent;
        public WeaponDron Weapon;
        public ParticleSystem Explotion;
        public ZoneOfDetect ZoneOfDetect;
        public BodyDron Body;
        public EyeDron Eye;
        public bool PlayerDetected;
        public EnemyStates State;

        private EnemyHealthUI _EnemyHealthUI;
        public Canvas _healthCanvas;

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
            _EnemyHealthUI = GetComponentInChildren<EnemyHealthUI>();
            _healthCanvas = GetComponentInChildren<Canvas>();

            Eye.EyeGetDamage.AddListener(Destroy);
            Body.BodyGetDamage.AddListener(GetDamage);
            Explotion.Stop();
            Agent.destination = PatrolPoints[IndexOfDestinationPoint].position;
        }

        private void Update()
        {
            PlayerDetected = ZoneOfDetect.PlayerDetected;

            if (Input.GetKey(KeyCode.Mouse1))
            {
                _EnemyHealthUI.HealthValueUI.text = Health.ToString();
            }
            else _EnemyHealthUI.HealthValueUI.text = " ";
        }

        private void GetDamage()
        {
            Health -= Body.Damage;
            _EnemyHealthUI.HealthValueUI.text = Health.ToString();
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
            _EnemyHealthUI.HealthValueUI.text = " ";
            Explotion.Play();
            Destroy(gameObject, 40);
        }

        public void Patrol()
        {
            if (!Agent.pathPending && Agent.remainingDistance < 0.5f)
            {
                print("gonext");
                GotoNextPoint();
            }

            Eye.Light.color = Color.green;
        }

        public void Attack(Transform target)
        {
            Agent.destination = target.position;
            Agent.stoppingDistance = 5;
            transform.LookAt(target.transform);
            Weapon.Fire();
            //сюда запишется инфо о пересечении луча, если оно будет
            RaycastHit hit;
            //сам луч, начинается от позиции этого объекта и направлен в сторону цели
            Ray ray = new Ray(Eye.transform.position, target.position - Eye.transform.position);
            //пускаем луч
            Physics.Raycast(ray, out hit);

            //если луч с чем-то пересёкся, то..
            if (hit.collider != null)
            {
                //если луч не попал в цель
                if (hit.collider.gameObject != target.gameObject)
                {
                    //Debug.Log("Путь к врагу преграждает объект: " + hit.collider.name);
                }
                //если луч попал в цель
                else
                {
                    //Debug.Log("Попадаю во врага!!!");
                }
                //просто для наглядности рисуем луч в окне Scene
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                Eye.Light.color = Color.red;
            }
        }

        public void GotoNextPoint()
        {
            // Returns if no points have been set up
            if (PatrolPoints.Length == 0)
                return;
            
            Agent.stoppingDistance = 0;
            // Set the agent to go to the currently selected destination.
            Agent.destination = PatrolPoints[IndexOfDestinationPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            IndexOfDestinationPoint = (IndexOfDestinationPoint + 1) % PatrolPoints.Length;
        }
    }
}
