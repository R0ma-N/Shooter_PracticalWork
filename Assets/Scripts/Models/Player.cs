using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

namespace Shooter
{
    public class Player : MonoBehaviour, IOnInitialize, IDamageable
    {
        public float Health;
        public AudioSource Music;
        public AudioClip[] Sounds;
        public AudioClip[] PainSounds;
        public AudioClip HealSound;

        public bool ikActiveFire = false;
        public bool ikActiveLight = false;
        public Transform rightHandObj = null;
        public Transform leftHandObj = null;
        public Transform lookObj = null;
        public Transform CellForEnemy;
        public UnityEvent Death = new UnityEvent();

        private Transform[] Objs;
        private AudioSource _audioSourse;
        private Animator animator;
        private HealthBar _healthBarUI;
        private GameOverUI _gameOverUI;
        private ColorGraddingTrigger _vignette;

        [SerializeField] private PostProcessProfile _pprofile;
        public ColorGrading _colorGrading;

        public void OnStart()
        {
            Music.pitch = 1;
            animator = GetComponent<Animator>();
            _audioSourse = GetComponent<AudioSource>();
            Objs = GetComponentsInChildren<Transform>();
            for (int i = 0; i < Objs.Length; i++)
            {
                if (Objs[i].name == "Cell for Enemy")
                {
                    CellForEnemy = Objs[i];
                }
            }
            _healthBarUI = GameObject.FindObjectOfType<HealthBar>();
            _vignette = GameObject.FindObjectOfType<ColorGraddingTrigger>();
            _gameOverUI = GameObject.FindObjectOfType<GameOverUI>().GetComponent<GameOverUI>();
        }
        
        public void Footstep()
        {
            if (_audioSourse ==  Sounds[0])
            {
                _audioSourse.volume = 0.8f;
                _audioSourse.Play();
            }
            else
            {
                if (!_audioSourse.isPlaying)
                {
                    _audioSourse.clip = Sounds[0];
                    _audioSourse.volume = 0.6f;
                    _audioSourse.Play();
                }
            }
        }

        public void GotWeaponSound()
        {
            _audioSourse.clip = Sounds[1];
            _audioSourse.volume = 0.2f;
            _audioSourse.Play();
        }

        //Вызывается при расчёте IK
        void OnAnimatorIK()
        {
            if (animator)
            {

                //Если, мы включили IK, устанавливаем позицию и вращение
                if (ikActiveFire)
                {

                    // Устанавливаем цель взгляда для головы
                    if (lookObj != null)
                    {
                        animator.SetLookAtWeight(1);
                        animator.SetLookAtPosition(lookObj.position);
                    }

                    // Устанавливаем цель для правой руки и выставляем её в позицию
                    if (rightHandObj != null)
                    {
                        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.1f);
                        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);



                        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.1f);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                    }
                }
                else if (ikActiveLight)
                {
                    if (lookObj != null)
                    {
                        animator.SetLookAtWeight(1);
                        animator.SetLookAtPosition(lookObj.position);
                    }

                    if (rightHandObj != null)
                    {
                        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.1f);
                        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                    }
                }

                // Если IK неактивен, ставим позицию и вращение рук и головы в изначальное положение
                else
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                    animator.SetLookAtWeight(0);
                }
            }
        }

        public void getDamage(float damage)
        {
            Health -= damage;
            _healthBarUI.Health.size -= damage / 100;
            _vignette.GetDamage();

            _audioSourse.clip = PainSounds[Random.Range(0, 2)];
            _audioSourse.Play();
            
            if (Health <= 0)
            {
                Dying();
            }
        }

        public void Healing()
        {
            Health = 100;
            _audioSourse.clip = HealSound;
            _audioSourse.volume = 0.1f;
            _audioSourse.Play();
            _healthBarUI.Health.size = 1;
        }

        private void Dying()
        {
            Time.timeScale = 0.5f;

            rightHandObj = null;
            leftHandObj = null;
            lookObj = null;

            animator.SetTrigger("Dying");
            Camera.main.GetComponent<Animator>().SetTrigger("Death");
            GameObject.FindGameObjectWithTag("Finish").SetActive(false);

            _vignette.Dying();
            _gameOverUI.GameOverText();
            Death?.Invoke();
        }
    }
}
