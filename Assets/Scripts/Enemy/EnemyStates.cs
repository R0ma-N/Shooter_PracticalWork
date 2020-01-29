using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class EnemyStates
    {
        private Transform[] _patrolPoints;
        private int destPoint = 1;

        public EnemyStates()
        {
            _patrolPoints = Object.FindObjectOfType<PatrolPoints>().Points;
            Debug.Log($"StatesConst {_patrolPoints.Length}");
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

    }
}
