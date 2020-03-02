using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Player : MonoBehaviour
    {
        protected Animator animator;

        public bool ikActiveFire = false;
        public bool ikActiveLight = false;
        public Transform rightHandObj = null;
        public Transform leftHandObj = null;
        public Transform lookObj = null;

        void Start()
        {
            animator = GetComponent<Animator>();
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

    }
}
