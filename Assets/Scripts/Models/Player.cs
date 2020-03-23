﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Shooter
{
    public class Player : MonoBehaviour, IOnInitialize, IDamageable
    {
        public float Health;

        public bool ikActiveFire = false;
        public bool ikActiveLight = false;
        public Transform rightHandObj = null;
        public Transform leftHandObj = null;
        public Transform lookObj = null;
        public Transform CellForEnemy;

        private Transform[] Objs;
        private AudioSource _step;
        private Animator animator;
        private HealthBar _healthBarUI;
        private ColorGraddingTrigger _vignette;

        [SerializeField] private PostProcessProfile _pprofile;
        public ColorGrading _colorGrading;

        public void OnStart()
        {
            animator = GetComponent<Animator>();
            _step = GetComponent<AudioSource>();
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
        }
        
        public void Footstep(string s)
        {
            _step.Play();
        }

        public void Footstep2(string s)
        {
            _step.Play();
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
            Camera.main.GetComponent<Animator>().SetTrigger("Damage");
        }
    }
}
