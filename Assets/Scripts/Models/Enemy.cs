using UnityEngine;
using UnityEngine.AI;

namespace Shooter
{
    public class Enemy : MonoBehaviour, IOnInitialize
    {
        public AudioSource _audioSource;
        public AudioClip PatrolSound;
        public AudioClip AttackSound;
        public AudioClip FireSound;
        public AudioClip DeathSound;
        
        public Rigidbody Rigidbody;
        public bool MomentaryDeath = false;

        public Transform[] PatrolPoints;
        private int IndexOfDestinationPoint;
        public NavMeshAgent Agent;
        public ZoneOfDetect ZoneOfDetect;
        private Player _playerScript;
        public bool PlayerDetected;
        
        public WeaponDron Weapon;
        public Transform _player;

        public float Health;
        public Canvas _healthCanvas;
        public EnemyHealthUI _EnemyHealthUI;
        public BodyDron Body;
        public EyeDron Eye;

        public ParticleSystem Explotion;
        public bool IsDead = false;

        [SerializeField] private SpriteRenderer MapPoint;

        public void OnStart()
        {
            //Body = GetComponentInChildren<BodyDron>();
            //Eye = GetComponentInChildren<EyeDron>();
            //Agent = GetComponent<NavMeshAgent>();
            //Weapon = GetComponentInChildren<WeaponDron>();
            //ZoneOfDetect = GetComponentInChildren<ZoneOfDetect>();

            //_EnemyHealthUI = GetComponentInChildren<EnemyHealthUI>();
            //_healthCanvas = GetComponentInChildren<Canvas>();

            Eye.EyeGetDamage.AddListener(Destroy);
            Body.BodyGetDamage.AddListener(GetDamage);

            //_player = GameObject.FindObjectOfType<Player>().CellForEnemy;
            _playerScript = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
            _playerScript.Death.AddListener(OnPlayersDeath);
            //_audioSource = GetComponent<AudioSource>();

            //Explotion = GetComponentInChildren<ParticleSystem>();
            Explotion.Stop();
            
            Agent.destination = PatrolPoints[IndexOfDestinationPoint].position;
        }

        private void Update()
        {
            if (IsDead) return;

            PlayerDetected = ZoneOfDetect.PlayerDetected;

            if (!PlayerDetected) 
            {
                Patrol();
            } 
            else if (_player) Attack(_player);

            if (Input.GetKey(KeyCode.Mouse1))
            {
                _EnemyHealthUI.HealthValueUI.text = Health.ToString();
            }
            else _EnemyHealthUI.HealthValueUI.text = " ";

            if (MomentaryDeath)
            {
                Destroy();
            }
        }

        public void GetDamage()
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
            _EnemyHealthUI.HealthValueUI.text = " ";
            IsDead = true;
            Eye.Light.enabled = false;
            Agent.enabled = false;
            Agent = null;
            Rigidbody.isKinematic = false;
            Body.Rigidbody.isKinematic = false;
            Body.MaterialLights.SetColor("_EmissionColor", Color.black);
            Eye.MaterialLights.SetColor("_EmissionColor", Color.black);
            Eye.MaterialLights.SetColor("_Color", Color.black);
            MapPoint.enabled = false;
            _audioSource.clip = DeathSound;
            _audioSource.Play();
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

            _audioSource.clip = PatrolSound;
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            Eye.Light.color = Color.green;
        }

        public void Attack(Transform target)
        {
            Agent.destination = target.position;
            Agent.stoppingDistance = 5;
            transform.LookAt(target.transform);
            Weapon.Fire();

            _audioSource.clip = AttackSound;
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }

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

        private void GotoNextPoint()
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

        public void OnPlayersDeath()
        {
            _player = null;
            GotoNextPoint();

            //_playerScript.Death.RemoveListener(OnPlayersDeath);
        }

    }
}
