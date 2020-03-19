using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class EnemyStates
    {
        private Transform[] _patrolPoints;
        private int destPoint = 1;
        RaycastHit hit;
        Ray ray;

        public EnemyStates()
        {
            _patrolPoints = Object.FindObjectOfType<PatrolPoints>().Points;
        }

        public void Patrol(Enemy enemy)
        {
            _patrolPoints = Object.FindObjectOfType<PatrolPoints>().Points;

            enemy.Agent.destination = _patrolPoints[destPoint].position;

            if (!enemy.Agent.pathPending && enemy.Agent.remainingDistance < 0.5)
            {
                destPoint++;
                if(destPoint == _patrolPoints.Length)
                {
                    destPoint = 0;
                }
            }
            
            enemy.Eye.Light.color = Color.green;
        }

        public void Attack(Enemy enemy, Transform target)
        {
            enemy.Agent.destination = target.position;
            enemy.transform.LookAt(target.transform);
            enemy.Weapon.Fire();
            //сюда запишется инфо о пересечении луча, если оно будет
            RaycastHit hit;
            //сам луч, начинается от позиции этого объекта и направлен в сторону цели
            Ray ray = new Ray(enemy.Eye.transform.position, target.position - enemy.Eye.transform.position);
            //пускаем луч
            Physics.Raycast(ray, out hit);

            //если луч с чем-то пересёкся, то..
            if (hit.collider != null)
            {
                //если луч не попал в цель
                if (hit.collider.gameObject != target.gameObject)
                {
                    Debug.Log("Путь к врагу преграждает объект: " + hit.collider.name);
                }
                //если луч попал в цель
                else
                {
                    Debug.Log("Попадаю во врага!!!");
                }
                //просто для наглядности рисуем луч в окне Scene
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                enemy.Eye.Light.color = Color.red;
            }
        }

    }
}
